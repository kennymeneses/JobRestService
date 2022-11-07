namespace JobRestService.Models
{
    public class Job
    {
        public string name { get; set; }
        public int process { get; set; }
        public DateTime? earliestStart { get; set; }
        public DateTime latestStart { get; set; }
        public List<Argument> arguments { get; set; }

        public Job()
        {
            arguments = new List<Argument>();
        }
    }

    public class Argument
    {
        public string name { get; set; }
        public string value { get; set; }
        public string type { get; set; }
    }
}
