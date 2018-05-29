namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLastFirstPartTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.DepRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Timelogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        FinishDate = c.DateTime(),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Timelogs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DepRelations", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DepRelations", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Timelogs", new[] { "EmployeeId" });
            DropIndex("dbo.DepRelations", new[] { "DepartmentId" });
            DropIndex("dbo.DepRelations", new[] { "EmployeeId" });
            DropIndex("dbo.Departments", new[] { "DepartmentId" });
            DropTable("dbo.Timelogs");
            DropTable("dbo.DepRelations");
            DropTable("dbo.Departments");
        }
    }
}
