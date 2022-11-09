using Azure.Messaging.ServiceBus;
using JobRestService.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Text.Json;

namespace JobRestService.Manager
{
    public class JobManager : IJobManager
    {
        IConfiguration configuration;
        private readonly string TableStorageConnectionString;
        private readonly string tableName;
        private readonly string ServiceBusConnectionString;
        private readonly string queueName;
        string jobid;

        public JobManager(IConfiguration _configuration)
        {
            configuration = _configuration;

            TableStorageConnectionString = configuration["AzureTableStorage:ConnectionString"];
            tableName = configuration["AzureTableStorage:TableName"];

            ServiceBusConnectionString = configuration["ServiceBus:ConnectionString"];
            queueName = configuration["ServiceBus:QueueName"];

            jobid = Guid.NewGuid().ToString();
        }

        public async Task<IncomingMessage> StoreMessage(Job job)
        {
            // Todo: convert job arguments in a string type 
            try
            {
                

                var incomingMsg = new IncomingMessage(job.name, 
                                                      job.process,
                                                      job.earliestStart,
                                                      job.latestStart,
                                                      "");

                incomingMsg.RowKey = jobid;

                var storageAccount = CloudStorageAccount.Parse(TableStorageConnectionString);
                var tableClient = storageAccount.CreateCloudTableClient();
                var table = tableClient.GetTableReference(tableName);
                
                await table.ExecuteAsync(TableOperation.Insert(incomingMsg));

                return incomingMsg;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }

        public async Task PublishMessage(Job job)
        {
            try
            {
                DateTime earliestStart = DateTime.Now;

                DateTime latestStart = DateTime.Now.AddMinutes(6);
                
                var serviceBusClient = new ServiceBusClient(ServiceBusConnectionString);
                var queueMessage = new QueueMessage(job.name, job.process, earliestStart, latestStart, job.arguments, jobid);

                ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);
                string serviceBusMessage = JsonSerializer.Serialize(queueMessage);
                await serviceBusSender.SendMessageAsync(new ServiceBusMessage(serviceBusMessage));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
