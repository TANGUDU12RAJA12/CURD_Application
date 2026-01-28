using DemoCURD.Data;
using DemoCURD.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DemoCURD.Services
{
    public class EmployeeService
    {
        public DataTable GetAllEmployee()
        {
            string query = @"SELECT EmployeeID,EmpName,Gender,Age,Email,DepartmentID, DesignationID FROM Employees";
            return DbAccess.GetData(query);
        }

        public DataTable GetEmployeeById(int id)
        {
            string query = @"SELECT EmployeeID,EmpName,Gender,Age,Email,DepartmentID, DesignationID FROM Employees Where EmployeeID = @EmployeeID";
            return DbAccess.GetDataById(query,id);
        }

        public void AddEmployee(string empname , string gender , int age , string email , int DepartmentID, int DesignationID)
        {
             string query = $"INSERT INTO Employees (EmpName, Gender, Age, Email, DepartmentID, DesignationID) " +
                                  $"VALUES ('{empname}', '{gender}', {age}, '{email}', {DepartmentID}, {DesignationID})";
            DbAccess.InsertData(query);

        }

        public void UpdateEmployee(int employeeId, string empName, string gender, int age, string email, int deptId, int designId)
        {
            //string query = @"UPDATE Employees SET EmpName = @EmpName, Gender = @Gender, Age = @Age, 
            //             Email = @Email, DepartmentID = @DeptID, DesignationID = @DesignID 
            //           WHERE EmployeeID = @EmployeeID";

            string query = $"UPDATE Employees SET EmpName = '{empName}', Gender = '{gender}', " +
                                  $"Age = {age}, Email = '{email}', DepartmentID = {deptId}, " +
                                  $"DesignationID = {designId} WHERE EmployeeID = {employeeId}";
            DbAccess.UpdateData(query,employeeId);
        }
        public void DeleteEmployee(int employeeId)
        {
            string query = @"DELETE Employees WHERE EmployeeID = @EmployeeID"; 
            DbAccess.DeleteRecord(query,employeeId);
        }
    }
}
