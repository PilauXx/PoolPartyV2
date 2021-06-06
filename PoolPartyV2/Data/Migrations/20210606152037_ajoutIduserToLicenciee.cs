using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolPartyV2.Data.Migrations
{
    public partial class ajoutIduserToLicenciee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Licensie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Licensie");
        }
    }
}
