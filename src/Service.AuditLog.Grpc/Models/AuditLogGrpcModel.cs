using System;
using System.Runtime.Serialization;

namespace Service.AuditLog.Grpc.Models
{
    [DataContract]
    public class AuditLogGrpcModel
    {
        [DataMember(Order = 1)]
        public string TraderId { get; set; }

        [DataMember(Order = 2)]
        public string Ip { get; set; }
        
        [DataMember(Order = 3)]
        public string ServiceName { get; set; }
        
        [DataMember(Order = 4)]
        public DateTime? IsDeleted { get; set; }
        
        [DataMember(Order = 5)]
        public string UpdatedData { get; set; }
        
        [DataMember(Order = 6)]
        public string Before { get; set; }
        
        [DataMember(Order = 7)]
        public string After { get; set; }
        
        [DataMember(Order = 8)]
        public string ProcessId { get; set; }
        
        [DataMember(Order = 9)]
        public string Context { get; set; }
    }
}