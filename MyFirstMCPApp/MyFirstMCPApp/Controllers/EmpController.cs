using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstMCPApp.Models;

namespace MyFirstMCPApp.Controllers
{
    public class EmpController : Controller
    {
        // GET: EmpController
        public ActionResult Index()
        {
            List<Employee> emplist=EmpDbRepository.GetEmpList();
            return View(emplist);
        }

        // GET: EmpController/Details/5
        public ActionResult Details(int id)
        {
            if (id <= 0)
            {
                    return RedirectToAction("Index");
            }
            Employee employee=EmpDbRepository.GetEmpById(id);
            return View(employee);

        }

        // GET: EmpController/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: EmpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection,Employee pemployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpDbRepository.AddNewEmp(pemployee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id <= 0)

            {

                return RedirectToAction("Index");

            }

            Employee employee = EmpDbRepository.GetEmpById(id);

            return View(employee);
        }

        // POST: EmpController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Employee pemployee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpDbRepository.UpdateEmployee(pemployee);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpController/Delete/5
        public ActionResult Delete(int id)
        {
            if(id<=0)
            {
                return RedirectToActionPermanent("Index");
            }
            Employee employee = EmpDbRepository.GetEmpById(id);
            return View(employee);
        }

        // POST: EmpController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    EmpDbRepository.DeleteEmployee(id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
