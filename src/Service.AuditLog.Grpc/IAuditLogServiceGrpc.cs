using System.ServiceModel;
using System.Threading.Tasks;
using Service.AuditLog.Grpc.Contracts;
using Service.AuditLog.Grpc.Models;

namespace Service.AuditLog.Grpc
{
    [ServiceContract]
    public interface IAuditLogServiceGrpc
    {
        [OperationContract]
        public ValueTask RegisterEventAsync(AuditLogGrpcModel request);

        [OperationContract]
        public ValueTask<GetEventsGrpcResponse> GetEventsAsync(GetEventsGrpcRequest request);
    }
}