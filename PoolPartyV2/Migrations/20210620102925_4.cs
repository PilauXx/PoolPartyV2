using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolPartyV2.Migrations
{
    public partial class _4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeLicencie");

            migrationBuilder.AddColumn<int>(
                name: "LicencieID",
                table: "Equipe",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MembreEquipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDEquipe = table.Column<int>(type: "int", nullable: false),
                    EquipeID = table.Column<int>(type: "int", nullable: true),
                    IDLicencie = table.Column<int>(type: "int", nullable: false),
                    LicencieID = table.Column<int>(type: "int", nullable: true),
                    Confirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembreEquipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MembreEquipe_Equipe_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembreEquipe_Licensie_LicencieID",
                        column: x => x.LicencieID,
                        principalTable: "Licensie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_LicencieID",
                table: "Equipe",
                column: "LicencieID");

            migrationBuilder.CreateIndex(
                name: "IX_MembreEquipe_EquipeID",
                table: "MembreEquipe",
                column: "EquipeID");

            migrationBuilder.CreateIndex(
                name: "IX_MembreEquipe_LicencieID",
                table: "MembreEquipe",
                column: "LicencieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipe_Licensie_LicencieID",
                table: "Equipe",
                column: "LicencieID",
                principalTable: "Licensie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipe_Licensie_LicencieID",
                table: "Equipe");

            migrationBuilder.DropTable(
                name: "MembreEquipe");

            migrationBuilder.DropIndex(
                name: "IX_Equipe_LicencieID",
                table: "Equipe");

            migrationBuilder.DropColumn(
                name: "LicencieID",
                table: "Equipe");

            migrationBuilder.CreateTable(
                name: "EquipeLicencie",
                columns: table => new
                {
                    EquipesID = table.Column<int>(type: "int", nullable: false),
                    LicensiesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipeLicencie", x => new { x.EquipesID, x.LicensiesID });
                    table.ForeignKey(
                        name: "FK_EquipeLicencie_Equipe_EquipesID",
                        column: x => x.EquipesID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipeLicencie_Licensie_LicensiesID",
                        column: x => x.LicensiesID,
                        principalTable: "Licensie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EquipeLicencie_LicensiesID",
                table: "EquipeLicencie",
                column: "LicensiesID");
        }
    }
}
