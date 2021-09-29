using SimpleTrading.Common;

namespace Service.AuditLog.AzureStorage
{
    public static class EncoderDecoder
    {
        public static void Encode(this AuditLogAzureEntity entity, byte[] initKey, byte[] initVector)
        {
            entity.Before = entity.Before.Encode(initKey, initVector);
            entity.UpdatedData = entity.UpdatedData.Encode(initKey, initVector);
            entity.After = entity.After.Encode(initKey, initVector);
        }
        
        public static void Decode(this AuditLogAzureEntity entity, byte[] initKey, byte[] initVector)
        {
            entity.Before = entity.Before.Decode(initKey, initVector);
            entity.UpdatedData = entity.UpdatedData.Decode(initKey, initVector);
            entity.After = entity.After.Decode(initKey, initVector);
        }
    }
}