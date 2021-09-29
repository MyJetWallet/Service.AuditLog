using JetBrains.Annotations;
using MyJetWallet.Sdk.Grpc;
using Service.AuditLog.Grpc;

namespace Service.AuditLog.Client
{
    [UsedImplicitly]
    public class AuditLogClientFactory: MyGrpcClientFactory
    {
        public AuditLogClientFactory(string grpcServiceUrl) : base(grpcServiceUrl)
        {
        }

        public IAuditLogServiceGrpc GetAuditLogService() => CreateGrpcService<IAuditLogServiceGrpc>();
    }
}
