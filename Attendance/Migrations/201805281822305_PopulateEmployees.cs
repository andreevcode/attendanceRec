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
                "VALUES(3, N'����', NULL, N'�������', N'������� 1 ���������')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(5, N'����', NULL, N'�����', N'������� ����������')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(8, N'������', N'��������', N'������', N'��������� ��������� ����')");

            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(11, N'�������', NULL, N'�������', N'��������� ������� ����')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(13, N'�����', NULL, N'�������', N'������')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(14, N'����', NULL, N'�����', N'������')");

            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(15, N'����', NULL, N'�����', N'��������� �� �����')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(18, N'�������', NULL, N'������', N'������� ���������')");
            Sql("INSERT Employees (Id, Name, Patronymic, Surname, Position) " +
                "VALUES(19, N'����', NULL, N'�����', N'������� ���������')");
            Sql("SET IDENTITY_INSERT Employees OFF");
        }

        public override void Down()
        {
        }
    }
}
