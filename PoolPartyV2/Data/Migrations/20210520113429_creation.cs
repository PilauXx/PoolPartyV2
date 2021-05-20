using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoolPartyV2.Data.Migrations
{
    public partial class creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jeu",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jeu", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Licensie",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    LienceValidate = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Licensie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Competition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    jeuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Competition_Jeu_jeuID",
                        column: x => x.jeuID,
                        principalTable: "Jeu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompetitionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipe", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Equipe_Competition_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Etape",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RencontreID = table.Column<int>(type: "int", nullable: false),
                    EtapeSuivanteID = table.Column<int>(type: "int", nullable: true),
                    CompetitionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etape", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Etape_Competition_CompetitionID",
                        column: x => x.CompetitionID,
                        principalTable: "Competition",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etape_Etape_EtapeSuivanteID",
                        column: x => x.EtapeSuivanteID,
                        principalTable: "Etape",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "Rencontre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    jeuID = table.Column<int>(type: "int", nullable: true),
                    EtapeID = table.Column<int>(type: "int", nullable: false),
                    EquipeAID = table.Column<int>(type: "int", nullable: true),
                    EquipeBID = table.Column<int>(type: "int", nullable: true),
                    ScoreA = table.Column<int>(type: "int", nullable: false),
                    ScoreB = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rencontre", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rencontre_Equipe_EquipeAID",
                        column: x => x.EquipeAID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rencontre_Equipe_EquipeBID",
                        column: x => x.EquipeBID,
                        principalTable: "Equipe",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rencontre_Etape_EtapeID",
                        column: x => x.EtapeID,
                        principalTable: "Etape",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rencontre_Jeu_jeuID",
                        column: x => x.jeuID,
                        principalTable: "Jeu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competition_jeuID",
                table: "Competition",
                column: "jeuID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipe_CompetitionID",
                table: "Equipe",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeLicencie_LicensiesID",
                table: "EquipeLicencie",
                column: "LicensiesID");

            migrationBuilder.CreateIndex(
                name: "IX_Etape_CompetitionID",
                table: "Etape",
                column: "CompetitionID");

            migrationBuilder.CreateIndex(
                name: "IX_Etape_EtapeSuivanteID",
                table: "Etape",
                column: "EtapeSuivanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_EquipeAID",
                table: "Rencontre",
                column: "EquipeAID");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_EquipeBID",
                table: "Rencontre",
                column: "EquipeBID");

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_EtapeID",
                table: "Rencontre",
                column: "EtapeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rencontre_jeuID",
                table: "Rencontre",
                column: "jeuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipeLicencie");

            migrationBuilder.DropTable(
                name: "Rencontre");

            migrationBuilder.DropTable(
                name: "Licensie");

            migrationBuilder.DropTable(
                name: "Equipe");

            migrationBuilder.DropTable(
                name: "Etape");

            migrationBuilder.DropTable(
                name: "Competition");

            migrationBuilder.DropTable(
                name: "Jeu");
        }
    }
}
