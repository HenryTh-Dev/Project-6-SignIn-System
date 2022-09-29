using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignIn.Infra.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Lastname = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Snn = table.Column<string>(type: "VARCHAR(8)", nullable: false),
                    Birthdate = table.Column<string>(type: "CHAR(8)", nullable: false),
                    Password = table.Column<string>(type: "VARCHAR(32)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
