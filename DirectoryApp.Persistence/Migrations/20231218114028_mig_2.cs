using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DirectoryApp.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Persons_PersonId",
                table: "ContactInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "ContactInfos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Persons_PersonId",
                table: "ContactInfos",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfos_Persons_PersonId",
                table: "ContactInfos");

            migrationBuilder.AlterColumn<Guid>(
                name: "PersonId",
                table: "ContactInfos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfos_Persons_PersonId",
                table: "ContactInfos",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
