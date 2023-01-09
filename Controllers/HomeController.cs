using EmployeeDircetoryMVCApplication.Models;
using EmployeeDircetoryMVCApplication.Providers;
using Microsoft.AspNetCore.Mvc;
using EmployeeDircetoryMVCApplication.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace EmployeeDircetoryMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        EmployeeProvider EmployeeProvider= new EmployeeProvider();
        public HomeController() { }

        [HttpGet]
        public IActionResult Index()
        {
            List<Employee> list = LoadEmployees();
            return View(list);
        }
        private List<Employee> LoadEmployees()
        {
            ViewBag.Search = new Search();
            List<Employee>? employees = new List<Employee>();
            ViewBag.Employeecount = EmployeeProvider.GetCount();
            if (TempData["employees"] == null)
            {
                employees = EmployeeProvider.GetEmployees();
                ViewBag.Employees = EmployeeProvider.GetEmployees();
            }
            else
            {
                employees = JsonSerializer.Deserialize<List<Employee>>(TempData["employees"].ToString());
                ViewBag.Search = new Search()
                {
                    Keyword = TempData["keyword"].ToString(),
                    FilterBy = TempData["value"].ToString(),
                };
            }
            return employees;
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            LoadEmployees();
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee emp)
        {
            Employee employee = new Employee(emp.Id, emp.FirstName, emp.LastName, emp.JobTitle, emp.Office, emp.Department, emp.PhoneNumber, emp.Email);
            EmployeeProvider.AddEmployee(employee);
            return RedirectToAction("");
        }
        public IActionResult EditEmployee(int id)
        {
            LoadEmployees();
            List<Employee> employees = EmployeeProvider.GetEmployees();
            Employee emp = new Employee();
            foreach (Employee employee in employees)
            {
                if (employee.Id == id)
                {
                    emp = employee;
                }
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            Employee edit = new Employee(emp.Id, emp.FirstName, emp.LastName, emp.JobTitle, emp.Office, emp.Department, emp.PhoneNumber, emp.Email);
            EmployeeProvider.EditEmployee(edit);
            return RedirectToAction("");
        }
        [HttpPost]
        public IActionResult Search(string search, string value, string alpha)
        {
            string keyword = "";
            if (search == null)
            {
                keyword = alpha;
                TempData["keyword"] = " ";
            }
            else
            {
                keyword = search;
                TempData["keyword"] = search;
            }

            string filterby = value;
            TempData["employees"] = JsonSerializer.Serialize(EmployeeProvider.Search(keyword, filterby));
            TempData["value"] = value;
            return RedirectToAction("Index", "Home");
        }

    }
}