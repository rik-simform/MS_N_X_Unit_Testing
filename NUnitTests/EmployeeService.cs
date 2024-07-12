using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    public class EmployeeService
    {
        private readonly List<Employee> Employees;

        public EmployeeService()
        {
            Employees = new List<Employee>();
        }

        public EmployeeService(List<Employee> EmployeeList)
        {
            Employees = EmployeeList;
        }

        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await Task.FromResult(GetAllEmployees());
        }

        public Employee GetEmployeeById(int id)
        {
            var Employee = Employees.FirstOrDefault(p => p.Id == id);
            if (Employee == null)
            {
                return null;
            }
            return Employee;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await Task.FromResult(GetEmployeeById(id));
        }
    }
}
