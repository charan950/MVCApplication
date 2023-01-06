namespace MVCApplication.Models
{
    public class EmployeeCount
    {
        public int It { get; set; }
        public int Hr { get; set; }
        public int Md { get; set; }
        public int Sales { get; set; }
        public int Office { get; set; }
      
        public int India { get; set; }
        public int Sharepoint { get; set; }

        public int Dotnet { get; set; }
        public int RecruitingExpert { get; set; }
        public int BIDevelopers { get; set; }
        public int BA { get; set; }

        public EmployeeCount()
        {

        }
        public EmployeeCount(int it, int hr, int md, int sales, int office, int india, int sharepoint, int dotnet, int recruitingExpert, int bIDevelopers, int bA)
        {
            It = it;
            Hr = hr;
            Md = md;
            Sales = sales;
            Office = office;
            this.India = india;
            this.Sharepoint = sharepoint;
            Dotnet = dotnet;
            RecruitingExpert = recruitingExpert;
            BIDevelopers = bIDevelopers;
            BA = bA;
        }
    }
}
