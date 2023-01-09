namespace EmployeeDircetoryMVCApplication.Models
{
    public class Employee
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Employee(int Id, string? Firstname, string? Lastname, string? Jobtitle, string? Office, string? Department, string? Phonenumber, string? Email)
        {
            this.Id = Id;
            FirstName = Firstname;
            LastName = Lastname;
            JobTitle = Jobtitle;
            this.Office = Office;
            this.Department = Department;
            PhoneNumber = Phonenumber;
            this.Email = Email;
        }
        public Employee()
        {

        }
    }
    public enum JobList
    {
        Sharepointhead,
        DotNetDevelopmentLead,
        Recrutingexpert,
        BIDeveloper,
        BussinessAnalyst
    }
    public enum Seatle
    {
        Office,
        India,
    }
    public enum Department
    {
        IT,
        HumanResources,
        MD,
        Sales
    }

}
