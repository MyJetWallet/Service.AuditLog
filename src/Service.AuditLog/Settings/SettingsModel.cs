using MyJetWallet.Sdk.Service;
using MyYamlParser;

namespace Service.AuditLog.Settings
{
    public class SettingsModel
    {
        [YamlProperty("AuditLog.SeqServiceUrl")]
        public string SeqServiceUrl { get; set; }

        [YamlProperty("AuditLog.ZipkinUrl")]
        public string ZipkinUrl { get; set; }

        [YamlProperty("AuditLog.ElkLogs")]
        public LogElkSettings ElkLogs { get; set; }
        
        [YamlProperty("AuditLog.AzureStorageConnString")]
        public string AzureStorageConnString { get; set; }
    }
}
