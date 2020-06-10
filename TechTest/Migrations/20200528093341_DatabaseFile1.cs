using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTest.Migrations
{
    public partial class DatabaseFile1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    EID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(maxLength: 50, nullable: true),
                    Designation = table.Column<string>(maxLength: 10, nullable: true),
                    Join_Date = table.Column<string>(maxLength: 20, nullable: true),
                    Current_Salary = table.Column<double>(nullable: false),
                    Department = table.Column<string>(maxLength: 10, nullable: true),
                    Next_Review_Date = table.Column<string>(maxLength: 20, nullable: true),
                    Date_Of_Birth = table.Column<string>(maxLength: 10, nullable: true),
                    Gender = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.EID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");
        }
    }
}
