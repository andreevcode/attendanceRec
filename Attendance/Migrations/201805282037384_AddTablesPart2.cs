namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesPart2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceJobTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        DayStartTime = c.Time(nullable: false, precision: 7),
                        DayFinishTime = c.Time(nullable: false, precision: 7),
                        JobTime = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                        IsLate = c.Boolean(nullable: false),
                        IsJobTimeNotEnough = c.Boolean(nullable: false),
                        IsJobTimeTooMuch = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.AttendanceLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        TimeIn = c.Time(nullable: false, precision: 7),
                        TimeOut = c.Time(nullable: false, precision: 7),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.TimeShedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SheduleStartTime = c.Time(nullable: false, precision: 7),
                        SheduleFinishTime = c.Time(nullable: false, precision: 7),
                        BreakStartTime = c.Time(nullable: false, precision: 7),
                        BreakFinishTime = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TimeShedules", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AttendanceLogs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AttendanceJobTimes", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AttendanceJobTimes", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.TimeShedules", new[] { "EmployeeId" });
            DropIndex("dbo.AttendanceLogs", new[] { "EmployeeId" });
            DropIndex("dbo.AttendanceJobTimes", new[] { "DepartmentId" });
            DropIndex("dbo.AttendanceJobTimes", new[] { "EmployeeId" });
            DropTable("dbo.TimeShedules");
            DropTable("dbo.AttendanceLogs");
            DropTable("dbo.AttendanceJobTimes");
        }
    }
}
