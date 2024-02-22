using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class _22SubatAksam : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStates_ApplicationStateId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Bootcamps_BootcampId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_BootcampStates_BootcampStateId",
                table: "Bootcamps");

            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Instructors_InstructorId",
                table: "Bootcamps");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStates_ApplicationStateId",
                table: "Applications",
                column: "ApplicationStateId",
                principalTable: "ApplicationStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Bootcamps_BootcampId",
                table: "Applications",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_BootcampStates_BootcampStateId",
                table: "Bootcamps",
                column: "BootcampStateId",
                principalTable: "BootcampStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Instructors_InstructorId",
                table: "Bootcamps",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_ApplicationStates_ApplicationStateId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Bootcamps_BootcampId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_BootcampStates_BootcampStateId",
                table: "Bootcamps");

            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Instructors_InstructorId",
                table: "Bootcamps");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applicants_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_ApplicationStates_ApplicationStateId",
                table: "Applications",
                column: "ApplicationStateId",
                principalTable: "ApplicationStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Bootcamps_BootcampId",
                table: "Applications",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_BootcampStates_BootcampStateId",
                table: "Bootcamps",
                column: "BootcampStateId",
                principalTable: "BootcampStates",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Instructors_InstructorId",
                table: "Bootcamps",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }
    }
}
