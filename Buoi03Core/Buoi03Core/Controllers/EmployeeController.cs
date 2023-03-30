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
        public IActionResult CreateView(Employee AddEmp, IFormFile fileUploadxx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (fileUploadxx.Length > 0)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUploadxx.FileName);
                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", fileName);
                        var stream = new FileStream(uploadPath, FileMode.Create);
                        fileUploadxx.CopyToAsync(stream);
                        AddEmp.Image = "images/" + fileName;

                    } 
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
        public IActionResult Update(Employee UpdateEmp, IFormFile? fileUploadxx)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var emp_inDb = _empController.GetEmp(UpdateEmp.Id);
                    if (fileUploadxx == null)
                    {
                        UpdateEmp.Image = emp_inDb.Image;
                        _empController.UpdateEmp(UpdateEmp);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(fileUploadxx.FileName);
                        string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot//images", fileName);
                        var stream = new FileStream(uploadPath, FileMode.Create);
                        fileUploadxx.CopyToAsync(stream);
                        UpdateEmp.Image = "images/" + fileName;

                    }
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
