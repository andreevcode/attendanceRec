namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeesDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Surname = c.String(),
                        Position = c.String(),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "EmployeeId" });
            DropTable("dbo.Employees");
        }
    }
}
