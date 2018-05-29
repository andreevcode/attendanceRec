namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTimeLog : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2015-02-24', '2017-02-24', 3) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2015-02-24', NULL, 5) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2013-02-24', '2014-02-24', 8) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2015-02-24', '2016-02-24', 11)  ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2016-05-01', '2018-05-21', 13) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2017-05-01', '2018-05-21', 14)");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2017-08-01', '2018-03-01', 15) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2017-08-01', '2018-03-01', 18) ");
            Sql("INSERT INTO Timelogs (StartDate, FinishDate, EmployeeId)  VALUES('2015-02-24', '2018-05-21', 19)");
        }

        public override void Down()
        {
        }
    }
}
