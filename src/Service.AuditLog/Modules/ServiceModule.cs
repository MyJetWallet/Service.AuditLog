using System;
using System.Collections.Concurrent;
using System.Text;
using Autofac;
using Service.AuditLog.AzureStorage;
using Service.AuditLog.Domain;

namespace Service.AuditLog.Modules
{
    public class ServiceModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var key = Environment.GetEnvironmentVariable(Program.EncodingKeyStr);
            
            if (string.IsNullOrEmpty(key))
                throw new Exception($"Env Variable {Program.EncodingKeyStr} is not found");
            
            var initVector = Environment.GetEnvironmentVariable(Program.EncodingInitVectorStr);
            
            if (string.IsNullOrEmpty(initVector))
                throw new Exception($"Env Variable {Program.EncodingInitVectorStr} is not found");

            Program.EncodingKey = Encoding.UTF8.GetBytes(key);
            Program.InitVector = Encoding.UTF8.GetBytes(initVector);
            
            var auditLogTable = new MyAzureTableStorage.AzureTableStorage<AuditLogAzureEntity>(Program.ReloadedSettings(t=>t.AzureStorageConnString), "auditlog");

            builder.RegisterInstance(new AuditLogRepository(
                auditLogTable,
                Program.EncodingKey,
                Program.InitVector))
                .As<IAuditLogRepository>()
                .SingleInstance();

            builder.RegisterInstance(new ConcurrentQueue<IAuditLog>()).AsSelf().SingleInstance();
        }
    }
}