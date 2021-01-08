using System;

namespace Question01
{
    class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(2018, 11, 22);
            var tester = new Tester("Alex", date, false);
            tester.ShowInfo();
        }
    }

    class Employee
    {
        internal string name;
        private DateTime hiringDate;

        public Employee(string name, DateTime hiringDate)
        {
            this.name = name;
            this.hiringDate = hiringDate;
        }

        public int Experience()
        {
            var experience = DateTime.Now.Year - hiringDate.Year;
            if (hiringDate.Date > DateTime.Now.AddYears(-experience)) experience--;

            return experience;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"{name} has {Experience()} years of experience");
        }
    }

    class Developer : Employee
    {
        private string programmingLanguage;

        public Developer(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
        {
            this.programmingLanguage = programmingLanguage;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"{name} is {programmingLanguage} programmer");
        }
    }

    class Tester : Employee
    {
        private bool isAuthomation;

        public Tester(string name, DateTime hiringDate, bool isAuthomation) : base(name, hiringDate)
        {
            this.isAuthomation = isAuthomation;
        }

        public override void ShowInfo()
        {
            Console.Write($"{name} is ");
            Console.Write(isAuthomation ? "authomated" : "manual");
            Console.WriteLine($" tester and has {Experience()} year(s) of experience");
        }
    }
}
