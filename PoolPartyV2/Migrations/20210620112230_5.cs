using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolPartyV2.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembreEquipe_Equipe_EquipeID",
                table: "MembreEquipe");

            migrationBuilder.DropForeignKey(
                name: "FK_MembreEquipe_Licensie_LicencieID",
                table: "MembreEquipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembreEquipe",
                table: "MembreEquipe");

            migrationBuilder.RenameTable(
                name: "MembreEquipe",
                newName: "MembreEquipes");

            migrationBuilder.RenameIndex(
                name: "IX_MembreEquipe_LicencieID",
                table: "MembreEquipes",
                newName: "IX_MembreEquipes_LicencieID");

            migrationBuilder.RenameIndex(
                name: "IX_MembreEquipe_EquipeID",
                table: "MembreEquipes",
                newName: "IX_MembreEquipes_EquipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembreEquipes",
                table: "MembreEquipes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MembreEquipes_Equipe_EquipeID",
                table: "MembreEquipes",
                column: "EquipeID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembreEquipes_Licensie_LicencieID",
                table: "MembreEquipes",
                column: "LicencieID",
                principalTable: "Licensie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MembreEquipes_Equipe_EquipeID",
                table: "MembreEquipes");

            migrationBuilder.DropForeignKey(
                name: "FK_MembreEquipes_Licensie_LicencieID",
                table: "MembreEquipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembreEquipes",
                table: "MembreEquipes");

            migrationBuilder.RenameTable(
                name: "MembreEquipes",
                newName: "MembreEquipe");

            migrationBuilder.RenameIndex(
                name: "IX_MembreEquipes_LicencieID",
                table: "MembreEquipe",
                newName: "IX_MembreEquipe_LicencieID");

            migrationBuilder.RenameIndex(
                name: "IX_MembreEquipes_EquipeID",
                table: "MembreEquipe",
                newName: "IX_MembreEquipe_EquipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembreEquipe",
                table: "MembreEquipe",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MembreEquipe_Equipe_EquipeID",
                table: "MembreEquipe",
                column: "EquipeID",
                principalTable: "Equipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MembreEquipe_Licensie_LicencieID",
                table: "MembreEquipe",
                column: "LicencieID",
                principalTable: "Licensie",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
