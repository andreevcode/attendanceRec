namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteDepartmentIdFromJobTimes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttendanceJobTimes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AttendanceJobTimes", new[] { "DepartmentId" });
            DropColumn("dbo.AttendanceJobTimes", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AttendanceJobTimes", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AttendanceJobTimes", "DepartmentId");
            AddForeignKey("dbo.AttendanceJobTimes", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
