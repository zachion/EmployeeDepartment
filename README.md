# EmployeeDepartment
I have developed a Employee-Department manager using Asp.NET Core 2.1 and Entity Framework core Code first approach. 
A web application with a simple administration area (2 pages) for managing company departments and
company employees shall be implemented. Company departments have a name and a max-employees
property. Company employees have the following properties: first name, last name, email address, birthdate
and a single company department (ForeignKey). All employee fields are required and must be validated before
saving.

I am  using Visual Studio 2019 and SQL Server 2017 (localdb) for our demo.

to create the database please navigate to the .cproj folder and run powershell command: dotnet ef database update

https://github.com/zachion/EmployeeDepartment