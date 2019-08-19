using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class addactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "SentMessages",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "ReceiverCategories",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "ReceiverCategories",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "MessageServiceProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "MessageServiceProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "MessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "MessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "MessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "MessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "EmployeeTitles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "EmployeeTitles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Employees",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Distributors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Distributors",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Departments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Customers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "Businesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "Businesses",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "AutoMessageConfigs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "AutoMessageConfigs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRemoved",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemovedById",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_RemovedById",
                table: "SentMessages",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_RemovedById",
                table: "ReceiverProviders",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverCategories_RemovedById",
                table: "ReceiverCategories",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_People_RemovedById",
                table: "People",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageServiceProviders_RemovedById",
                table: "MessageServiceProviders",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_RemovedById",
                table: "MessageReceivers",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroups_RemovedById",
                table: "MessageReceiverGroups",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_RemovedById",
                table: "MessageReceiverGroupMessageReceivers",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTitles_RemovedById",
                table: "EmployeeTitles",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RemovedById",
                table: "Employees",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_RemovedById",
                table: "Distributors",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_RemovedById",
                table: "Departments",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_RemovedById",
                table: "Customers",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_RemovedById",
                table: "Countries",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_RemovedById",
                table: "Businesses",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_RemovedById",
                table: "AutoMessageConfigs",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_RemovedById",
                table: "AutoMessageConfigProviders",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "RemovedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_RemovedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "RemovedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_RemovedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AspNetUsers_RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigProviders_AspNetUsers_RemovedById",
                table: "AutoMessageConfigProviders",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigs_AspNetUsers_RemovedById",
                table: "AutoMessageConfigs",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_RemovedById",
                table: "Businesses",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AspNetUsers_RemovedById",
                table: "Countries",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_RemovedById",
                table: "Customers",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_AspNetUsers_RemovedById",
                table: "Departments",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Distributors_AspNetUsers_RemovedById",
                table: "Distributors",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_RemovedById",
                table: "Employees",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeTitles_AspNetUsers_RemovedById",
                table: "EmployeeTitles",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_AspNetUsers_RemovedById",
                table: "MessageReceiverGroupMessageReceivers",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiverGroups_AspNetUsers_RemovedById",
                table: "MessageReceiverGroups",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_AspNetUsers_RemovedById",
                table: "MessageReceivers",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageServiceProviders_AspNetUsers_RemovedById",
                table: "MessageServiceProviders",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AspNetUsers_RemovedById",
                table: "People",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiverCategories_AspNetUsers_RemovedById",
                table: "ReceiverCategories",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiverProviders_AspNetUsers_RemovedById",
                table: "ReceiverProviders",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_AspNetUsers_RemovedById",
                table: "SentMessages",
                column: "RemovedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_RemovedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AspNetUsers_RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigProviders_AspNetUsers_RemovedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigs_AspNetUsers_RemovedById",
                table: "AutoMessageConfigs");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_RemovedById",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_RemovedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_RemovedById",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_RemovedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Distributors_AspNetUsers_RemovedById",
                table: "Distributors");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_RemovedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTitles_AspNetUsers_RemovedById",
                table: "EmployeeTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_AspNetUsers_RemovedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceiverGroups_AspNetUsers_RemovedById",
                table: "MessageReceiverGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_AspNetUsers_RemovedById",
                table: "MessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageServiceProviders_AspNetUsers_RemovedById",
                table: "MessageServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AspNetUsers_RemovedById",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiverCategories_AspNetUsers_RemovedById",
                table: "ReceiverCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiverProviders_AspNetUsers_RemovedById",
                table: "ReceiverProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_AspNetUsers_RemovedById",
                table: "SentMessages");

            migrationBuilder.DropIndex(
                name: "IX_SentMessages_RemovedById",
                table: "SentMessages");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_RemovedById",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverCategories_RemovedById",
                table: "ReceiverCategories");

            migrationBuilder.DropIndex(
                name: "IX_People_RemovedById",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_MessageServiceProviders_RemovedById",
                table: "MessageServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceivers_RemovedById",
                table: "MessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroups_RemovedById",
                table: "MessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_RemovedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeTitles_RemovedById",
                table: "EmployeeTitles");

            migrationBuilder.DropIndex(
                name: "IX_Employees_RemovedById",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_RemovedById",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_RemovedById",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_RemovedById",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Countries_RemovedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_RemovedById",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigs_RemovedById",
                table: "AutoMessageConfigs");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_RemovedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_RemovedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "SentMessages");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "ReceiverCategories");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "ReceiverCategories");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "People");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "People");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "MessageServiceProviders");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "MessageServiceProviders");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "MessageReceivers");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "MessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "MessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "MessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "EmployeeTitles");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "EmployeeTitles");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Distributors");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateRemoved",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "RemovedById",
                table: "AutoMesasgeConfigMessageReceivers");
        }
    }
}
