using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.Providers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        EmployeeProvider _employeeprovider=new EmployeeProvider();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
           List<Employee> list=LoadEmployees();
            return View(list);
        }
        private List<Employee> LoadEmployees()
        {
            ViewBag.Search = new Search();
            List<Employee> employees = new List<Employee>();
            ViewBag.Employeecount = _employeeprovider.GetCount();
            if (TempData["employees"] == null)
            {
                employees= _employeeprovider.GetEmployees();
                ViewBag.Employees = _employeeprovider.GetEmployees();
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
            Employee employee = new Employee(emp.Id, emp.Firstname, emp.Lastname, emp.Jobtitle, emp.Office, emp.Department, emp.Phonenumber, emp.Email);
            _employeeprovider.AddEmployee(employee);
            return RedirectToAction("");
        }
        public IActionResult EditEmployee(int id)
        {
            LoadEmployees();
            List<Employee> employees = _employeeprovider.GetEmployees();
            Employee emp = new Employee();
            foreach (Employee employee in employees)
            {
                if (employee.Id == id)
                {
                    emp= employee;
                }
            }
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee emp)
        {
            Employee edit = new Employee(emp.Id,emp.Firstname, emp.Lastname, emp.Jobtitle, emp.Office, emp.Department, emp.Phonenumber, emp.Email);
            _employeeprovider.EditEmployee(edit);
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
            TempData["employees"] = JsonSerializer.Serialize(_employeeprovider.Search(keyword, filterby));
            //TempData["keyword"] = keyword;
            TempData["value"] = value;
            return RedirectToAction("Index", "Home");
        }
        
    }
}