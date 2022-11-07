namespace JobRestService.ServiceBus
{
    public class ServiceBusQueue : IServiceBusQueue
    {
        private readonly IConfiguration _configuration;

        public ServiceBusQueue(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendMessageAsync(string serviceBusMessage)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            throw new NotImplementedException();
        }
    }
}
