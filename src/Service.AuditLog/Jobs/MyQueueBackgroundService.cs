using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Service.AuditLog.Domain;

namespace Service.AuditLog.Jobs
{
    public class MyQueueBackgroundService : BackgroundService
    {
        private readonly ConcurrentQueue<IAuditLog> _myQueue;
        private readonly IAuditLogRepository _auditLogRepository;

        public MyQueueBackgroundService(IAuditLogRepository auditLogRepository, ConcurrentQueue<IAuditLog> myQueue)
        {
            _auditLogRepository = auditLogRepository;
            _myQueue = myQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                Console.WriteLine("MyQueueBackgroundService is starting");
            
                stoppingToken.Register(() =>
                    Console.WriteLine($" MyQueueBackgroundService task is stopping."));

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(500, stoppingToken);

                    if (_myQueue.Any())
                    {
                        _myQueue.TryDequeue(out var log);
                        await _auditLogRepository.SaveAsync(log);
                    }
                }
                
                Console.WriteLine($"MyQueueBackgroundService background task is stopping.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}