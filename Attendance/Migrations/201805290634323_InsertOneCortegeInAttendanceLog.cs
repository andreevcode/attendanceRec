namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertOneCortegeInAttendanceLog : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AttendanceLogs (EmployeeId, TimeIn, TimeOut, Date) VALUES (3, '8:00','12:00', '2018-05-29')");
        }
        
        public override void Down()
        {
        }
    }
}
