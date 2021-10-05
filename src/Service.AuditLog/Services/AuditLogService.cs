using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using Service.AuditLog.Domain;
using Service.AuditLog.Grpc;
using Service.AuditLog.Grpc.Contracts;
using Service.AuditLog.Grpc.Models;
using Service.AuditLog.Mappers;

namespace Service.AuditLog.Services
{
    public class AuditLogService : IAuditLogServiceGrpc
    {
        private readonly ConcurrentQueue<IAuditLog> _myQueue;
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogService(ConcurrentQueue<IAuditLog> myQueue, IAuditLogRepository auditLogRepository)
        {
            _myQueue = myQueue;
            _auditLogRepository = auditLogRepository;
        }

        public async ValueTask RegisterEventAsync(AuditLogGrpcModel request)
        {
            _myQueue.Enqueue(request.ToDomain());
        }

        public async ValueTask<GetEventsGrpcResponse> GetEventsAsync(GetEventsGrpcRequest request)
        {
            var result = await _auditLogRepository.Get(request.TraderId, request.DateTimeFrom, request.DateTimeTo);
            return new GetEventsGrpcResponse { Events = result.Select(DomainToGrpcMapper.Create) };
        }
    }
}