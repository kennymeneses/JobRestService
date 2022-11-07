using JobRestService.Models;

namespace JobRestService.Manager
{
    public interface IJobManager
    {
        Task<IncomingMessage> StoreMessage(Job job);

        Task PublishMessage(Job job);

    }
}
