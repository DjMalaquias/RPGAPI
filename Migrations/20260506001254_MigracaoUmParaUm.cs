using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RpgApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoUmParaUm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Derrotas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Disputas",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Vitorias",
                table: "TB_PERSONAGENS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonagemId",
                table: "TB_ARMAS",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 1,
                column: "PersonagemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 2,
                column: "PersonagemId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 3,
                column: "PersonagemId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 4,
                column: "PersonagemId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 5,
                column: "PersonagemId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 6,
                column: "PersonagemId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "TB_ARMAS",
                keyColumn: "Id",
                keyValue: 7,
                column: "PersonagemId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_PERSONAGENS",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Derrotas", "Disputas", "Vitorias" },
                values: new object[] { 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 8, 115, 125, 34, 28, 61, 53, 134, 22, 216, 213, 205, 88, 224, 107, 183, 99, 133, 47, 144, 36, 26, 131, 215, 109, 60, 240, 219, 28, 156, 12, 155, 73, 242, 202, 204, 224, 103, 149, 127, 110, 241, 96, 160, 218, 219, 223, 156, 202, 228, 171, 15, 94, 197, 120, 208, 159, 193, 135, 109, 115, 35, 61, 206 }, new byte[] { 89, 46, 230, 46, 39, 147, 174, 146, 144, 46, 246, 18, 64, 17, 80, 200, 1, 232, 72, 170, 50, 248, 60, 231, 167, 144, 171, 11, 21, 7, 30, 34, 66, 0, 177, 177, 84, 133, 204, 58, 63, 207, 74, 238, 140, 186, 181, 67, 142, 215, 1, 77, 124, 78, 170, 16, 206, 178, 97, 13, 166, 56, 55, 123, 0, 229, 165, 207, 43, 145, 31, 44, 158, 10, 114, 58, 251, 168, 37, 94, 88, 145, 89, 164, 163, 16, 60, 148, 207, 24, 97, 212, 6, 168, 117, 91, 254, 108, 51, 99, 83, 25, 50, 163, 126, 242, 200, 17, 3, 195, 110, 239, 220, 59, 64, 23, 107, 0, 77, 196, 114, 117, 206, 232, 94, 183, 70, 211 } });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS",
                column: "PersonagemId",
                principalTable: "TB_PERSONAGENS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ARMAS_TB_PERSONAGENS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ARMAS_PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.DropColumn(
                name: "Derrotas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Disputas",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "Vitorias",
                table: "TB_PERSONAGENS");

            migrationBuilder.DropColumn(
                name: "PersonagemId",
                table: "TB_ARMAS");

            migrationBuilder.UpdateData(
                table: "TB_USUARIOS",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 229, 0, 206, 66, 227, 152, 157, 68, 136, 154, 233, 155, 165, 75, 30, 130, 228, 199, 136, 163, 124, 51, 14, 238, 136, 222, 33, 116, 31, 93, 213, 154, 248, 157, 196, 220, 130, 78, 207, 183, 151, 239, 247, 139, 146, 115, 52, 90, 22, 0, 85, 222, 127, 168, 98, 29, 103, 157, 224, 68, 213, 238, 159, 212 }, new byte[] { 6, 103, 143, 186, 254, 169, 129, 94, 134, 22, 103, 85, 211, 254, 137, 19, 182, 82, 20, 45, 127, 77, 7, 3, 174, 150, 118, 217, 49, 2, 39, 168, 122, 138, 105, 21, 78, 114, 77, 88, 39, 151, 108, 249, 232, 26, 178, 125, 184, 85, 82, 245, 109, 21, 1, 68, 116, 68, 20, 236, 167, 36, 209, 23, 119, 63, 212, 148, 162, 86, 209, 86, 217, 205, 179, 178, 48, 45, 192, 65, 192, 2, 153, 250, 111, 134, 16, 31, 141, 23, 140, 190, 155, 150, 98, 249, 69, 94, 77, 62, 214, 136, 199, 69, 186, 121, 248, 82, 118, 149, 4, 214, 189, 136, 235, 105, 28, 112, 195, 78, 61, 139, 110, 138, 167, 102, 244, 12 } });
        }
    }
}
