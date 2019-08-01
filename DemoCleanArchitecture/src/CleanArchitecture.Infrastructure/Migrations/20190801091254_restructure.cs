using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class restructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    BusinessIdentityNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    TaxNumber = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Businesses_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    IdentityNumber = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DisplayName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigs_AutoMessageConfigs_OriginId",
                        column: x => x.OriginId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Distributors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Distributors_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Distributors_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Distributors_Distributors_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTitles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTitles_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceiverGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceiverGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageReceiverGroups_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    AddressRegex = table.Column<string>(nullable: true),
                    AddressLabel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageServiceProviders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageServiceProviders_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiverCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiverCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Period = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true),
                    BusinessId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    DistributorId = table.Column<int>(nullable: true),
                    CoordinateX = table.Column<float>(nullable: true),
                    CoordinateY = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Distributors_DistributorId",
                        column: x => x.DistributorId,
                        principalTable: "Distributors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_Customers_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigMessageReceiverGroups",
                columns: table => new
                {
                    AutoMessageConfigId = table.Column<int>(nullable: false),
                    MessageReceiverGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigMessageReceiverGroups", x => new { x.AutoMessageConfigId, x.MessageReceiverGroupId });
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigMessageReceiverGroups_AutoMessageConfigs_AutoMessageConfigId",
                        column: x => x.AutoMessageConfigId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigMessageReceiverGroups_MessageReceiverGroups_MessageReceiverGroupId",
                        column: x => x.MessageReceiverGroupId,
                        principalTable: "MessageReceiverGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoMessageConfigProviders",
                columns: table => new
                {
                    AutoMessageConfigId = table.Column<int>(nullable: false),
                    MessageServiceProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMessageConfigProviders", x => new { x.AutoMessageConfigId, x.MessageServiceProviderId });
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigProviders_AutoMessageConfigs_AutoMessageConfigId",
                        column: x => x.AutoMessageConfigId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMessageConfigProviders_MessageServiceProviders_MessageServiceProviderId",
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
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    AutoMessageConfigDetailsId = table.Column<int>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    ReceiveTime = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ReceiverProviderId = table.Column<int>(nullable: false)
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
                        name: "FK_SentMessages_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Location2 = table.Column<string>(nullable: true),
                    Location3 = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Phone3 = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    ManagerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departments_Departments_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: true),
                    EmployeeTitleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTitles_EmployeeTitleId",
                        column: x => x.EmployeeTitleId,
                        principalTable: "EmployeeTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MessageReceivers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    CreatedById = table.Column<string>(nullable: true),
                    DateEffective = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    DateReplaced = table.Column<DateTime>(nullable: true),
                    DiscriptionNote = table.Column<string>(nullable: true),
                    OriginId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    ReceiverCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReceivers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageReceivers_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageReceivers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageReceivers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MessageReceivers_ReceiverCategories_ReceiverCategoryId",
                        column: x => x.ReceiverCategoryId,
                        principalTable: "ReceiverCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoMesasgeConfigMessageReceivers",
                columns: table => new
                {
                    MessageReceiverId = table.Column<int>(nullable: false),
                    AutoMessageConfigId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoMesasgeConfigMessageReceivers", x => new { x.MessageReceiverId, x.AutoMessageConfigId });
                    table.ForeignKey(
                        name: "FK_AutoMesasgeConfigMessageReceivers_AutoMessageConfigs_AutoMessageConfigId",
                        column: x => x.AutoMessageConfigId,
                        principalTable: "AutoMessageConfigs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoMesasgeConfigMessageReceivers_MessageReceivers_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "MessageReceivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ReceiverAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiverProviders", x => new { x.MessageReceiverId, x.MessageServiceProviderId });
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_BusinessId",
                table: "AspNetUsers",
                column: "BusinessId",
                unique: true,
                filter: "[BusinessId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PersonId",
                table: "AspNetUsers",
                column: "PersonId",
                unique: true,
                filter: "[PersonId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMesasgeConfigMessageReceivers_AutoMessageConfigId",
                table: "AutoMesasgeConfigMessageReceivers",
                column: "AutoMessageConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_CreatedById",
                table: "AutoMessageConfigDetails",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigDetails_OriginId",
                table: "AutoMessageConfigDetails",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigMessageReceiverGroups_MessageReceiverGroupId",
                table: "AutoMessageConfigMessageReceiverGroups",
                column: "MessageReceiverGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigProviders_MessageServiceProviderId",
                table: "AutoMessageConfigProviders",
                column: "MessageServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_CreatedById",
                table: "AutoMessageConfigs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AutoMessageConfigs_OriginId",
                table: "AutoMessageConfigs",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_CountryId",
                table: "Businesses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BusinessId",
                table: "Customers",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Code",
                table: "Customers",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CreatedById",
                table: "Customers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DistributorId",
                table: "Customers",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_OriginId",
                table: "Customers",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_PersonId",
                table: "Customers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedById",
                table: "Departments",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ManagerId",
                table: "Departments",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_OriginId",
                table: "Departments",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_ParentId",
                table: "Departments",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_Code",
                table: "Distributors",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_CountryId",
                table: "Distributors",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_CreatedById",
                table: "Distributors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Distributors_OriginId",
                table: "Distributors",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedById",
                table: "Employees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTitleId",
                table: "Employees",
                column: "EmployeeTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OriginId",
                table: "Employees",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PersonId",
                table: "Employees",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTitles_CreatedById",
                table: "EmployeeTitles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroupMessageReceivers_MessageReceiverId",
                table: "MessageReceiverGroupMessageReceivers",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceiverGroups_CreatedById",
                table: "MessageReceiverGroups",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_CreatedById",
                table: "MessageReceivers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_CustomerId",
                table: "MessageReceivers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_EmployeeId",
                table: "MessageReceivers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageReceivers_ReceiverCategoryId",
                table: "MessageReceivers",
                column: "ReceiverCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageServiceProviders_CreatedById",
                table: "MessageServiceProviders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_People_CountryId",
                table: "People",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverCategories_CreatedById",
                table: "ReceiverCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiverProviders_MessageServiceProviderId",
                table: "ReceiverProviders",
                column: "MessageServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_AutoMessageConfigDetailsId",
                table: "SentMessages",
                column: "AutoMessageConfigDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_SentMessages_CreatedById",
                table: "SentMessages",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments",
                column: "ManagerId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_AspNetUsers_CreatedById",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_CreatedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeTitles_AspNetUsers_CreatedById",
                table: "EmployeeTitles");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_People_PersonId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_ManagerId",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AutoMesasgeConfigMessageReceivers");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigMessageReceiverGroups");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigProviders");

            migrationBuilder.DropTable(
                name: "MessageReceiverGroupMessageReceivers");

            migrationBuilder.DropTable(
                name: "ReceiverProviders");

            migrationBuilder.DropTable(
                name: "SentMessages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MessageReceiverGroups");

            migrationBuilder.DropTable(
                name: "MessageReceivers");

            migrationBuilder.DropTable(
                name: "MessageServiceProviders");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigDetails");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ReceiverCategories");

            migrationBuilder.DropTable(
                name: "AutoMessageConfigs");

            migrationBuilder.DropTable(
                name: "Distributors");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EmployeeTitles");
        }
    }
}
