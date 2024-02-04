using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ManagerClass")]

namespace SupermarketMS
{
    public class EmployeeSingleton   // klasa koju koristimo za cuvanje podataka o uposlenicima na jednom mjestu
    {
        private static EmployeeSingleton instance;
        private List<Employee> employees;

        private EmployeeSingleton()
        {
            employees = new List<Employee>();
            
        }

        public static EmployeeSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeSingleton();
                }
                return instance;
            }
        }

        internal Employee GetEmployeebyNameAndSurname(string name, string surname)
        {   
            Employee returnEmployee = null;
            foreach (Employee employee in employees)
            {
                if (employee.FirstName == name && employee.LastName.Equals(surname))
                    returnEmployee=employee;
            }
            return returnEmployee;
        }
         // obzirom da cuvam uposlenike sortirane po id-u, iskoristio sam binary searhch za njihovo brzo trazenje po id-u
        internal Employee GetEmployeeById(int employeeId)
        {
            
            int low = 0;
            int high = employees.Count - 1;

            while (low <= high)
            {
                int mid = (low + high) / 2;
                Employee midEmployee = employees[mid];

                if (midEmployee.EmployeeID == employeeId)
                {
                    return midEmployee; 
                }
                else if (midEmployee.EmployeeID < employeeId)
                {
                    low = mid + 1; 
                }
                else
                {
                    high = mid - 1; 
                }
            }

            return null; 
        }

        internal void RemoveEmployeeById(int employeeId)  
        {
            RemoveEmployee(GetEmployeeById(employeeId)); // iskoristio funkciju opet 
        }

        internal void RemoveEmployeeByNameAndSurname(string employeeName, string surname)
        {
            RemoveEmployee(GetEmployeebyNameAndSurname(employeeName, surname));
        }

        internal void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }
        private void RemoveEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
    }

}