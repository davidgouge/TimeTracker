using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace TimeTracker.Migrations
{
    public partial class Invoices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_TimeLog_Client_ClientId", table: "TimeLog");
            migrationBuilder.DropForeignKey(name: "FK_TimeLog_User_UserId", table: "TimeLog");
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: true),
                    From = table.Column<DateTime>(nullable: false),
                    InvoiceNumber = table.Column<int>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    To = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.AddColumn<int>(
                name: "OnInvoiceId",
                table: "TimeLog",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_Client_ClientId",
                table: "TimeLog",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_Invoice_OnInvoiceId",
                table: "TimeLog",
                column: "OnInvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_User_UserId",
                table: "TimeLog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_TimeLog_Client_ClientId", table: "TimeLog");
            migrationBuilder.DropForeignKey(name: "FK_TimeLog_Invoice_OnInvoiceId", table: "TimeLog");
            migrationBuilder.DropForeignKey(name: "FK_TimeLog_User_UserId", table: "TimeLog");
            migrationBuilder.DropColumn(name: "OnInvoiceId", table: "TimeLog");
            migrationBuilder.DropTable("Invoice");
            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_Client_ClientId",
                table: "TimeLog",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_TimeLog_User_UserId",
                table: "TimeLog",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
