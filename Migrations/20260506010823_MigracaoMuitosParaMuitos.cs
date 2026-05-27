using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoMuitosParaMuitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_HABILIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Dano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_HABILIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERSONAGENS_HABILIDADES",
                columns: table => new
                {
                    PersonagemId = table.Column<int>(type: "int", nullable: false),
                    HabilidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERSONAGENS_HABILIDADES", x => new { x.PersonagemId, x.HabilidadeId });
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_HABILIDADES_HabilidadeId",
                        column: x => x.HabilidadeId,
                        principalTable: "TB_HABILIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_PERSONAGENS_HABILIDADES_TB_PERSONAGENS_PersonagemId",
                        column: x => x.PersonagemId,
                        principalTable: "TB_PERSONAGENS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_HABILIDADES",
                columns: new[] { "Id", "Dano", "Nome" },
                values: new object[,]
                {
                    { 1, 39, "Adormecer" },
                    { 2, 41, "Congelar" },
                    { 3, 37, "Hipnotizar" }
                });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 67, 73, 221, 173, 64, 61, 144, 230, 4, 206, 30, 67, 233, 81, 69, 130, 61, 18, 217, 43, 170, 249, 86, 205, 100, 190, 144, 220, 239, 49, 46, 10, 68, 43, 253, 79, 179, 17, 211, 9, 47, 78, 97, 242, 209, 227, 21, 254, 163, 138, 121, 115, 120, 217, 118, 66, 8, 116, 83, 32, 163, 236, 12, 134 }, new byte[] { 220, 87, 227, 192, 130, 7, 132, 109, 69, 212, 159, 38, 167, 23, 52, 179, 84, 79, 203, 98, 101, 176, 61, 38, 8, 131, 120, 226, 183, 63, 100, 43, 92, 63, 89, 210, 32, 94, 193, 56, 61, 123, 73, 132, 243, 219, 7, 39, 175, 44, 244, 171, 252, 36, 95, 181, 168, 129, 245, 87, 44, 164, 122, 211, 38, 20, 235, 156, 108, 68, 152, 37, 52, 183, 226, 102, 7, 179, 236, 203, 69, 102, 210, 182, 200, 185, 196, 155, 16, 12, 12, 38, 219, 228, 177, 71, 217, 190, 160, 117, 200, 74, 107, 199, 58, 168, 166, 240, 197, 51, 218, 163, 208, 200, 91, 145, 250, 49, 193, 2, 221, 97, 110, 44, 228, 16, 160, 3 } });

            migrationBuilder.InsertData(
                table: "TB_PERSONAGENS_HABILIDADES",
                columns: new[] { "HabilidadeId", "PersonagemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 },
                    { 3, 4 },
                    { 1, 5 },
                    { 2, 6 },
                    { 3, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PERSONAGENS_HABILIDADES_HabilidadeId",
                table: "TB_PERSONAGENS_HABILIDADES",
                column: "HabilidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PERSONAGENS_HABILIDADES");

            migrationBuilder.DropTable(
                name: "TB_HABILIDADES");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 115, 125, 34, 28, 61, 53, 134, 22, 216, 213, 205, 88, 224, 107, 183, 99, 133, 47, 144, 36, 26, 131, 215, 109, 60, 240, 219, 28, 156, 12, 155, 73, 242, 202, 204, 224, 103, 149, 127, 110, 241, 96, 160, 218, 219, 223, 156, 202, 228, 171, 15, 94, 197, 120, 208, 159, 193, 135, 109, 115, 35, 61, 206 }, new byte[] { 89, 46, 230, 46, 39, 147, 174, 146, 144, 46, 246, 18, 64, 17, 80, 200, 1, 232, 72, 170, 50, 248, 60, 231, 167, 144, 171, 11, 21, 7, 30, 34, 66, 0, 177, 177, 84, 133, 204, 58, 63, 207, 74, 238, 140, 186, 181, 67, 142, 215, 1, 77, 124, 78, 170, 16, 206, 178, 97, 13, 166, 56, 55, 123, 0, 229, 165, 207, 43, 145, 31, 44, 158, 10, 114, 58, 251, 168, 37, 94, 88, 145, 89, 164, 163, 16, 60, 148, 207, 24, 97, 212, 6, 168, 117, 91, 254, 108, 51, 99, 83, 25, 50, 163, 126, 242, 200, 17, 3, 195, 110, 239, 220, 59, 64, 23, 107, 0, 77, 196, 114, 117, 206, 232, 94, 183, 70, 211 } });
        }
    }
}
