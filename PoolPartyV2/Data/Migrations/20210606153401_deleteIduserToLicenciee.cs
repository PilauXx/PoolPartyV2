using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolPartyV2.Data.Migrations
{
    public partial class deleteIduserToLicenciee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Licensie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Licensie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
