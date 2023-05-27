using AmarisMVC.LLM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmarisMVC.LDA
{
    public class EmployeeBD : IDisposable
    {
        public EmployeeBD() { }
        public void Dispose() { }

        //make the request GET of the list employees
        public async Task<List<EmployeeM>> RequestListEmployees(string url)
        {
            var json = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                var Response = await httpClient.GetAsync(url);

                if (Response.IsSuccessStatusCode)
                {
                    json = await Response.Content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<List<EmployeeM>>(json);
            }
        }

        //make the request GET of the list employees by id 
        public async Task<EmployeeM> RequestEmployeeID(string url, string Id)
        {
            var json = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                var Response = await httpClient.GetAsync(url + Id);

                if (Response.IsSuccessStatusCode)
                {
                    json = await Response.Content.ReadAsStringAsync();
                }

                return JsonConvert.DeserializeObject<EmployeeM>(json);
            }
        }

        //url access API
        public static string ReadAppSetting(string Key)
        {
            string value = System.Configuration.ConfigurationManager.AppSettings[Key];
            return value;
        }
    }
}
