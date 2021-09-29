using Service.AuditLog.Domain;
using Service.AuditLog.Grpc.Models;

namespace Service.AuditLog.Mappers
{
    public static class DomainToGrpcMapper
    {
        public static AuditLogGrpcModel Create(IAuditLog src)
        {
            return new AuditLogGrpcModel
            {
                TraderId = src.TraderId,
                ProcessId = src.ProcessId,
                Ip = src.Ip,
                ServiceName = src.ServiceName,
                Context = src.Context,
                Before = src.Before,
                UpdatedData = src.UpdatedData,
                After = src.After
            };
        }
    }
}