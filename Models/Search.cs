using Microsoft.AspNetCore.Components.Forms;

namespace EmployeeDircetoryMVCApplication.Models
{
    public class Search
    {
        public string? Keyword { get; set; }
        public string Alpha { get; set; }
        public string? FilterBy { get; set; }

    }
    public enum Dropdown
    {
        Firstname,
        Lastname,
        Jobtitle,
        Department
    }
}
