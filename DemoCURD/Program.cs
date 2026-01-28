using DemoCURD.Data;
using DemoCURD.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DemoCURD
{
    public class Program
    {
        
       
       
        static void Main(string[] args)
        {
            Console.WriteLine("=== EMPLOYEE MANAGEMENT SYSTEM ===");
            AllEmployeeOperations();
        }
        public static void AllEmployeeOperations()
        {
            while (true)
            {
                Console.WriteLine("\n" + new string('=', 50));
                Console.WriteLine("Choose Operation:");
                Console.WriteLine("1. View All Employees");
                Console.WriteLine("2. View Employee by ID");
                Console.WriteLine("3. Add New Employee");
                Console.WriteLine("4. Update Employee");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. View Employees by Age>30:");
                Console.WriteLine("7. Export Employee Details To CSV");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice (0-5): ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        EmployeeManagement.ViewAllEmployees();
                        break;
                    case 2:
                       EmployeeManagement.ViewEmployeeById();
                        break;
                    case 3:
                       EmployeeManagement.AddNewEmployee();
                        break;
                    case 4:
                      EmployeeManagement.UpdateEmployee();
                        break;
                    case 5:
                        EmployeeManagement.DeleteEmployee();
                        break;
                    case 6:
                        EmployeeManagement.LinqOperations();
                        break;
                    case 7:
                        EmployeeManagement.ExportToCSV();
                        break;
                    case 0:
                        Console.WriteLine("Thank you for using Employee Management System!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }

        }
        
    }
}

