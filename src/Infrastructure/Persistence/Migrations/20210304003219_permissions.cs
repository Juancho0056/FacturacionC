using Microsoft.EntityFrameworkCore.Migrations;

namespace VentasApp.Infrastructure.Persistence.Migrations
{
    public partial class permissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationPermission_menusroles_MenuRoleId",
                table: "ApplicationPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationPermission",
                table: "ApplicationPermission");

            migrationBuilder.RenameTable(
                name: "ApplicationPermission",
                newName: "permissions");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationPermission_MenuRoleId",
                table: "permissions",
                newName: "IX_permissions_MenuRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_permissions",
                table: "permissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_permissions_menusroles_MenuRoleId",
                table: "permissions",
                column: "MenuRoleId",
                principalTable: "menusroles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_permissions_menusroles_MenuRoleId",
                table: "permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_permissions",
                table: "permissions");

            migrationBuilder.RenameTable(
                name: "permissions",
                newName: "ApplicationPermission");

            migrationBuilder.RenameIndex(
                name: "IX_permissions_MenuRoleId",
                table: "ApplicationPermission",
                newName: "IX_ApplicationPermission_MenuRoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationPermission",
                table: "ApplicationPermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationPermission_menusroles_MenuRoleId",
                table: "ApplicationPermission",
                column: "MenuRoleId",
                principalTable: "menusroles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
