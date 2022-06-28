using EmployeeManagement_Api.Models;
using EmployeeManagement_Api.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Harshal", Salary = 40000, Department = "Development" },
                new Employee() { Id = 2, Name = "Suvi", Salary = 25000, Department = "Testing" }
            };
        }

        // Create
        public void CreateEmployee(Employee employee)
        {
            var originalEmployee = GetEmployee(employee.Id);

            if (employee == null || employee.Id == 0 || employee.Name == null)
            {
                throw new System.Exception("Employee is null");
            } 
            else if (originalEmployee != null)
            {
                _employees.ForEach(item =>
                {
                    if(item.Id == employee.Id)
                    {
                        throw new System.Exception("Employee ID is already exists.");
                    }
                });
            }

            _employees.Add(employee);
        }

        // Read
        public Employee GetEmployee(int id)
        {
            return _employees.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        // Update (Create/Update)
        public void UpdateEmployee(Employee employee)
        {
            var originalEmployee = GetEmployee(employee.Id);
            if(originalEmployee != null)
            {
                _employees.ForEach(item =>
                {
                    if(item.Id == employee.Id)
                    {
                        item.Name = employee.Name;
                        item.Salary = employee.Salary;
                        item.Department = employee.Department;
                    }
                });
            } 
            else
            {
                _employees.Add(employee);
            }
        }

        // Delete
        public bool DeleteEmployee(int id)
        {
            _employees = _employees.Where(x => x.Id != id).ToList();
            return true;
        }
    }
}
