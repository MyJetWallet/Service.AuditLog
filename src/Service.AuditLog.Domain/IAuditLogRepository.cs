using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.AuditLog.Domain
{
    public interface IAuditLogRepository
    {
        Task SaveAsync(IAuditLog log);

        Task<IReadOnlyList<IAuditLog>> Get(string traderId, DateTime dateTimeFrom, DateTime dateTimeTo);
    }
}