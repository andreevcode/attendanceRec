namespace Attendance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateEmployees : DbMigration
    {
        public override void Up()
        {
            
            Sql("SET IDENTITY_INSERT Employees ON");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(3, N'Иван', NULL, N'Федоров', N'Инженер 1 категории')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(5, N'Саша', NULL, N'Васин', N'Главный специалист')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(8, N'Михаил', N'Петрович', N'Клязин', N'Начальник молочного цеха')");

            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(11, N'Наталья', NULL, N'Козлова', N'Начальник мясного цеха')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(13, N'Мария', NULL, N'Петрова', N'Мясник')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(14, N'Петр', NULL, N'Васин', N'Мясник')");

            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(15, N'Иван', NULL, N'Катин', N'Энергетик по цехам')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(18, N'Николай', NULL, N'Скалли', N'Главный энергетик')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(19, N'Петр', NULL, N'Шойгу', N'Главный бухгалтер')");
            Sql("SET IDENTITY_INSERT Employees OFF");
        }

        public override void Down()
        {
        }
    }
}
