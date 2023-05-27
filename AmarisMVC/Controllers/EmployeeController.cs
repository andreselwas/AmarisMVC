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
                List<Data> listEmployees = new List<Data>();
                Data Model = new Data();
                listEmployees = await employeePrc.ListAll(Model);

                ViewBag.Employees = listEmployees;
            }
            return View();
        }

        [HttpGet]
        public async Task<PartialViewResult> Search(Data employeeM)
        {
            using (EmployeePrc employeePrc = new EmployeePrc())
            {
                List<Data> listEmployees = new List<Data>();
                Data listEmployee = new Data();

                if (employeeM.id == 0)
                {
                    listEmployees = await employeePrc.ListAll(employeeM);

                    ViewBag.Employees = listEmployees;
                }
                else
                {
                    listEmployee = await employeePrc.ListById(employeeM, employeeM.id);

                    ViewBag.Employees = listEmployee;
                }

                
            }

            return PartialView("_Search");
        }

    }
}