using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OldMutual.Scheme.Host.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inbound_Mimo_Customer",
                columns: table => new
                {
                    schemeId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    system = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    systemCompanyId = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    systemUniqueId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customerGroupId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    primaryEmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    pinNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    currencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    partyType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    primaryPhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    addressDefaultRoles = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    addressCountryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    billGroupCombinedCollection = table.Column<bool>(type: "bit", nullable: false),
                    brokerCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isBillGroup = table.Column<bool>(type: "bit", nullable: false),
                    billGroupNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    billGroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    brokerCombinedCollection = table.Column<bool>(type: "bit", nullable: false),
                    customerBankAccountHolder = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    customerBankAccountNumber = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    customerBankBranchCode = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    customerBankName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    customerCellularAccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    customerExternalMethodOfPayment = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    iBanNo = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: true),
                    addressDescription = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbound_Mimo_Customer", x => x.schemeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inbound_Mimo_Customer");
        }
    }
}
