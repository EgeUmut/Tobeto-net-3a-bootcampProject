using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _27SubatOglen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlackLists_ApplicantId",
                table: "BlackLists");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_ApplicantId",
                table: "BlackLists",
                column: "ApplicantId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlackLists_ApplicantId",
                table: "BlackLists");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_ApplicantId",
                table: "BlackLists",
                column: "ApplicantId");
        }
    }
}
