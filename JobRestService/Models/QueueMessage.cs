namespace JobRestService.Models
{
    public class QueueMessage
    {
        public string processName { get; set; }
        public int processNumber { get; set; }
        public DateTime? earliestStart { get; set; }
        public DateTime latestStart { get; set; }
        public List<Argument> arguments { get; set; }
        public string JobId { get; set; }

        public QueueMessage(string _processName, int _processNumber, DateTime _earliestStart, DateTime _latestStart, List<Argument> _arguments, string _jobId)
        {
            arguments = new List<Argument>();

            processName = _processName;
            processNumber = _processNumber;
            earliestStart = _earliestStart;
            latestStart = _latestStart;
            arguments = _arguments;
            JobId = _jobId;
        }
    }
}
