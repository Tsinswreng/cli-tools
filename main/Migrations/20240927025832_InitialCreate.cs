using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace main.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KV",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    KeyDesc = table.Column<string>(type: "TEXT", nullable: false),
                    VauleType = table.Column<string>(type: "TEXT", nullable: false),
                    ValueDesc = table.Column<string>(type: "TEXT", nullable: false),
                    Str = table.Column<string>(type: "TEXT", nullable: false),
                    Int = table.Column<long>(type: "INTEGER", nullable: true),
                    Real = table.Column<double>(type: "REAL", nullable: true),
                    Bl = table.Column<string>(type: "TEXT", nullable: false),
                    Ct = table.Column<long>(type: "INTEGER", nullable: false),
                    Ut = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KV", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KV_Bl",
                table: "KV",
                column: "Bl");

            migrationBuilder.CreateIndex(
                name: "IX_KV_Ct",
                table: "KV",
                column: "Ct");

            migrationBuilder.CreateIndex(
                name: "IX_KV_Key",
                table: "KV",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_KV_KeyDesc",
                table: "KV",
                column: "KeyDesc");

            migrationBuilder.CreateIndex(
                name: "IX_KV_Ut",
                table: "KV",
                column: "Ut");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KV");
        }
    }
}
