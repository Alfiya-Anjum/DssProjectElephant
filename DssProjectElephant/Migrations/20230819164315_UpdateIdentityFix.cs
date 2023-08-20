using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DssProjectElephant.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Addresses_AddressID",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AppUser_TheAppUserID1",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_TheNews_AppUser_TheAppUserID1",
                table: "TheNews");

            migrationBuilder.DropIndex(
                name: "IX_TheNews_TheAppUserID1",
                table: "TheNews");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_TheAppUserID1",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "TheAppUserID1",
                table: "TheNews");

            migrationBuilder.DropColumn(
                name: "TheAppUserID1",
                table: "Clubs");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "TheNews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clubs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "AppUser",
                newName: "AddressId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "AppUser",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AddressID",
                table: "AppUser",
                newName: "IX_AppUser_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "TheAppUserID",
                table: "TheNews",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TheAppUserID",
                table: "Clubs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "AppUser",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AppUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AppUser",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AppUser",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AppUser",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TheNews_TheAppUserID",
                table: "TheNews",
                column: "TheAppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_TheAppUserID",
                table: "Clubs",
                column: "TheAppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Addresses_AddressId",
                table: "AppUser",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AppUser_TheAppUserID",
                table: "Clubs",
                column: "TheAppUserID",
                principalTable: "AppUser",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheNews_AppUser_TheAppUserID",
                table: "TheNews",
                column: "TheAppUserID",
                principalTable: "AppUser",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUser_Addresses_AddressId",
                table: "AppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_AppUser_TheAppUserID",
                table: "Clubs");

            migrationBuilder.DropForeignKey(
                name: "FK_TheNews_AppUser_TheAppUserID",
                table: "TheNews");

            migrationBuilder.DropIndex(
                name: "IX_TheNews_TheAppUserID",
                table: "TheNews");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_TheAppUserID",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AppUser");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TheNews",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clubs",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AppUser",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUser",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_AppUser_AddressId",
                table: "AppUser",
                newName: "IX_AppUser_AddressID");

            migrationBuilder.AlterColumn<string>(
                name: "TheAppUserID",
                table: "TheNews",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheAppUserID1",
                table: "TheNews",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TheAppUserID",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TheAppUserID1",
                table: "Clubs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "AppUser",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "AppUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_TheNews_TheAppUserID1",
                table: "TheNews",
                column: "TheAppUserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_TheAppUserID1",
                table: "Clubs",
                column: "TheAppUserID1");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUser_Addresses_AddressID",
                table: "AppUser",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_AppUser_TheAppUserID1",
                table: "Clubs",
                column: "TheAppUserID1",
                principalTable: "AppUser",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TheNews_AppUser_TheAppUserID1",
                table: "TheNews",
                column: "TheAppUserID1",
                principalTable: "AppUser",
                principalColumn: "ID");
        }
    }
}
