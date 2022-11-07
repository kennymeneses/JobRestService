namespace JobRestService.ServiceBus
{
    public interface IServiceBusQueue
    {
        Task SendMessageAsync(string serviceBusMessage);
    }
}
