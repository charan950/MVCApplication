namespace MVCApplication.Models
{
    public class Employee
    {
       
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Jobtitle { get; set; }
        public string Office { get; set; }
        public string Department { get; set; }  
        public string Phonenumber { get; set; }
        public string Email { get; set; }

        public Employee(int Id,string Firstname,string Lastname,string Jobtitle,string Office,string Department,string Phonenumber,string Email)
        { 
            this.Id = Id;
            this.Firstname = Firstname;
            this.Lastname= Lastname;
            this.Jobtitle = Jobtitle;
            this.Office = Office;
            this.Department = Department;
            this.Phonenumber= Phonenumber;
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
