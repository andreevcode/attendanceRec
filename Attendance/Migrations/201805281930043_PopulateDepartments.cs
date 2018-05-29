namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepartments : DbMigration
    {
        public override void Up()
        {

            Sql("SET IDENTITY_INSERT Departments ON");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(19, N'Производственный департамент', 202, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(21, N'Администрация', 303, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(7, N'Бухгалтерия', 101, 21)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(8, N'Отдел MES', 102, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(9, N'Автобаза', 103, NULL)");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(10, N'Отдел продаж', 104, NULL)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(11, N'Молочный цех', 105, 19)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(12, N'Мясной цех', 106, 19)");

            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(13, N'Оберточный цех', 107, 19)");
            Sql("INSERT INTO Departments (Id, Name, Code, DepartmentId) VALUES(16, N'Отдел электрооборудования', 201, NULL)");


            Sql("SET IDENTITY_INSERT Departments OFF");
        }
        
        public override void Down()
        {
        }
    }
}
