using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCApplication.Models;
using System.Data;
using System.Data.SqlClient;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MVCApplication.Providers
{
    public class EmployeeProvider:PageModel
    {
        static string connectionstring = "data source =.; Initial Catalog = Employees; Integrated Security = SSPI;";
        string Filterby = "firstname";
        string alpha = "";
        public string SidebarValue = "";
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionstring);
            SqlCommand cm = new SqlCommand("Select * from Employees", con);
            con.Open();  
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                employees.Add(new Employee((int)sdr["id"],sdr["firstname"].ToString(), sdr["lastname"].ToString(), sdr["jobtitle"].ToString(),
                 sdr["office"].ToString(), sdr["department"].ToString(), sdr["phonenumber"].ToString() , sdr["email"].ToString()));
            }
            return employees;
        }
        public void EditEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "update Employees set firstname=@firstname,lastname=@lastname,jobtitle=@jobtitle,office=@office,department=@department,phonenumber=@phonenumber,email=@email where id=@id";
            string str = $"Update Employees SET firstname='{employee.Firstname}',lastname='{employee.Lastname}',jobtitle='{employee.Jobtitle}'," +
                $"office='{employee.Office}',department='{ employee.Department}',phonenumber='{ employee.Phonenumber}',email='{ employee.Email}' Where Id='{employee.Id}'";
            SqlCommand command = new SqlCommand(str, connection);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Employee Added Successfully");
            connection.Close();
        }
        public void AddEmployee(Employee employee)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            string query = "insert into Employees(firstname,lastname,jobtitle,office,department,phonenumber,email) values(@firstname,@lastname,@jobtitle,@office,@department,@phonenumber,@email)";
            SqlCommand command = new SqlCommand(query, connection);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@firstname",employee.Firstname);
            command.Parameters.AddWithValue("@lastname", employee.Lastname);
            command.Parameters.AddWithValue("@jobtitle", employee.Jobtitle);
            command.Parameters.AddWithValue("@office", employee.Office);
            command.Parameters.AddWithValue("@department", employee.Department);
            command.Parameters.AddWithValue("@phonenumber", employee.Phonenumber);
            command.Parameters.AddWithValue("@email", employee.Email);
            connection.Open();
            command.ExecuteNonQuery();
            Console.WriteLine("Employee Added Successfully");
            connection.Close();
        }
        public List<Employee> Search(string keyword,string FilterBy)
        {
            var employees = new List<Employee>();
            SqlConnection con = new SqlConnection(connectionstring);
            string query = "Select * from Employees where " + FilterBy.ToLower()+" like '" + (keyword.ToLower()) + "%'";
            SqlCommand cm = new SqlCommand(query, con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                employees.Add(new Employee((int)sdr["id"], sdr["firstname"].ToString(), sdr["lastname"].ToString(), sdr["jobtitle"].ToString(),
                    sdr["office"].ToString(), sdr["department"].ToString(), sdr["phonenumber"].ToString(), sdr["email"].ToString()));
            }
            return employees;
        }
        public EmployeeCount GetCount()
        {
            var emp = GetEmployees();
            EmployeeCount employeecpount = new EmployeeCount(0,0,0,0,0,0,0,0,0,0,0);
            for(int i=0;i<emp.Count;i++)
            {
                if (emp[i].Jobtitle.ToLower().Contains(JobList.Sharepointhead.ToString().ToLower()))
                {
                    employeecpount.Sharepoint++;
                }
                if (emp[i].Jobtitle.ToLower().Contains(JobList.DotNetDevelopmentLead.ToString().ToLower()))
                {
                    employeecpount.Dotnet++;
                }
                if (emp[i].Jobtitle.ToLower().Contains(JobList.BussinessAnalyst.ToString().ToLower()))
                {
                    employeecpount.BA++;
                }
                if (emp[i].Jobtitle.ToLower().Contains(JobList.Recrutingexpert.ToString().ToLower()))
                {
                    employeecpount.RecruitingExpert++;
                }
                if (emp[i].Jobtitle.ToLower().Contains(JobList.BIDeveloper.ToString().ToLower()))
                {
                    employeecpount.BIDevelopers++;
                }
                if (emp[i].Department.ToLower().Contains(Department.Sales.ToString().ToLower()))
                {
                    employeecpount.Sales++;
                }
                if (emp[i].Department.ToLower().Contains(Department.IT.ToString().ToLower()))
                {
                    employeecpount.It++;
                }
                if (emp[i].Department.ToLower().Contains(Department.HumanResources.ToString().ToLower()))
                {
                    employeecpount.Hr++;
                }
                if (emp[i].Department.ToLower().Contains(Department.MD.ToString().ToLower()))
                {
                    employeecpount.Md++;
                }
                if (emp[i].Office.ToLower().Contains(Seatle.Office.ToString().ToLower()))
                {
                    employeecpount.Office++;
                }
                if (emp[i].Office.ToLower().Contains(Seatle.India.ToString().ToLower()))
                {
                    employeecpount.India++;
                }
            }
            return employeecpount;
        }
       
        //public List<Employee>  SideFilter(string search)
        //{
            
        //    this.SideBarValue(search);
        //    var employees = new List<Employee>();
        //    string filterby = search;
        //    SqlConnection con = new SqlConnection(connectionstring);
        //    string query = "Select * from Employees where department like '" + (filterby.ToLower()) + "%'" + " OR jobtitle  like '" + (filterby.ToLower()) + "%'" + " or office like '" + (filterby.ToLower()) + "%'";
        //    SqlCommand cm = new SqlCommand(query, con);
        //    DataSet dataset = new DataSet();
        //    con.Open();
        //    SqlDataReader sdr = cm.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        employees.Add(new Employee((int)sdr["id"], sdr["firstname"].ToString(), sdr["lastname"].ToString(), sdr["jobtitle"].ToString(),
        //            sdr["office"].ToString(), sdr["department"].ToString(), sdr["phonenumber"].ToString(), sdr["email"].ToString()));
        //    }
        //    return employees;
        //}
        //public void SideBarValue(string search)
        //{
        //    this.SidebarValue = search;
        //}
        //public string GetSideBarValue()
        //{
        //    return this.SidebarValue;
        //}
    }
}
