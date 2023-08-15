using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppTest1.Models;

namespace WebAppTest1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> list = Employee.SelectAllEmployees();
            return View(list);
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            Employee emp = Employee.GetEmpById(id);
            return View(emp);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
<<<<<<< HEAD
            List<SelectListItem> deptList = new List<SelectListItem>();
            foreach (Department d in Department.GetAllDepartments())
            {
                deptList.Add(new SelectListItem() { Text= d.DeptName, Value=d.DeptName });
            }
            ViewBag.Departments = deptList;
            return View();
=======
            Employee e= new Employee();
            return View(e);
>>>>>>> e11eed36996b8195472e933c14bc30d188dc546d
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                Employee.AddEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Employee.GetEmpById(id));
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                Employee.UpdateEmployee(emp);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
                return View(Employee.GetEmpById(id));       
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.DeleteEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
