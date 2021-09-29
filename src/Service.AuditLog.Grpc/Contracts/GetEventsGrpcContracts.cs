using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Service.AuditLog.Grpc.Models;

namespace Service.AuditLog.Grpc.Contracts
{
    [DataContract]
    public class GetEventsGrpcRequest
    {
        [DataMember(Order = 1)]
        public string TraderId { get; set; }
        
        [DataMember(Order = 2)]
        public DateTime DateTimeFrom { get; set; }
        
        [DataMember(Order = 3)]
        public DateTime DateTimeTo { get; set; }
    }

    [DataContract]
    public class GetEventsGrpcResponse
    {
        [DataMember(Order = 1)]
        public IEnumerable<AuditLogGrpcModel> Events { get; set; }
    }
}