namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpplyChangesToModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AttendanceLogs", "TimeIn", c => c.Time(precision: 7));
            AlterColumn("dbo.AttendanceLogs", "TimeOut", c => c.Time(precision: 7));
            AlterColumn("dbo.AttendanceLogs", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AttendanceLogs", "Date", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AttendanceLogs", "TimeOut", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.AttendanceLogs", "TimeIn", c => c.Time(nullable: false, precision: 7));
        }
    }
}
