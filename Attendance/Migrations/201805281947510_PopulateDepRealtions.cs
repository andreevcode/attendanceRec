namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDepRealtions : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(3, 7)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(5, 7)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(15, 11)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(15, 12)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(15, 13)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(15, 16)");
            Sql("INSERT INTO DepRelations (EmployeeId, DepartmentId) VALUES(19, 7)");
        }
        
        public override void Down()
        {
        }
    }
}
