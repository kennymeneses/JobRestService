using Microsoft.WindowsAzure.Storage.Table;

namespace JobRestService.Models
{
    public class IncomingMessage : TableEntity
    {
        public string name { get; set; }
        public int process { get; set; }
        public DateTime? earliestStart { get; set; }
        public DateTime latestStart { get; set; }
        public string arguments { get; set; }

        public IncomingMessage(string _name, int _process, DateTime? _earliestStart, DateTime _latestStart, string _arguments)
        {
            this.PartitionKey = _process.ToString();
            this.RowKey = Guid.NewGuid().ToString();
            name = _name;
            process = _process;
            earliestStart = _earliestStart;
            latestStart = _latestStart;
            arguments = _arguments;            
        }
    }
}
