using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace z8
{
    class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public decimal Zp { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<Employee> employees = new Queue<Employee>();
            string[] lines = File.ReadAllLines("1.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                Employee employee = new Employee
                {
                    LastName = parts[0],
                    FirstName = parts[1],
                    MiddleName = parts[2],
                    Gender = parts[3],
                    Age = int.Parse(parts[4]),
                    Zp = decimal.Parse(parts[5])
                };
                employees.Enqueue(employee);
            }
            var employeesUnder30 = employees.Where(e => e.Age < 30);
            WriteLine("Сотрудники младше 30:");
            foreach (var employee in employeesUnder30)
            {
               WriteLine($"{employee.LastName}, {employee.FirstName}, {employee.MiddleName}, {employee.Gender}, {employee.Age}, {employee.Zp}");
            }
            WriteLine("Все сотрудники:");
            foreach (var employee in employees)
            {
                WriteLine($"{employee.LastName}, {employee.FirstName}, {employee.MiddleName}, {employee.Gender}, {employee.Age}, {employee.Zp}");
            }
            ReadKey();
        }
    }
}
