# DemoCURD – Console-Based Employee Management System

## 📌 Overview

**DemoCURD** is a **console-based CRUD (Create, Read, Update, Delete) application** developed using **C# and ADO.NET**. The project demonstrates how to build a layered architecture for managing employee data using **SQL Server**, along with **LINQ operations**, **parallel processing**, and **CSV export functionality**.

This project is ideal for **beginners and intermediate learners** to understand real-world database operations in a console application.

---

## 🛠️ Technology Stack

* **Language:** C#
* **Framework:** .NET (Console Application)
* **Database:** SQL Server
* **Data Access:** ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`)
* **Configuration:** `App.config` (using `AppSettings`)
* **Concepts Used:**

  * CRUD Operations
  * LINQ to DataTable
  * Parallel Programming (`Parallel.ForEach`)
  * File Handling (CSV Export)

---

## 📂 Project Architecture

The application follows a **layered architecture** for better separation of concerns:

```
DemoCURD/
│
├── Data/
│   └── DbAccess.cs          # Database connection & SQL execution
│
├── Services/
│   ├── EmployeeService.cs   # Business logic layer
│   └── EmployeeManagement.cs# User interaction & LINQ operations
│
├── Models/
│   └── Employee.cs (if any)
│
├── Program.cs               # Application entry point
```

---

## 🔗 Database Configuration

Connection string is read from **App.config** using `AppSettings`:

```xml
<appSettings>
  <add key="DbConnection" value="your_sql_connection_string_here" />
</appSettings>
```

---

## 🧾 Database Tables Used

* **Employees**
* **Departments**
* **Designations**
* **Salaries**

### Sample Employees Table

```sql
CREATE TABLE Employees (
    EmployeeID INT IDENTITY PRIMARY KEY,
    EmpName VARCHAR(100),
    Gender VARCHAR(10),
    Age INT,
    Email VARCHAR(100),
    DepartmentID INT,
    DesignationID INT
);
```

---

## ⚙️ Application Features

### 👤 Employee CRUD Operations

* View all employees
* View employee by ID
* Add new employee
* Update employee details
* Delete employee

### 🔍 LINQ Operations

* Join Employees with Departments, Designations, and Salaries
* Display complete employee details
* Parallel data processing using `Parallel.ForEach`

### 📁 Export to CSV

* Export complete employee data to a CSV file
* Displays total records exported

---

## 🖥️ Console Menu Options

```
1. View All Employees
2. View Employee by ID
3. Add New Employee
4. Update Employee
5. Delete Employee
6. View Employee Details using LINQ
7. Export Employee Details to CSV
0. Exit
```

---

## 🔐 Security & Best Practices (Learning Scope)

* Uses parameterized queries for SELECT and DELETE
* Demonstrates separation of concerns
* Exception handling implemented

⚠️ **Note:** Some INSERT and UPDATE queries use string interpolation (for learning only). In production, parameterized queries should always be used.

---

## 🚀 Future Enhancements

* Use parameterized queries everywhere
* Add input validation
* Implement logging
* Convert to REST API or ASP.NET MVC
* Add authentication & authorization

---

## 👨‍💻 Author

**Tangudu Raja**
C# | .NET | SQL | Backend Development Learner

---

## 📌 Disclaimer

This project is developed for **educational purposes only** and is not intended for production use without improvements.
