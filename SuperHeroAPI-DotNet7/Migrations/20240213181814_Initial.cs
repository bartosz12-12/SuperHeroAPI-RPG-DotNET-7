using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperHeroAPI_DotNet7.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HitPoinsts = table.Column<int>(type: "int", nullable: false),
                    Strenght = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Intelliegence = table.Column<int>(type: "int", nullable: false),
                    RpgClass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");
        }
    }
}
