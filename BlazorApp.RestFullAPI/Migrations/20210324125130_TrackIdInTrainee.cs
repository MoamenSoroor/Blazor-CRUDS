using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorApp.RestFullAPI.Migrations
{
    public partial class TrackIdInTrainee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Tracks_TrackID",
                table: "Trainees");

            migrationBuilder.RenameColumn(
                name: "TrackID",
                table: "Trainees",
                newName: "TrackId");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_TrackID",
                table: "Trainees",
                newName: "IX_Trainees_TrackId");

            migrationBuilder.AlterColumn<int>(
                name: "TrackId",
                table: "Trainees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Tracks_TrackId",
                table: "Trainees",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainees_Tracks_TrackId",
                table: "Trainees");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                table: "Trainees",
                newName: "TrackID");

            migrationBuilder.RenameIndex(
                name: "IX_Trainees_TrackId",
                table: "Trainees",
                newName: "IX_Trainees_TrackID");

            migrationBuilder.AlterColumn<int>(
                name: "TrackID",
                table: "Trainees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainees_Tracks_TrackID",
                table: "Trainees",
                column: "TrackID",
                principalTable: "Tracks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
