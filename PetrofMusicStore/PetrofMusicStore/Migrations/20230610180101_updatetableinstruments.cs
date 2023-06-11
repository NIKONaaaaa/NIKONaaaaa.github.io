using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetrofMusicStore.Migrations
{
    /// <inheritdoc />
    public partial class updatetableinstruments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "Instruments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "Instruments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
