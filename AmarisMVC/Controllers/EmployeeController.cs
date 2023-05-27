using AmarisMVC.LLB;
using AmarisMVC.LLM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AmarisMVC.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (EmployeePrc employeePrc = new EmployeePrc())
            {
                List<EmployeeM> listEmployees = new List<EmployeeM>();
                EmployeeM Model = new EmployeeM();
                listEmployees = await employeePrc.ListAll(Model);

                ViewBag.Employees = listEmployees;
            }
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> Search(EmployeeM employeeM)
        {
            using (EmployeePrc employeePrc = new EmployeePrc())
            {
                List<EmployeeM> listEmployees = new List<EmployeeM>();

                if (employeeM.Id == 0)
                {
                    listEmployees = await employeePrc.ListAll(employeeM);
                }
                else
                {
                    listEmployees = await employeePrc.ListById(employeeM, employeeM.Id);
                }

                ViewBag.Employees = listEmployees;
            }

            return PartialView("_Search");
        }

    }
}