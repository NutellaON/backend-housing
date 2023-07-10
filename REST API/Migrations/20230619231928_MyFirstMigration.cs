using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_API.Migrations
{
    /// <inheritdoc />
    public partial class MyFirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Iedzīvotāji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uzvards = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Personas_kods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dzimsanas_datums = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefons = table.Column<int>(type: "int", nullable: false),
                    Epasts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Iedzīvotāji", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mājas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numurs = table.Column<int>(type: "int", nullable: false),
                    Iela = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pilseta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valsts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pasta_indekss = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mājas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dzīvokļi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numurs = table.Column<int>(type: "int", nullable: false),
                    Stavs = table.Column<int>(type: "int", nullable: false),
                    Istabu_skaits = table.Column<int>(type: "int", nullable: false),
                    Iedzivotaju_skaits = table.Column<int>(type: "int", nullable: false),
                    Pilna_platiba = table.Column<double>(type: "float", nullable: false),
                    Dzivojama_platiba = table.Column<double>(type: "float", nullable: false),
                    MājaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dzīvokļi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dzīvokļi_Mājas_MājaId",
                        column: x => x.MājaId,
                        principalTable: "Mājas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IedzīvotājiDzīvokļi",
                columns: table => new
                {
                    IedzivotajaID = table.Column<int>(type: "int", nullable: false),
                    DzivoklaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IedzīvotājiDzīvokļi", x => new { x.IedzivotajaID, x.DzivoklaID });
                    table.ForeignKey(
                        name: "FK_IedzīvotājiDzīvokļi_Dzīvokļi_DzivoklaID",
                        column: x => x.DzivoklaID,
                        principalTable: "Dzīvokļi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IedzīvotājiDzīvokļi_Iedzīvotāji_IedzivotajaID",
                        column: x => x.IedzivotajaID,
                        principalTable: "Iedzīvotāji",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Iedzīvotāji",
                columns: new[] { "Id", "Dzimsanas_datums", "Epasts", "IsOwner", "Personas_kods", "Telefons", "Uzvards", "Vards" },
                values: new object[,]
                {
                    { 1, new DateTime(1991, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "bob@inbox.lv", false, "12412-220191", 22132451, "Bērzins", "Jānis" },
                    { 2, new DateTime(1992, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "testers@gmail.com", false, "12345-230292", 24371234, "Zveja", "Andris" },
                    { 3, new DateTime(1999, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "programmetajs@inbox.lv", false, "58214-020599", 24352357, "Liepa", "Anna" },
                    { 4, new DateTime(1981, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "epastsepasts@inbox.lv", false, "14561-111181", 27545345, "Modre", "Marija" }
                });

            migrationBuilder.InsertData(
                table: "Mājas",
                columns: new[] { "Id", "Iela", "Numurs", "Pasta_indekss", "Pilseta", "Valsts" },
                values: new object[,]
                {
                    { 1, "Ganibu", 21, "LV3007", "Riga", "Latvija" },
                    { 2, "Zvejnieku", 30, "LV3011", "Jelgava", "Latvija" }
                });

            migrationBuilder.InsertData(
                table: "Dzīvokļi",
                columns: new[] { "Id", "Dzivojama_platiba", "Iedzivotaju_skaits", "Istabu_skaits", "MājaId", "Numurs", "Pilna_platiba", "Stavs" },
                values: new object[,]
                {
                    { 1, 60.509999999999998, 4, 4, 1, 21, 65.209999999999994, 6 },
                    { 2, 50.540999999999997, 4, 4, 1, 4, 52.109999999999999, 1 },
                    { 3, 44.43, 4, 3, 1, 32, 47.439999999999998, 2 },
                    { 4, 29.100000000000001, 2, 2, 2, 8, 31.199999999999999, 4 },
                    { 5, 24.399999999999999, 1, 1, 2, 16, 25.210000000000001, 9 }
                });

            migrationBuilder.InsertData(
                table: "IedzīvotājiDzīvokļi",
                columns: new[] { "DzivoklaID", "IedzivotajaID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 4, 1 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dzīvokļi_MājaId",
                table: "Dzīvokļi",
                column: "MājaId");

            migrationBuilder.CreateIndex(
                name: "IX_IedzīvotājiDzīvokļi_DzivoklaID",
                table: "IedzīvotājiDzīvokļi",
                column: "DzivoklaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IedzīvotājiDzīvokļi");

            migrationBuilder.DropTable(
                name: "Dzīvokļi");

            migrationBuilder.DropTable(
                name: "Iedzīvotāji");

            migrationBuilder.DropTable(
                name: "Mājas");
        }
    }
}
