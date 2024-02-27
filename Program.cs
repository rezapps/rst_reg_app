/* 
###########  A console app to register and display restaurnats employees.     ###########
###########  Classes to create in the namespace:                              ###########
###########  1. class Employee to define employee properties                  ###########
###########  2. class EmployeesList to print list of employees in console     ###########
###########  3. class Program which is the entry of program.                  ###########
*/

namespace rst_reg_app
{
    // Employee class has 4 properties Id, Name, Title and Salary
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int Salary { get; set; }
    }

    // Class EmployeesList
    class EmployeesList
    {
        private List<Employee> Employees = new();

        // Register new employee
        public void RegisterNew(string name, string title, int salary)
        {

            int newId = Employees.Count + 1;

            Employee employee = new Employee
            {
                Id = newId,
                Name = name,
                Title = title,
                Salary = salary
            };

            Employees.Add(employee);
        }

        // Display all employees
        public void DisplayAll()
        {
            foreach (var employee in Employees)
            {
                Console.WriteLine($"Name: {employee.Name} \nId: {employee.Id} \nTitle: {employee.Title} \nSalary: {employee.Salary}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            EmployeesList rgstr = GetRgstr();

            rgstr.RegisterNew("John Doe", "Sushi Chief", 50000);

            Console.WriteLine("Please choose one option: \n Type \"list\": to list all employees \n Type \"add\" to start registering new employee");
            string opt = Console.ReadLine() ?? "list";

            // check if user 
            if (opt != "")
            {
                if (opt == "list")
                {
                    rgstr.DisplayAll();
                }
                else if (opt == "add")
                {
                    // taking user info to register
                    // Setting default name and tile
                    Console.WriteLine("Please Enter Name and Lastname: ");
                    string name = Console.ReadLine() ?? "Jane Doe";

                    Console.WriteLine("Please Enter Title: ");
                    string title = Console.ReadLine() ?? "Cook";

                    Console.WriteLine("Please Enter Salary: ");
                    int salary;


                    // Console.ReadLine returns only string
                    // convert string to int
                    if (int.TryParse(Console.ReadLine(), out salary))
                    {
                        rgstr.RegisterNew(name, title, salary);
                    }
                    else
                    {
                        Console.WriteLine("Invalid salary input");
                    }

                    rgstr.DisplayAll();

                }
            }
        }

        // Create an instance of EmployeesList class
        private static EmployeesList GetRgstr()
        {
            return new EmployeesList();
        }
    }
}
