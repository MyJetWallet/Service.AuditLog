using System;
using Microsoft.WindowsAzure.Storage.Table;
using Service.AuditLog.Domain;

namespace Service.AuditLog.AzureStorage
{
    public class AuditLogAzureEntity : TableEntity, IAuditLog
    {
        public static string GeneratePartitionKey(string traderId)
        {
            return traderId;
        }

        public static string GenerateRowKey(string createdAt)
        {
            return createdAt;
        }

        public string TraderId => PartitionKey;
        
        public string Ip { get; set; }
        
        public string ServiceName { get; set; }
        
        public DateTime? IsDeleted { get; set; }
        
        public string UpdatedData { get; set; }
        
        public string Before { get; set; }
        
        public string After { get; set; }
        
        public string ProcessId { get; set; }
        
        public string Context { get; set; }

        public static AuditLogAzureEntity Create(IAuditLog src, string createdAt)
        {
            return new AuditLogAzureEntity
            {
                PartitionKey = GeneratePartitionKey(src.TraderId),
                RowKey = GenerateRowKey(createdAt),
                Ip = src.Ip,
                ServiceName = src.ServiceName,
                After = src.After,
                Before = src.Before,
                UpdatedData = src.UpdatedData,
                ProcessId = src.ProcessId,
                Context = src.Context
            };
        }
    }
}