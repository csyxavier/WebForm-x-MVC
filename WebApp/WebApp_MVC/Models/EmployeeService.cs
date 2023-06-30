using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApp_MVC.Models
{
    public class EmployeeService : DbContextBase
    {
        public async Task<List<Employee>> GetEmployeeList()
        {
            return await dbEntities.Employee.ToListAsync();
        }
        public async Task<Employee> QueryEmployee(int PK)
        {
            return await dbEntities.Employee.Where(x => x.PK == PK).FirstOrDefaultAsync();
        }
        public async Task<Employee> DeleteEmployee(int PK)
        {
            var deletedEmployee = dbEntities.Employee.Remove(await QueryEmployee(PK));
            await dbEntities.SaveChangesAsync();
            return deletedEmployee;
        }
        public async Task<Employee> EditEmployee(Employee employee)
        {
            Employee targetEmployee = await QueryEmployee(employee.PK);
            targetEmployee.Name = employee.Name;
            targetEmployee.Birthday = employee.Birthday;
            targetEmployee.Age = employee.Age;
            if(await dbEntities.SaveChangesAsync() > 0)
            {
                return targetEmployee;
            }
            else
            {
                return employee;
            }
        }
        public async Task<bool> CreateEmployee(Employee newEmployee)
        {
            try
            {
                if (newEmployee != null && newEmployee.Name != null && int.TryParse(Convert.ToString(newEmployee.Age), out _) && DateTime.TryParse(Convert.ToString(newEmployee.Birthday), out var birthday) && birthday.Date <= DateTime.Now.Date)
                {
                    dbEntities.Employee.Add(new Employee() { Name = newEmployee.Name, Age = DateTime.Now.Year - newEmployee.Birthday.Year, Birthday = newEmployee.Birthday.Date });
                    return await dbEntities.SaveChangesAsync() > 0 ? true : false;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }

        }
    }
}