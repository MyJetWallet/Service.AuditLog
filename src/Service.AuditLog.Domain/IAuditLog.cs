using System;

namespace Service.AuditLog.Domain
{
    public interface IAuditLog
    {
        string TraderId { get; }
        
        string Ip { get; set; }
        
        string ServiceName { get; set; }
        
        DateTime? IsDeleted { get; set; }
        
        string UpdatedData { get; set; }
        
        string Before { get; set; }
        
        string After { get; set; }
        
        string ProcessId { get; set; }
        
        string Context { get; set; }
    }

    public class AuditLog : IAuditLog
    {
        public string TraderId { get; set; }

        public string Ip { get; set; }
        
        public string ServiceName { get; set; }
        
        public DateTime? IsDeleted { get; set; }
        
        public string UpdatedData { get; set; }
        
        public string Before { get; set; }
        
        public string After { get; set; }
        
        public string ProcessId { get; set; }
        
        public string Context { get; set; }
    }
}