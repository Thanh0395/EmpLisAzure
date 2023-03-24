using Buoi03Core.Models;
using Buoi03Core.Respository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buoi03Core.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _empController;
        public EmployeeController(IEmployeeRepository employeeRepository) { 
            _empController = employeeRepository;
        }
        //private IEmployeeRepository _employeeController;
        public IActionResult Index(string name)
        {
            var result = _empController.GetAllEmp();
            if (string.IsNullOrEmpty(name))
            {
                return View(result);
            } else { 
                var list = result.Where(e=>e.EmployeeName.ToLower().Contains(name.ToLower()));
                return View(list);
            }
        }
        public IActionResult Delete(int id) {
            _empController.DeleteEmp(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CreateView() {
            return View();
        }

        [HttpPost]
        public IActionResult CreateView(Employee AddEmp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empController.AddEmp(AddEmp);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var emp = _empController.GetEmp(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Update(Employee UpdateEmp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empController.UpdateEmp(UpdateEmp);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
            }
            return View();
        }
    }
}
