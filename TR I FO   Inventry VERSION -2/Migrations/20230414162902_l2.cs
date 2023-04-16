using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TR_I_FO___Inventry_VERSION__2.Migrations
{
    /// <inheritdoc />
    public partial class l2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Approval",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Approval",
                table: "User");
        }
    }
}
