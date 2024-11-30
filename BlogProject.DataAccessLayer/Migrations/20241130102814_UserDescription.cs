using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class UserDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserDescription",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDescription",
                table: "AspNetUsers");
        }
    }
}
