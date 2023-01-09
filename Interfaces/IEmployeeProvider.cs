using EmployeeDircetoryMVCApplication.Models;

namespace EmployeeDircetoryMVCApplication.Interfaces
{
    public interface IEmployeeProvider
    {
        public List<Employee> GetEmployees();
        public void EditEmployee(Employee employee);
        public void AddEmployee(Employee employee);
        public List<Employee> Search(string keyword, string FilterBy);
        public EmployeeCount GetCount();


    }
}
