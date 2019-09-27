using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAPIDocker.Migrations
{
    public partial class newmag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "MagazineId", "Name" },
                values: new object[] { 4, "DockerCompose Magazine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Magazine",
                keyColumn: "MagazineId",
                keyValue: 4);
        }
    }
}
