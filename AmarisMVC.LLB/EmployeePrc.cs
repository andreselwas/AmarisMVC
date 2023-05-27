using AmarisMVC.LDA;
using AmarisMVC.LLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmarisMVC.LLB
{
    public class EmployeePrc : IDisposable
    {
        public EmployeePrc() { }

        public void Dispose() { }
        public async Task<List<Data>> ListAll(Data Model)
        {
            string searchall = string.Empty;
            List<Data> model = null;

            searchall = EmployeeBD.ReadAppSetting("APIUrlAll");

            using (EmployeeBD employeeBD = new EmployeeBD())
            {
                model = await employeeBD.RequestListEmployees(searchall);
            }

            return model;
        }

        public async Task<Data> ListById(Data Model, decimal Id)
        {
            string searchId = string.Empty;
            Data model = null;

            searchId = EmployeeBD.ReadAppSetting("APIUrlId");

            using (EmployeeBD employeeBD = new EmployeeBD())
            {
                model = await employeeBD.RequestEmployeeID(searchId, Id);
            }

            return model;
        }

        public static decimal CalculateEmployeeAnualSalary(decimal employeeSalary)
        {
            decimal AnualSalary = employeeSalary * 12;

            return AnualSalary;
        }
    }
}
