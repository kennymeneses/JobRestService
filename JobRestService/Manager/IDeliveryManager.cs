using JobRestService.Models;

namespace JobRestService.Manager
{
    public interface IDeliveryManager
    {
        Task PublishMessage(Job job);   
    }
}
