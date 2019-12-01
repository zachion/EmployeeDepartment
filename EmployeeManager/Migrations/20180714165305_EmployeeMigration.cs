using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManager.Migrations
{
    public partial class EmployeeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeFirstName = table.Column<string>(nullable: false),
                    EmployeeLastName = table.Column<string>(nullable: false),
                    EmployeeEmail = table.Column<string>(nullable: false),
                    EmployeeBirthDate = table.Column<DateTime>(nullable: false),
                    EmployeeDepartment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                            name: "Department",
                            columns: table => new
                            {
                                DepartmentId = table.Column<int>(nullable: false)
                                    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                                DepartmenName = table.Column<string>(nullable: false),
                                MaxEmployees = table.Column<int>(nullable: false)
                            },
                            constraints: table =>
                            {
                                table.PrimaryKey("PK_Department", x => x.DepartmentId);
                            });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
