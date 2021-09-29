using Service.AuditLog.Grpc.Models;

namespace Service.AuditLog.Mappers
{
    public static class GrpcToDomainMapper
    {
        public static Domain.AuditLog ToDomain(this AuditLogGrpcModel request)
        {
            return new Domain.AuditLog
            {
                TraderId = request.TraderId,
                ProcessId = request.ProcessId,
                Ip = request.Ip,
                ServiceName = request.ServiceName,
                Context = request.Context,
                Before = request.Before,
                UpdatedData = request.UpdatedData,
                After = request.After
            };
        }
    }
}