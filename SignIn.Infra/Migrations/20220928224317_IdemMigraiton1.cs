using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignIn.Infra.Migrations
{
    public partial class IdemMigraiton1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChangedPass",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangedPass",
                table: "Users");
        }
    }
}
