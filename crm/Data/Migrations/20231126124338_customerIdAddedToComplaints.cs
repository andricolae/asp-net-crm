using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crm.Data.Migrations
{
    public partial class customerIdAddedToComplaints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Complaints",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Complaints");
        }
    }
}
