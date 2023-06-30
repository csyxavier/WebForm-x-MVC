using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApp_MVC.Models;

namespace WebApp_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService service = new EmployeeService();
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            return View(await service.GetEmployeeList());
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee newEmployee)
        {
            try
            {
                if (await service.CreateEmployee(newEmployee))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData[EnumMessage.ErrorMessage.ToString()] = "資料不合法，未成功建立使用者";
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                TempData[EnumMessage.ErrorMessage.ToString()] = "資料不合法，未成功建立使用者";
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var data = await service.QueryEmployee(id);
                if (data == null)
                {
                    TempData[EnumMessage.ErrorMessage.ToString()] = "查無使用者";
                    return RedirectToAction("Index");
                }
                return View(data);
            }
            catch
            {
                TempData[EnumMessage.ErrorMessage.ToString()] = "查無使用者";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Employee employee)
        {
            try
            {
                await service.EditEmployee(employee);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await service.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
