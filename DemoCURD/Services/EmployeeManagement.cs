using DemoCURD.Data;
using DemoCURD.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoCURD.Services
{
    public  class EmployeeManagement
    {
        static EmployeeService employeeService = new EmployeeService();
        public static void ViewAllEmployees()
        {
            Console.WriteLine(".....ALL EMPLOYEE DETAILS.....");
            DataTable dt = employeeService.GetAllEmployee();
            Console.WriteLine("ID\tName\t\t\tGender\tAge\tEmail\t\tDeptID\tDesigID");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["EmployeeID"]}\t " +
                    $"{row["EmpName"]}\t\t\t" +
                        $"{row["Gender"]}\t" +
                        $"{row["Age"]}\t" +
                        $"{row["Email"]}\t\t" +
                        $"{row["DepartmentID"]}\t" +
                        $"{row["DesignationID"]}");
            }

            Console.WriteLine($"\nTotal employees: {dt.Rows.Count}");

        }

        public static void ViewEmployeeById()
        {
            Console.WriteLine("ENTER EMPLOYEE ID: ");
            int id = int.Parse(Console.ReadLine());
            DataTable dt = employeeService.GetEmployeeById(id);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["EmployeeID"]}\t " +
                    $"{row["EmpName"]}\t\t" +
                        $"{row["Gender"]}\t" +
                        $"{row["Age"]}\t" +
                        $"{row["Email"]}\t\t" +
                        $"{row["DepartmentID"]}\t" +
                        $"{row["DesignationID"]}");
            }
        }

        public static void AddNewEmployee()
        {
            //int Empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Employee Name: ");
            string EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Gender: ");
            string Gender = Console.ReadLine();
            Console.WriteLine("Enter Employee Age: ");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Employee EmailID: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter  Employee DeparmentID: ");
            int deptID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee DesignetionID: ");
            int desgID = int.Parse(Console.ReadLine());

            employeeService.AddEmployee(EmpName, Gender, Age, email, deptID, desgID);
        }

        public static void UpdateEmployee()
        {
            Console.WriteLine("Enter Employee Id ToUpdate Data :");
            int Empid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Employee Name: ");
            string EmpName = Console.ReadLine();
            Console.WriteLine("Enter Employee Gender: ");
            string Gender = Console.ReadLine();
            Console.WriteLine("Enter Employee Age: ");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New Employee EmailID: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter  Employee DeparmentID: ");
            int deptID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee DesignetionID: ");
            int desgID = int.Parse(Console.ReadLine());

            employeeService.UpdateEmployee(Empid, EmpName, Gender, Age, email, deptID, desgID);
        }

        public static void DeleteEmployee()
        {
            Console.WriteLine("Enter Employee Id ToUpdate Data :");
            int Empid = int.Parse(Console.ReadLine());
            employeeService.DeleteEmployee(Empid);
        }

        public static void LinqOperations()
        {
            //Console.WriteLine("Employee Detailes Age > S30.....");
            //DataTable dt = employeeService.GetAllEmployee();
            //var result = from DataRow row in dt.Rows
            //             where (int)row["Age"] > 30
            //             select row;
            //foreach(DataRow row in result)
            //{
            //    Console.WriteLine($"{row["EmpName"]},Age: {row["Age"]}");
            //}
            //Console.WriteLine( "/n");
            //Console.WriteLine("Employee Detailes Acording To Gender....");
            //var maleCount = (from DataRow row in dt.Rows
            //              where row["Gender"].ToString() == "Male" 
            //              select row).Count();
            //int femaleCount =  dt.Rows.Count -  maleCount;
            //Console.WriteLine($"MaleCount: {maleCount} , FemaleCount: {femaleCount}");

            Console.WriteLine("Employee Detailes...");
            DataTable EmployeeDetails = employeeService.GetAllEmployee();
            DataTable Department = DbAccess.GetData("select * from Departments");
            DataTable Designetion = DbAccess.GetData("select * from Designations");
            DataTable Salaries = DbAccess.GetData("select * from Salaries");
            //var EmpDept = from emp in EmployeeDetails.AsEnumerable()
            //              join dept in Department.AsEnumerable()
            //              on (int)emp["DepartmentID"] equals (int)dept["DepartmentID"]
            //              select new
            //              {
            //                  Name = emp["EmpName"].ToString(),
            //                  Age = (int)emp["Age"],
            //                  Email = emp["Email"],
            //                  DeptName = dept["DepartmentName"],
            //                  DeptLocation = dept["DepartmentLocation"],
            //                  DesignationID = emp["DesignationID"]
            //              };
           
            // foreach(var row in EmpDept)
            //{
            //    Console.WriteLine($"Name: {row.Name}, Age: {row.Age}, Email: {row.Email}, DeptName : {row.DeptName}, DeptLocation: {row.DeptLocation}, DeptId: {row.DesignationID}");
            //}

            var CompleteJoin = from emp in EmployeeDetails.AsEnumerable()
                               join dept in Department.AsEnumerable()
                               on (int)emp["DepartmentID"] equals (int)dept["DepartmentID"]
                               join desg in Designetion.AsEnumerable()
                               on (int)emp["DesignationID"] equals (int)desg["DesignationID"]
                               join salary in Salaries.AsEnumerable()
                               on (int)emp["EmployeeID"] equals (int)salary["EmployeeID"]
                               select new
                               {
                                   EmpId = emp["EmployeeID"],
                                   Name = emp["EmpName"].ToString(),
                                   Email = emp["Email"],
                                   DeptName = dept["DepartmentName"],
                                   DeptLocation = dept["DepartmentLocation"],
                                   DesignationID = desg["DesignationID"],
                                   DesignationName = desg["DesignationName"],
                                   BasicSalary = salary["BasicSalary"],
                                   Netsalary = salary["NetSalary"]
                               };

            //foreach (var row in CompleteJoin)
            //{
            //    Console.WriteLine($" Name: {row.Name}" +
            //        $", Email: {row.Email}," +
            //        $" DeptName : {row.DeptName}, " +
            //        $"DeptLocation: {row.DeptLocation}," +
            //        $" DeptId: {row.DesignationID}," +
            //        $"DesgName: {row.DesignationName}," +
            //        $"BasicSalary: {row.BasicSalary}," +
            //        $"NetSalary: {row.Netsalary}");
            //}

            Parallel.ForEach(CompleteJoin  , row => 
            {
                
                    Console.WriteLine($" Name: {row.Name}" +
                        $", Email: {row.Email}," +
                        $" DeptName : {row.DeptName}, " +
                        $"DeptLocation: {row.DeptLocation}," +
                        $" DeptId: {row.DesignationID}," +
                        $"DesgName: {row.DesignationName}," +
                        $"BasicSalary: {row.BasicSalary}," +
                        $"NetSalary: {row.Netsalary}");
                
            });
        }
        public static void ExportToCSV()
        {

            Console.WriteLine("Employee Detailes...");
            DataTable EmployeeDetails = employeeService.GetAllEmployee();
            DataTable Department = DbAccess.GetData("select * from Departments");
            DataTable Designetion = DbAccess.GetData("select * from Designations");
            DataTable Salaries = DbAccess.GetData("select * from Salaries");

            var CompleteJoin = from emp in EmployeeDetails.AsEnumerable()
                               join dept in Department.AsEnumerable()
                               on (int)emp["DepartmentID"] equals (int)dept["DepartmentID"]
                               join desg in Designetion.AsEnumerable()
                               on (int)emp["DesignationID"] equals (int)desg["DesignationID"]
                               join salary in Salaries.AsEnumerable()
                               on (int)emp["EmployeeID"] equals (int)salary["EmployeeID"]
                               select new
                               {
                                   EmpId = emp["EmployeeID"],
                                   Name = emp["EmpName"].ToString(),
                                   Email = emp["Email"],
                                   DeptName = dept["DepartmentName"],
                                   DeptLocation = dept["DepartmentLocation"],
                                   DesignationID = desg["DesignationID"],
                                   DesignationName = desg["DesignationName"],
                                   BasicSalary = salary["BasicSalary"],
                                   Netsalary = salary["NetSalary"]
                               };
            string FilePath = @"C:\Users\tangu\source\repos\DemoCURD\DemoCURD\EmployeeDetails.csv";
            //string ZipPath = @"C:\Users\tangu\source\repos\DemoCURD\DemoCURD\EmployeeDetails.zip";

            using (StreamWriter sw = new StreamWriter(FilePath,false))
            {
                sw.WriteLine("EmpId,Name,Email,DeptName,DeptLocation,DesignationID,DesignationName,BasicSalary,Netsalary");
                foreach(var row in CompleteJoin)
                sw.WriteLine($"{row.EmpId},{row.Name},{row.Email},{row.DeptName},{row.DeptLocation},{row.DesignationID},{row.DesignationName},{row.BasicSalary},{row.Netsalary}");
            }
            Console.WriteLine($"Data SuccessFully Added To :{FilePath}");
            Console.WriteLine($"Number Of Rows : {CompleteJoin.Count()}");


            //if (File.Exists(FilePath))
            //{
            //    using(var fileStream =new FileStream(ZipPath , FileMode.Create)) 
            //    {
            //        using (var archive = new ZipArchive(fileStream, ZipArchiveMode.Create))
            //        {
            //            archive.CreateEntryFromFile(FilePath,Path.GetFileName(FilePath));                       
            //        }
            //        Console.WriteLine("Zipfile Created...");
            //    }
               
            //}

        }

    }
}
