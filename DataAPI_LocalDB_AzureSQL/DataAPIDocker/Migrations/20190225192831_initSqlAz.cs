using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAPIDocker.Migrations
{
    public partial class initSqlAz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Magazine",
                columns: table => new
                {
                    MagazineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazine", x => x.MagazineId);
                });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "MagazineId", "Name" },
                values: new object[] { 1, "BASTA! Magazine" });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "MagazineId", "Name" },
                values: new object[] { 2, "Docker Magazine" });

            migrationBuilder.InsertData(
                table: "Magazine",
                columns: new[] { "MagazineId", "Name" },
                values: new object[] { 3, "EFCore Magazine" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Magazine");
        }
    }
}
