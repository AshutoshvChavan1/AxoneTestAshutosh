using AshutoshTest.Data;
using AshutoshTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AshutoshTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            var employees = _dbContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(employee);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _dbContext.Employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(employee);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        private bool EmployeeExists(int id)
        {
            return _dbContext.Employees.Any(e => e.EmployeeId == id);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _dbContext.Employees
                .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
