using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mipBackend.Migrations
{
    public partial class addsetselect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetSelects",
                columns: table => new
                {
                    Value = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetSelects", x => x.Value);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetSelects");
        }
    }
}
