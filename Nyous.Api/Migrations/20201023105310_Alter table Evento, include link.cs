using Microsoft.EntityFrameworkCore.Migrations;

namespace Nyous.Api.Migrations
{
    public partial class AltertableEventoincludelink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Eventos");
        }
    }
}
