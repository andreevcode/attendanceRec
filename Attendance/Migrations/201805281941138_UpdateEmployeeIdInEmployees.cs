namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeIdInEmployees : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Employees SET EmployeeId= 19 WHERE Id=3");
            Sql("UPDATE Employees SET EmployeeId= 19 WHERE Id=5");
            Sql("UPDATE Employees SET EmployeeId= NULL WHERE Id=8");
            Sql("UPDATE Employees SET EmployeeId= NULL WHERE Id=11");
            Sql("UPDATE Employees SET EmployeeId= 11 WHERE Id=13");
            Sql("UPDATE Employees SET EmployeeId= 11 WHERE Id=14");
            Sql("UPDATE Employees SET EmployeeId= 18 WHERE Id=15");
            Sql("UPDATE Employees SET EmployeeId= NULL WHERE Id=18");
            Sql("UPDATE Employees SET EmployeeId= NULL WHERE Id=19");
        }

        public override void Down()
        {
        }
    }
}
