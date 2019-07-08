using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class addmessagemodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_Customer_CustomerId",
                table: "MessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_ReceiverCategory_ReceiverCategoryId",
                table: "MessageReceivers");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverCategory",
                table: "ReceiverCategory");

            migrationBuilder.RenameTable(
                name: "ReceiverCategory",
                newName: "ReceiverCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverCategories",
                table: "ReceiverCategories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigs_Employees_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceiverGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiverGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessageServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AutoMessageConfigId = table.Column<int>(nullable: false),
                    Period = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    VersionNumber = table.Column<int>(nullable: false),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetails_AutoMessageConfigs_AutoMessageConfigId",
                        column: x => x.AutoMessageConfigId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetails_Employees_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    Shortname = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    DistributorId = table.Column<int>(nullable: true),
                    DistributorCode = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ModifiedTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceiverGroupMessageReceivers",
                columns: table => new
                {
                    MessageReceiverId = table.Column<int>(nullable: false),
                    MessageReceiverGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiverGroupMessageReceivers", x => new { x.MessageReceiverGroupId, x.MessageReceiverId });
                    table.ForeignKey(
                        name: "FK_MessageReceiverGroupMessageReceivers_MessageReceiverGroups_MessageReceiverGroupId",
                        column: x => x.MessageReceiverGroupId,
                        principalTable: "MessageReceiverGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MessageReceiverGroupMessageReceivers_MessageReceivers_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "MessageReceivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverProviders",
                columns: table => new
                {
                    MessageReceiverId = table.Column<int>(nullable: false),
                    MessageServiceProviderId = table.Column<int>(nullable: false),
                    ReceiverAddress = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverProviders", x => new { x.MessageServiceProviderId, x.MessageReceiverId });
                    table.ForeignKey(
                        name: "FK_ReceiverProviders_MessageReceivers_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "MessageReceivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiverProviders_MessageServiceProviders_MessageServiceProviderId",
                        column: x => x.MessageServiceProviderId,
                        principalTable: "MessageServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMesasgeConfigDetailsMessageReceivers",
                columns: table => new
                {
                    MessageReceiverId = table.Column<int>(nullable: false),
                    AutoMessageConfigDetailsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMesasgeConfigDetailsMessageReceivers", x => new { x.MessageReceiverId, x.AutoMessageConfigDetailsId });
                    table.ForeignKey(
                        name: "FK_AutoMesasgeConfigDetailsMessageReceivers_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                        column: x => x.AutoMessageConfigDetailsId,
                        principalTable: "AutoMessageConfigDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMesasgeConfigDetailsMessageReceivers_MessageReceivers_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "MessageReceivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigDetailsMessageReceiverGroups",
                columns: table => new
                {
                    AutoMessageConfigDetailsId = table.Column<int>(nullable: false),
                    MessageReceiverGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigDetailsMessageReceiverGroups", x => new { x.AutoMessageConfigDetailsId, x.MessageReceiverGroupId });
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetailsMessageReceiverGroups_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                        column: x => x.AutoMessageConfigDetailsId,
                        principalTable: "AutoMessageConfigDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetailsMessageReceiverGroups_MessageReceiverGroups_MessageReceiverGroupId",
                        column: x => x.MessageReceiverGroupId,
                        principalTable: "MessageReceiverGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigDetailsProviders",
                columns: table => new
                {
                    AutoMessageConfigDetailsId = table.Column<int>(nullable: false),
                    MessageServiceProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigDetailsProviders", x => new { x.AutoMessageConfigDetailsId, x.MessageServiceProviderId });
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetailsProviders_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                        column: x => x.AutoMessageConfigDetailsId,
                        principalTable: "AutoMessageConfigDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigDetailsProviders_MessageServiceProviders_MessageServiceProviderId",
                        column: x => x.MessageServiceProviderId,
                        principalTable: "MessageServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SentMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: true),
                    AutoMessageConfigDetailsId = table.Column<int>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    ReceiveTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ReceiverProviderId = table.Column<int>(nullable: false),
                    ReceiverProviderMessageServiceProviderId = table.Column<int>(nullable: true),
                    ReceiverProviderMessageReceiverId = table.Column<int>(nullable: true),
                    SentBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SentMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SentMessages_AutoMessageConfigDetails_AutoMessageConfigDetailsId",
                        column: x => x.AutoMessageConfigDetailsId,
                        principalTable: "AutoMessageConfigDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SentMessages_ReceiverProviders_ReceiverProviderMessageServiceProviderId_ReceiverProviderMessageReceiverId",
                        columns: x => new { x.ReceiverProviderMessageServiceProviderId, x.ReceiverProviderMessageReceiverId },
                        principalTable: "ReceiverProviders",
                        principalColumns: new[] { "MessageServiceProviderId", "MessageReceiverId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigDetailsMessageReceivers_AutoMessageConfigDetailsId",
                table: "AutoMesasgeConfigDetailsMessageReceivers",
                column: "AutoMessageConfigDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_AutoMessageConfigId",
                table: "AutoMessageConfigDetails",
                column: "AutoMessageConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_CreatedById",
                table: "AutoMessageConfigDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetailsMessageReceiverGroups_MessageReceiverGroupId",
                table: "AutoMessageConfigDetailsMessageReceiverGroups",
                column: "MessageReceiverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetailsProviders_MessageServiceProviderId",
                table: "AutoMessageConfigDetailsProviders",
                column: "MessageServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_CreatedById",
                table: "AutoMessageConfigs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DistributorId",
                table: "Customers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_MessageReceiverId",
                table: "MessageReceiverGroupMessageReceivers",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_MessageReceiverId",
                table: "ReceiverProviders",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_AutoMessageConfigDetailsId",
                table: "SentMessages",
                column: "AutoMessageConfigDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_ReceiverProviderMessageServiceProviderId_ReceiverProviderMessageReceiverId",
                table: "SentMessages",
                columns: new[] { "ReceiverProviderMessageServiceProviderId", "ReceiverProviderMessageReceiverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_Customers_CustomerId",
                table: "MessageReceivers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_ReceiverCategories_ReceiverCategoryId",
                table: "MessageReceivers",
                column: "ReceiverCategoryId",
                principalTable: "ReceiverCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_Customers_CustomerId",
                table: "MessageReceivers");

            migrationBuilder.DropForeignKey(
                name: "FK_MessageReceivers_ReceiverCategories_ReceiverCategoryId",
                table: "MessageReceivers");

            migrationBuilder.DropTable(
                name: "AutoMesasgeConfigDetailsMessageReceivers");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigDetailsMessageReceiverGroups");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigDetailsProviders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropTable(
                name: "SentMessages");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "MessageReceiverGroups");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigDetails");

            migrationBuilder.DropTable(
                name: "ReceiverProviders");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigs");

            migrationBuilder.DropTable(
                name: "MessageServiceProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReceiverCategories",
                table: "ReceiverCategories");

            migrationBuilder.RenameTable(
                name: "ReceiverCategories",
                newName: "ReceiverCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReceiverCategory",
                table: "ReceiverCategory",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    DistributorCode = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    ModifiedTime = table.Column<DateTime>(nullable: false),
                    Owner = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Receiver = table.Column<string>(nullable: true),
                    Shortname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_Customer_CustomerId",
                table: "MessageReceivers",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MessageReceivers_ReceiverCategory_ReceiverCategoryId",
                table: "MessageReceivers",
                column: "ReceiverCategoryId",
                principalTable: "ReceiverCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
