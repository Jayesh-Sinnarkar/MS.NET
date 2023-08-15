using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;

namespace ModelBinding.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController
        public ActionResult Index()
        {
            List<Employee> lstEmps = new List<Employee>();
            lstEmps.Add(new Employee { EmpNo = 1, Name = "Ambar", Basic = 12345, DeptNo = 10 });
            lstEmps.Add(new Employee { EmpNo = 2, Name = "Muskaan", Basic = 22345, DeptNo = 20 });
            lstEmps.Add(new Employee { EmpNo = 3, Name = "Pradeep", Basic = 32345, DeptNo = 30 });

            return View(lstEmps);

            //List<Employee> list = Employee.GetAllEmployees();
            //return View(list);

        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id=0)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;
            //return View();
            return View(obj);

            //Employee obj = Employee.GetSingleEmployee(id);
            //return View(obj);
        }

        // GET: EmployeesController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        #region IFormCollection code
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        string name = collection["Name"];
        //        string empno = collection["EmpNo"];
        //        string basic = collection["Basic"];
        //        string deptno = collection["DeptNo"];
        //        //return RedirectToAction(nameof(Index));
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion
        public ActionResult Create(Employee obj)
        {
            try
            {
               
                //return RedirectToAction(nameof(Index));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;
            //return View();
            return View(obj);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee obj)
        {
            try
            {
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
            Employee obj = new Employee();
            obj.EmpNo = id;
            obj.Name = "Vikram";
            obj.Basic = 12345;
            obj.DeptNo = 10;
            //return View();
            return View(obj);
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee obj)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
