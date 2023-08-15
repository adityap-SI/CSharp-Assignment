namespace Employee_Management
{
    abstract class Employee
    {
        public string Name { get; }
        public string EmployeeID { get; }
        public double Salary { get; }

        public Employee(string name, string employeeID, double salary)
        {
            Name = name;
            EmployeeID = employeeID;
            Salary = salary;
        }

        public abstract double CalculateBonus();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Employee ID: {EmployeeID}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }

    class Manager : Employee
    {
        public Manager(string name, string employeeID, double salary)
            : base(name, employeeID, salary)
        {
        }

        public override double CalculateBonus()
        {
            // Managers get a bonus of 20% of their salary
            return Salary * 0.2;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {CalculateBonus()}");
        }
    }

    class Developer : Employee
    {
        public Developer(string name, string employeeID, double salary)
            : base(name, employeeID, salary)
        {
        }

        public override double CalculateBonus()
        {
            // Developers get a bonus of 15% of their salary
            return Salary * 0.15;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {CalculateBonus()}");
        }
    }

    class SalesPerson : Employee
    {
        public SalesPerson(string name, string employeeID, double salary)
            : base(name, employeeID, salary)
        {
        }

        public override double CalculateBonus()
        {
            // Salespersons get a bonus of 10% of their salary
            return Salary * 0.10;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {CalculateBonus()}");
        }
    }

    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Aditya", "1", 50000);
            Developer developer = new Developer("Shruti", "1", 60000);
            SalesPerson salesPerson = new SalesPerson("Dhruv", "1", 45000);

            Console.WriteLine("Manager Details:");
            manager.DisplayDetails();
            Console.WriteLine();

            Console.WriteLine("Developer Details:");
            developer.DisplayDetails();
            Console.WriteLine();

            Console.WriteLine("SalesPerson Details:");
            salesPerson.DisplayDetails();
            Console.WriteLine();
        }
    }

}
