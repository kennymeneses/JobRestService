using Azure.Messaging.ServiceBus;
using JobRestService.Models;

namespace JobRestService.Manager
{
    public class DeliveryManager : IDeliveryManager
    {
        private readonly IConfiguration _configuration;

        public DeliveryManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task PublishMessage(Job job)
        {
            string queueName = _configuration["ServiceBus:QueueName"];
            string connectionString = _configuration["ServiceBus:ConnectionString"];

    //        var serviceBusClient = new ServiceBusClient(connectionString,
    //new ServiceBusClientOptions() { TransportType = ServiceBusTransportType.AmqpWebSockets });

            var serviceBusClient = new ServiceBusClient(connectionString);

            ServiceBusSender serviceBusSender = serviceBusClient.CreateSender(queueName);

            throw new NotImplementedException();
        }
    }
}
