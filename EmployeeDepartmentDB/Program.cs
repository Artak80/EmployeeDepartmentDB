using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDepartmentDB
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeDepartmentDBEntities DB = new EmployeeDepartmentDBEntities();

            var query = from e in DB.Employee
                        join m in DB.Employee on e.HeadDepartmentID equals m.ID
                        join d in DB.Department on e.DepartmentID equals d.ID
                        orderby d.DepartmentName
                        select new
                        {
                            Id = e.ID,
                            FNameEmployee = e.FName,
                            LNameEmployee = e.LName,
                            Age = e.Age,
                            DepartmentName = d.DepartmentName,
                            HeadDepartment = m.LName
                        };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.Id} {item.FNameEmployee} {item.LNameEmployee} {item.Age} { item.DepartmentName} {item.HeadDepartment}");
            }
            Console.ReadKey();

             

        }
    }
}
