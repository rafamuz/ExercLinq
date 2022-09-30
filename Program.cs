using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using ExercLinq.Entities;
using System.IO;

namespace ExercLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file path: ");
            string path = Console.ReadLine();
            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Email of people whose salary is more than: " + salary.ToString("F2", CultureInfo.InvariantCulture));
            List<Person> people = new List<Person>();
            using (StreamReader sr = new StreamReader(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(',');
                    string name = line[0];
                    string email = line[1];
                    double salaryLine = double.Parse(line[2], CultureInfo.InvariantCulture);
                    people.Add(new Person() { Name = name, Email = email, Salary = salaryLine });
                }
            }
            Console.WriteLine();
            var result = from p in people where p.Salary > salary orderby p.Email ascending select p;
            foreach(Person p in result)
            {
                Console.WriteLine(p.Email);
            }
            double sum = people.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine();
            Console.WriteLine("Sum of salary whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
