using System.Collections.Generic;

namespace AmarisMVC.LLM
{
    public class Data
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public int employee_salary { get; set; }
        public int employee_age { get; set; }
        public string profile_image { get; set; }
    }

    public class ResultAll
    {
        public string status { get; set; }
        public List<Data> data { get; set; }
        public string message { get; set; }
    }

    public class ResultId
    {
        public string status { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}
