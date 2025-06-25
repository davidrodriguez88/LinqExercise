using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum of numbers: {numbers.Sum()}");

            Console.WriteLine();

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average of numbers: {numbers.Average()}");

            Console.WriteLine();

            //TODO: Order numbers in ascending order and print to the console
            var ascendingNumbers = numbers.OrderBy(n => n).ToArray();

            Console.WriteLine("Ascending Numbers");
            Console.WriteLine("------------------");

            foreach (var number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            //TODO: Order numbers in descending order and print to the console
            var descendingNumbers = numbers.OrderByDescending(n => n).ToArray();

            Console.WriteLine("Descending Numbers");
            Console.WriteLine("------------------");

            foreach (var number in descendingNumbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            //TODO: Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(n => n > 6);

            Console.WriteLine("Greater than Six");
            Console.WriteLine("----------------");

            foreach (var number in greaterThanSix)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**

            var evens = numbers
                .Where(n => n % 2 == 0 && n != 0)
                .OrderBy(n => n)
                .Take(4);

            Console.WriteLine("Evens");
            Console.WriteLine("-----");

            foreach (var number in evens)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            numbers[4] = 36;

            var updatedDescending = numbers.OrderByDescending(n => n);

            Console.WriteLine("Descending with age at index 4");
            Console.WriteLine("------------------------------");

            foreach (var number in updatedDescending)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("C & S Names Ascending");
            Console.WriteLine("----------------------");
            var filteredEmployees =
                from e in employees
                where e.FirstName.StartsWith("C") || e.FirstName.StartsWith("S")
                orderby e.FirstName
                select e;

            foreach (var employee in filteredEmployees)
            {
                Console.WriteLine(employee.FullName);
            }

            Console.WriteLine();

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Name & Age");
            Console.WriteLine("----------");
            var agedEmployees = employees
                .Where(e => e.Age > 26)
                .OrderBy(e => e.Age)
                .ThenBy(e => e.FirstName);

            foreach (var employee in agedEmployees)
            {
                Console.WriteLine($"{employee.FullName}, Age: {employee.Age}");
            }

            Console.WriteLine();

            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var yoeSum = employees
                .Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Sum(e => e.YearsOfExperience);

            Console.WriteLine($"Years of Experience Sum: {yoeSum}");
            Console.WriteLine();

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            var avgYoe = employees
                .Where(e => e.YearsOfExperience <= 10 && e.Age > 35)
                .Average(e => e.YearsOfExperience);
            Console.WriteLine($"Average Years of Experience: {avgYoe:F1}");
            
            Console.WriteLine();
            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("David", "Rodriguez", 36, 1)).ToList();
            Console.WriteLine("Employee Added to List End:");
            Console.WriteLine("---------------------------");
            Console.WriteLine(employees.Last().FullName);

            Console.WriteLine();
            Console.ReadLine();
        }
        
        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
