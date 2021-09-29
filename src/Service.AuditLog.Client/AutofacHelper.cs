using Autofac;
using Service.AuditLog.Grpc;

// ReSharper disable UnusedMember.Global

namespace Service.AuditLog.Client
{
    public static class AutofacHelper
    {
        public static void RegisterAuditLogClient(this ContainerBuilder builder, string grpcServiceUrl)
        {
            var factory = new AuditLogClientFactory(grpcServiceUrl);

            builder.RegisterInstance(factory.GetAuditLogService()).As<IAuditLogServiceGrpc>().SingleInstance();
        }
    }
}
