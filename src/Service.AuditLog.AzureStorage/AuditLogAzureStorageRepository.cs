using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;
using MyAzureTableStorage;
using Service.AuditLog.Domain;

namespace Service.AuditLog.AzureStorage
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly IAzureTableStorage<AuditLogAzureEntity> _tableStorage;
        private readonly byte[] _initKey;
        private readonly byte[] _initVector;
        
        public AuditLogRepository(IAzureTableStorage<AuditLogAzureEntity> tableStorage, byte[] initKey, byte[] initVector)
        {
            _tableStorage = tableStorage;
            _initKey = initKey;
            _initVector = initVector;
        }

        public async Task SaveAsync(IAuditLog log)
        {
            var entity = AuditLogAzureEntity.Create(log, DateTime.Now.ToString("s"));
            entity.Encode(_initKey, _initVector);
            
            await _tableStorage.InsertAsync(entity);
        }
        
        public async Task<IReadOnlyList<IAuditLog>> Get(string traderId, DateTime from, DateTime to)
        {
            var pk = AuditLogAzureEntity.GeneratePartitionKey(traderId);
            var rkFrom = AuditLogAzureEntity.GenerateRowKey(from.ToString("s"));
            var rkTo = AuditLogAzureEntity.GenerateRowKey(to.ToString("s"));

            var pkFilter = TableQuery
                .GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, pk);
            
            var rkFromFiler = TableQuery
                .GenerateFilterCondition("RowKey", QueryComparisons.GreaterThanOrEqual, rkFrom);
            
            var rkToFiler = TableQuery
                .GenerateFilterCondition("RowKey", QueryComparisons.LessThan, rkTo);
            
            var combinedRowKeyFilter = TableQuery
                .CombineFilters(rkFromFiler, TableOperators.And, rkToFiler);
            
            var combinedFilter = TableQuery
                .CombineFilters(pkFilter, TableOperators.And, combinedRowKeyFilter);
            
            var tableQuery = new TableQuery<AuditLogAzureEntity>().Where(combinedFilter);
            
            var result = new List<IAuditLog>();
            
            await foreach (var entity in _tableStorage.ExecQueryAsync(tableQuery))
            {
                entity.Decode(_initKey, _initVector);
                result.Add(entity);
            }

            return result;
        }
    }
}