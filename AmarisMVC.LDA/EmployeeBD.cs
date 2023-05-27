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
        public async Task<List<Data>> RequestListEmployees(string url)
        {
            var json = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                var Response = await httpClient.GetAsync(url);

                if (Response.IsSuccessStatusCode)
                {
                    json = await Response.Content.ReadAsStringAsync();
                }

                var result = JsonConvert.DeserializeObject<ResultAll>(json);

                return result.data;
            }
        }

        //make the request GET of the list employees by id 
        public async Task<Data> RequestEmployeeID(string url, decimal Id)
        {
            var json = string.Empty;

            using (HttpClient httpClient = new HttpClient())
            {
                var Response = await httpClient.GetAsync(url + Id.ToString());

                if (Response.IsSuccessStatusCode)
                {
                    json = await Response.Content.ReadAsStringAsync();
                }

                var result = JsonConvert.DeserializeObject<ResultId>(json);

                return result.data;
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
