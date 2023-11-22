using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    public partial class carEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fiyat = table.Column<int>(type: "int", nullable: false),
                    ModelYil = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Fiyat", "Marka", "Model", "ModelYil", "Renk" },
                values: new object[] { 1, 5000, "BMW", "320", 2000, "Siyah" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Fiyat", "Marka", "Model", "ModelYil", "Renk" },
                values: new object[] { 2, 6000, "BMW", "320", 2001, "Siyah" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Fiyat", "Marka", "Model", "ModelYil", "Renk" },
                values: new object[] { 3, 7000, "BMW", "320", 2003, "Beyaz" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
