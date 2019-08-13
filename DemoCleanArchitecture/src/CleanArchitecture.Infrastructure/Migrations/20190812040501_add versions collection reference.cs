using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class addversionscollectionreference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                table: "SentMessages");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverProviders",
                table: "ReceiverProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageReceiverGroupMessageReceivers",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMessageConfigProviders",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMessageConfigMessageReceiverGroups",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMesasgeConfigMessageReceivers",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.RenameColumn(
                name: "AutoMessageConfigDetailsId",
                table: "SentMessages",
                newName: "AutoMessageConfigId");

            migrationBuilder.RenameIndex(
                name: "IX_SentMessages_AutoMessageConfigDetailsId",
                table: "SentMessages",
                newName: "IX_SentMessages_AutoMessageConfigId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ReceiverProviders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "ReceiverProviders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "ReceiverProviders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "ReceiverProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "MessageReceiverGroupMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Countries",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Countries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Businesses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "AutoMessageConfigs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "AutoMessageConfigs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AutoMessageConfigs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "AutoMessageConfigs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AutoMessageConfigProviders",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AutoMessageConfigProviders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "AutoMessageConfigProviders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "AutoMessageConfigProviders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "AutoMessageConfigMessageReceiverGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEffective",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateReplaced",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DiscriptionNote",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "AutoMesasgeConfigMessageReceivers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverProviders",
                table: "ReceiverProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageReceiverGroupMessageReceivers",
                table: "MessageReceiverGroupMessageReceivers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMessageConfigProviders",
                table: "AutoMessageConfigProviders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMessageConfigMessageReceiverGroups",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMesasgeConfigMessageReceivers",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_CreatedById",
                table: "ReceiverProviders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_DateEffective",
                table: "ReceiverProviders",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_DateEnd",
                table: "ReceiverProviders",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_MessageReceiverId",
                table: "ReceiverProviders",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_OriginId",
                table: "ReceiverProviders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverCategories_DateEffective",
                table: "ReceiverCategories",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverCategories_DateEnd",
                table: "ReceiverCategories",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverCategories_OriginId",
                table: "ReceiverCategories",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CreatedById",
                table: "People",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_People_DateEffective",
                table: "People",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_People_DateEnd",
                table: "People",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_People_OriginId",
                table: "People",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageServiceProviders_DateEffective",
                table: "MessageServiceProviders",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_MessageServiceProviders_DateEnd",
                table: "MessageServiceProviders",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_MessageServiceProviders_OriginId",
                table: "MessageServiceProviders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_DateEffective",
                table: "MessageReceivers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_DateEnd",
                table: "MessageReceivers",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_OriginId",
                table: "MessageReceivers",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroups_DateEffective",
                table: "MessageReceiverGroups",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroups_DateEnd",
                table: "MessageReceiverGroups",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroups_OriginId",
                table: "MessageReceiverGroups",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_CreatedById",
                table: "MessageReceiverGroupMessageReceivers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_DateEffective",
                table: "MessageReceiverGroupMessageReceivers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_DateEnd",
                table: "MessageReceiverGroupMessageReceivers",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_MessageReceiverGroupId",
                table: "MessageReceiverGroupMessageReceivers",
                column: "MessageReceiverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_OriginId",
                table: "MessageReceiverGroupMessageReceivers",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_DateEffective",
                table: "Distributors",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_DateEnd",
                table: "Distributors",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DateEffective",
                table: "Departments",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DateEnd",
                table: "Departments",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DateEffective",
                table: "Customers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DateEnd",
                table: "Customers",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CreatedById",
                table: "Businesses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DateEffective",
                table: "Businesses",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_DateEnd",
                table: "Businesses",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_OriginId",
                table: "Businesses",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_DateEffective",
                table: "AutoMessageConfigs",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_DateEnd",
                table: "AutoMessageConfigs",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_AutoMessageConfigId",
                table: "AutoMessageConfigProviders",
                column: "AutoMessageConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_CreatedById",
                table: "AutoMessageConfigProviders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_DateEffective",
                table: "AutoMessageConfigProviders",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_DateEnd",
                table: "AutoMessageConfigProviders",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_OriginId",
                table: "AutoMessageConfigProviders",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_AutoMessageConfigId",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "AutoMessageConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_DateEffective",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_DateEnd",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_OriginId",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_CreatedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEffective",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "DateEffective");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEnd",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "DateEnd");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_MessageReceiverId",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_OriginId",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_CreatedById",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AutoMesasgeConfigMessageReceivers_OriginId",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "OriginId",
                principalTable: "AutoMesasgeConfigMessageReceivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AspNetUsers_CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AutoMessageConfigMessageReceiverGroups_OriginId",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "OriginId",
                principalTable: "AutoMessageConfigMessageReceiverGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigProviders_AspNetUsers_CreatedById",
                table: "AutoMessageConfigProviders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AutoMessageConfigProviders_AutoMessageConfigProviders_OriginId",
                table: "AutoMessageConfigProviders",
                column: "OriginId",
                principalTable: "AutoMessageConfigProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_AspNetUsers_CreatedById",
                table: "Businesses",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Businesses_Businesses_OriginId",
                table: "Businesses",
                column: "OriginId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_AspNetUsers_CreatedById",
                table: "Countries",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_AspNetUsers_CreatedById",
                table: "MessageReceiverGroupMessageReceivers",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_MessageReceiverGroupMessageReceivers_OriginId",
                table: "MessageReceiverGroupMessageReceivers",
                column: "OriginId",
                principalTable: "MessageReceiverGroupMessageReceivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceiverGroups_MessageReceiverGroups_OriginId",
                table: "MessageReceiverGroups",
                column: "OriginId",
                principalTable: "MessageReceiverGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_MessageReceivers_OriginId",
                table: "MessageReceivers",
                column: "OriginId",
                principalTable: "MessageReceivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageServiceProviders_MessageServiceProviders_OriginId",
                table: "MessageServiceProviders",
                column: "OriginId",
                principalTable: "MessageServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_AspNetUsers_CreatedById",
                table: "People",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_OriginId",
                table: "People",
                column: "OriginId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiverCategories_ReceiverCategories_OriginId",
                table: "ReceiverCategories",
                column: "OriginId",
                principalTable: "ReceiverCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiverProviders_AspNetUsers_CreatedById",
                table: "ReceiverProviders",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiverProviders_ReceiverProviders_OriginId",
                table: "ReceiverProviders",
                column: "OriginId",
                principalTable: "ReceiverProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_AutoMessageConfigs_AutoMessageConfigId",
                table: "SentMessages",
                column: "AutoMessageConfigId",
                principalTable: "AutoMessageConfigs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AspNetUsers_CreatedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMesasgeConfigMessageReceivers_AutoMesasgeConfigMessageReceivers_OriginId",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AspNetUsers_CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigMessageReceiverGroups_AutoMessageConfigMessageReceiverGroups_OriginId",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigProviders_AspNetUsers_CreatedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_AutoMessageConfigProviders_AutoMessageConfigProviders_OriginId",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_AspNetUsers_CreatedById",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Businesses_Businesses_OriginId",
                table: "Businesses");

            migrationBuilder.DropForeignKey(
                name: "FK_Countries_AspNetUsers_CreatedById",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_AspNetUsers_CreatedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceiverGroupMessageReceivers_MessageReceiverGroupMessageReceivers_OriginId",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceiverGroups_MessageReceiverGroups_OriginId",
                table: "MessageReceiverGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_MessageReceivers_OriginId",
                table: "MessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageServiceProviders_MessageServiceProviders_OriginId",
                table: "MessageServiceProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_People_AspNetUsers_CreatedById",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_People_People_OriginId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiverCategories_ReceiverCategories_OriginId",
                table: "ReceiverCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiverProviders_AspNetUsers_CreatedById",
                table: "ReceiverProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiverProviders_ReceiverProviders_OriginId",
                table: "ReceiverProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_SentMessages_AutoMessageConfigs_AutoMessageConfigId",
                table: "SentMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverProviders",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_CreatedById",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_DateEffective",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_DateEnd",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_MessageReceiverId",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverProviders_OriginId",
                table: "ReceiverProviders");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverCategories_DateEffective",
                table: "ReceiverCategories");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverCategories_DateEnd",
                table: "ReceiverCategories");

            migrationBuilder.DropIndex(
                name: "IX_ReceiverCategories_OriginId",
                table: "ReceiverCategories");

            migrationBuilder.DropIndex(
                name: "IX_People_CreatedById",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DateEffective",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_DateEnd",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_OriginId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_MessageServiceProviders_DateEffective",
                table: "MessageServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_MessageServiceProviders_DateEnd",
                table: "MessageServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_MessageServiceProviders_OriginId",
                table: "MessageServiceProviders");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceivers_DateEffective",
                table: "MessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceivers_DateEnd",
                table: "MessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceivers_OriginId",
                table: "MessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroups_DateEffective",
                table: "MessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroups_DateEnd",
                table: "MessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroups_OriginId",
                table: "MessageReceiverGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MessageReceiverGroupMessageReceivers",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_CreatedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_DateEffective",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_DateEnd",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_MessageReceiverGroupId",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_OriginId",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEffective",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DateEnd",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_DateEffective",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Distributors_DateEnd",
                table: "Distributors");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DateEffective",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DateEnd",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DateEffective",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DateEnd",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_CreatedById",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_DateEffective",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_DateEnd",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_OriginId",
                table: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigs_DateEffective",
                table: "AutoMessageConfigs");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigs_DateEnd",
                table: "AutoMessageConfigs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMessageConfigProviders",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_AutoMessageConfigId",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_CreatedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_DateEffective",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_DateEnd",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigProviders_OriginId",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMessageConfigMessageReceiverGroups",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_AutoMessageConfigId",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_DateEffective",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_DateEnd",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_OriginId",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AutoMesasgeConfigMessageReceivers",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_CreatedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEffective",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_DateEnd",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_MessageReceiverId",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_OriginId",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "ReceiverProviders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "AutoMessageConfigs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "AutoMessageConfigProviders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateEffective",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DateReplaced",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "DiscriptionNote",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.RenameColumn(
                name: "AutoMessageConfigId",
                table: "SentMessages",
                newName: "AutoMessageConfigDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_SentMessages_AutoMessageConfigId",
                table: "SentMessages",
                newName: "IX_SentMessages_AutoMessageConfigDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverProviders",
                table: "ReceiverProviders",
                columns: new[] { "MessageReceiverId", "MessageServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MessageReceiverGroupMessageReceivers",
                table: "MessageReceiverGroupMessageReceivers",
                columns: new[] { "MessageReceiverGroupId", "MessageReceiverId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMessageConfigProviders",
                table: "AutoMessageConfigProviders",
                columns: new[] { "AutoMessageConfigId", "MessageServiceProviderId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMessageConfigMessageReceiverGroups",
                table: "AutoMessageConfigMessageReceiverGroups",
                columns: new[] { "AutoMessageConfigId", "MessageReceiverGroupId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AutoMesasgeConfigMessageReceivers",
                table: "AutoMesasgeConfigMessageReceivers",
                columns: new[] { "MessageReceiverId", "AutoMessageConfigId" });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Period = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetails_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetails_AutoMessageConfigs_OriginId",
                        column: x => x.OriginId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_CreatedById",
                table: "AutoMessageConfigDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_OriginId",
                table: "AutoMessageConfigDetails",
                column: "OriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_SentMessages_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                table: "SentMessages",
                column: "AutoMessageConfigDetailsId",
                principalTable: "AutoMessageConfigDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
