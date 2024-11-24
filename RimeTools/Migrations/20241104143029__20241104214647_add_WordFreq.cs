using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace main.Migrations
{
    /// <inheritdoc />
    public partial class _20241104214647_add_WordFreq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WordFreq",
                columns: table => new
                {
                    id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bl = table.Column<string>(type: "TEXT", nullable: true),
                    ct = table.Column<long>(type: "INTEGER", nullable: false, defaultValueSql: "(strftime('%s', 'now') || substr(strftime('%f', 'now'), 4))"),
                    ut = table.Column<long>(type: "INTEGER", nullable: false, defaultValueSql: "(strftime('%s', 'now') || substr(strftime('%f', 'now'), 4))"),
                    kType = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "STR"),
                    kStr = table.Column<string>(type: "TEXT", nullable: true),
                    kI64 = table.Column<long>(type: "INTEGER", nullable: true),
                    kDesc = table.Column<string>(type: "TEXT", nullable: true),
                    vType = table.Column<string>(type: "TEXT", nullable: false, defaultValue: "STR"),
                    vDesc = table.Column<string>(type: "TEXT", nullable: true),
                    vStr = table.Column<string>(type: "TEXT", nullable: true),
                    vI64 = table.Column<long>(type: "INTEGER", nullable: true),
                    vF64 = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordFreq", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_bl",
                table: "WordFreq",
                column: "bl");

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_ct",
                table: "WordFreq",
                column: "ct");

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_kDesc",
                table: "WordFreq",
                column: "kDesc");

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_kI64",
                table: "WordFreq",
                column: "kI64");

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_kStr",
                table: "WordFreq",
                column: "kStr");

            migrationBuilder.CreateIndex(
                name: "IX_WordFreq_ut",
                table: "WordFreq",
                column: "ut");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WordFreq");
        }
    }
}
