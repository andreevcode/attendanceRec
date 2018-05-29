namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartments : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT Departments ON");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(19, N'���������������� �����������', 202, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(21, N'�������������', 303, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(7, N'�����������', 101, 21)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(8, N'����� MES', 102, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(9, N'��������', 103, NULL)");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(10, N'����� ������', 104, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(11, N'�������� ���', 105, 19)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(12, N'������ ���', 106, 19)");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(13, N'���������� ���', 107, 19)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(16, N'����� �������������������', 201, NULL)");


            Sql("SET IDENTITY_INSERT Departments OFF");
        }
        
        public override void Down()
        {
        }
    }
}
