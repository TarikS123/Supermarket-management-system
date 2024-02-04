namespace SupermarketMS
{
    public class Employee
    {
       
            public int EmployeeID { get; }
            private static int currid = 0;
            public string FirstName { get; set; }
            public string LastName { get; set; }
            private string Email { get; set; }
            private string PhoneNumber { get; set; }
            private string Address { get; set; }
            private double Salary { get; set; }
            public DateTime HireDate { get; set; }
            public string Role { get; set; }
            
            public string Department {  get; set; }

            
            public Employee(string firstName, string lastName, string email, string phoneNumber, string address, double salary, DateTime hireDate, string role, string department)
            {
                EmployeeID = currid++;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                PhoneNumber = phoneNumber;
                Address = address;
                Salary = salary;
                HireDate = hireDate;
                Role = role;
                Department = department;
                
            }
    }

    public class Manager : Employee  // predstavlja menadzera koji moze zaposljavati, davati otkaz, davati zadatke i voditi evidenciju o uposlenicima
    {

       
        public Manager( string firstName, string lastName, string email, string phoneNumber, string address, double salary, DateTime hireDate, string department)
            : base(firstName, lastName, email, phoneNumber, address, salary, hireDate, $"Manager of {department}", department)
        {
            Department = department;
        }

        public void AddCleaningTask(string CleaningDescription)
        {
            CleanJobSingleton.Instance.AddCleaningJob(new DirtyDepartment(this.Department, CleaningDescription)); // menadzer vodi evidenciju o cistoci svom deparmentu
        }

        public void Hire(Employee emp)
        {
            EmployeeSingleton.Instance.AddEmployee(emp);
        }

        public void FireByNameAndSurname(string name, string surname)
        {
            EmployeeSingleton.Instance.RemoveEmployeeByNameAndSurname(name,surname);
        }
        public void FireById (int id)
        {
            EmployeeSingleton.Instance.RemoveEmployeeById(id);
        }

        public void GetAllEmployees()
        {
            EmployeeSingleton.Instance.GetAllEmployees();
        }

        public List<Employee> GetEmployeesFromParticularDepartment(string department)
        {
            List<Employee> returnList= new List<Employee>();
            List<Employee> employees = EmployeeSingleton.Instance.GetAllEmployees();
            foreach (Employee employee in employees)
            {
                if (employee.Department.Equals(department))returnList.Add(employee);
            }
            return returnList;
        }

        public List<Employee> GetEmployeesFromManagerDepartment(string department)
        {
          return  GetEmployeesFromParticularDepartment(this.Department);
        }
    }

    public class Cashier : Employee
    {
        
        private int CashRegisterNo {  get; set; }

        public Cashier(string firstName, string lastName, string email, string phoneNumber, string address, double salary, DateTime hireDate, string department, int cashRegisterNo)
            : base(firstName, lastName, email, phoneNumber, address, salary, hireDate, $"Cashier working on {cashRegisterNo} cash register", department)
        {
            
            CashRegisterNo = cashRegisterNo;
        }
    }


    public class Replenisher : Employee   // predstavlja radnike koji pune police 
    {
       
        
        public Replenisher(string firstName, string lastName, string email, string phoneNumber, string address, double salary, DateTime hireDate, string department)
            : base(firstName, lastName, email, phoneNumber, address, salary, hireDate, $"Replenisher of {department}", department)
        {
            Department = department;
            
        }

        public void Replenish() { }   // nisam napravio singleton koji predstavlja police, ova metoda bi samo dodala kvantitet na police

    }

    public class Cleaner : Employee   
    {

        public int jobsDone;

        public Cleaner(string firstName, string lastName, string email, string phoneNumber, string address, double salary, DateTime hireDate, string department)
            : base(firstName, lastName, email, phoneNumber, address, salary, hireDate, $"Cleaner of {department}", department)
        {
            jobsDone = 0; // vodi evidenciju o koliko je uposlenik posla uradio
        }

        public void Clean() { CleanJobSingleton.Instance.CleanDepartment(this.Department); jobsDone++; }   // garantuje da higijenicari odrzavaju samo svoje departmente

    }



}