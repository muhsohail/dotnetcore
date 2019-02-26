using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.EntityFramework.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ActionName = table.Column<string>(nullable: true),
                    LogType = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
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
                    Name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    PrimaryPhone = table.Column<string>(nullable: false),
                    SecondaryPhone = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    EmergencyPhone = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    RegionNo = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TempAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SessionId = table.Column<string>(maxLength: 100, nullable: true),
                    ApplicationTypeId = table.Column<int>(nullable: true),
                    AttachmentTypeId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(maxLength: 200, nullable: true),
                    Path = table.Column<string>(maxLength: 500, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    TransactionId = table.Column<int>(nullable: true),
                    FileType = table.Column<int>(nullable: true),
                    StreamId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempAttachment", x => x.Id);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Fabrics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FabricTypeId = table.Column<Guid>(nullable: true),
                    FabricCodeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fabrics_FabricCodes_FabricCodeId",
                        column: x => x.FabricCodeId,
                        principalTable: "FabricCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Fabrics_FabricTypes_FabricTypeId",
                        column: x => x.FabricTypeId,
                        principalTable: "FabricTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ActionButtons",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ButtonText = table.Column<string>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionButtons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionButtons_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductRate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AskingRate = table.Column<double>(nullable: false),
                    MinimumRate = table.Column<double>(nullable: false),
                    MaximumRate = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FabricId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRate_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Mills",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MDId = table.Column<Guid>(nullable: false),
                    MangerId = table.Column<Guid>(nullable: false),
                    CPMId = table.Column<Guid>(nullable: false),
                    MechanicalId = table.Column<Guid>(nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mills_Person_CPMId",
                        column: x => x.CPMId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mills_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mills_Person_MDId",
                        column: x => x.MDId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mills_Person_MangerId",
                        column: x => x.MangerId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Mills_Person_MechanicalId",
                        column: x => x.MechanicalId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsignmentOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    OrderComments = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    BarCode = table.Column<string>(nullable: true),
                    MillId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsignmentOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsignmentOrders_Mills_MillId",
                        column: x => x.MillId,
                        principalTable: "Mills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsignmentOrders_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsignmentOrders_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DailyStocks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Width = table.Column<decimal>(nullable: false),
                    WidthInches = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    GSM = table.Column<string>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    WTOnePiece = table.Column<double>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Code = table.Column<double>(nullable: false),
                    TTLWT = table.Column<double>(nullable: false),
                    AskingRate = table.Column<double>(nullable: false),
                    VarianceInWidth = table.Column<string>(nullable: false),
                    VarianceInLength = table.Column<string>(nullable: false),
                    VarianceInGSM = table.Column<string>(nullable: false),
                    FabricId = table.Column<Guid>(nullable: false),
                    MillId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyStocks_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DailyStocks_Mills_MillId",
                        column: x => x.MillId,
                        principalTable: "Mills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    GSM = table.Column<string>(nullable: true),
                    SM = table.Column<double>(nullable: false),
                    AmountEachPiece = table.Column<double>(nullable: false),
                    ConsPcsYear = table.Column<int>(nullable: false),
                    ConsAmtYear = table.Column<int>(nullable: false),
                    NextOrder = table.Column<int>(nullable: false),
                    NextOrderCount = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    FabricId = table.Column<Guid>(nullable: true),
                    MillId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_Mills_MillId",
                        column: x => x.MillId,
                        principalTable: "Mills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Order_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PaperMillProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TotalAmount = table.Column<double>(nullable: true),
                    TotalPCSCount = table.Column<double>(nullable: true),
                    TotalConsAmtPerYear = table.Column<double>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    MillId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperMillProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperMillProfile_Mills_MillId",
                        column: x => x.MillId,
                        principalTable: "Mills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaperMillProfile_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Receivables",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    ReceiveableUpToDate = table.Column<double>(nullable: false),
                    AmounntReceiveable = table.Column<double>(nullable: true),
                    PersonReceivable = table.Column<string>(nullable: true),
                    DirectNumber = table.Column<string>(nullable: true),
                    CurrentLessThen30Days = table.Column<double>(nullable: false),
                    Rec31To60 = table.Column<double>(nullable: false),
                    Rec61To90 = table.Column<double>(nullable: false),
                    Rec90Plus = table.Column<double>(nullable: false),
                    AlmostDead = table.Column<double>(nullable: false),
                    PotentialAnnual = table.Column<double>(nullable: false),
                    Sale2k16 = table.Column<double>(nullable: false),
                    Sale2k17 = table.Column<double>(nullable: false),
                    Sale2K18 = table.Column<double>(nullable: false),
                    Width = table.Column<int>(nullable: false),
                    MechanicalData = table.Column<string>(nullable: true),
                    Drawing = table.Column<string>(nullable: true),
                    NextAction = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    MillId = table.Column<Guid>(nullable: true),
                    CPMId = table.Column<Guid>(nullable: true),
                    RegionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receivables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receivables_Person_CPMId",
                        column: x => x.CPMId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Receivables_Mills_MillId",
                        column: x => x.MillId,
                        principalTable: "Mills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Receivables_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ConsignmentOrderItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FabricTitle = table.Column<string>(nullable: true),
                    Width = table.Column<decimal>(nullable: false),
                    Length = table.Column<decimal>(nullable: false),
                    GSM = table.Column<string>(nullable: true),
                    QtyJ = table.Column<int>(nullable: false),
                    QtyIJ = table.Column<int>(nullable: false),
                    QtyWMA = table.Column<int>(nullable: false),
                    WT = table.Column<int>(nullable: false),
                    FormatReference = table.Column<string>(nullable: true),
                    LayerType = table.Column<string>(nullable: true),
                    PaperType = table.Column<string>(nullable: true),
                    BarCode = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    FabricType = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FabricId = table.Column<Guid>(nullable: true),
                    ConsignmentOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsignmentOrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsignmentOrderItem_ConsignmentOrders_ConsignmentOrderId",
                        column: x => x.ConsignmentOrderId,
                        principalTable: "ConsignmentOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ConsignmentOrderItem_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OrderComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    StatusId = table.Column<Guid>(nullable: true),
                    ConsignmentOrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderComments_ConsignmentOrders_ConsignmentOrderId",
                        column: x => x.ConsignmentOrderId,
                        principalTable: "ConsignmentOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OrderComments_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PaperMillProfileDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Width = table.Column<decimal>(nullable: false),
                    Witln = table.Column<decimal>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    GSM = table.Column<string>(nullable: true),
                    SM = table.Column<double>(nullable: false),
                    AmountEachPiece = table.Column<double>(nullable: false),
                    ConsPcsYear = table.Column<int>(nullable: false),
                    ConsAmtYear = table.Column<double>(nullable: false),
                    NextOrder = table.Column<int>(nullable: false),
                    NextOrderCount = table.Column<double>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FabricId = table.Column<Guid>(nullable: true),
                    PaperMillProfileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperMillProfileDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperMillProfileDetail_Fabrics_FabricId",
                        column: x => x.FabricId,
                        principalTable: "Fabrics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PaperMillProfileDetail_PaperMillProfile_PaperMillProfileId",
                        column: x => x.PaperMillProfileId,
                        principalTable: "PaperMillProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION_ATTACHMENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATT_ATTACHMENT_NAME_AR = table.Column<string>(maxLength: 150, nullable: true),
                    ATT_ATTACHMENT_NAME_EN = table.Column<string>(maxLength: 150, nullable: true),
                    ATT_ATTAHCMENT_MANDATORY = table.Column<bool>(nullable: true),
                    TA_Creation_Date = table.Column<DateTime>(nullable: true),
                    ATT_REF = table.Column<string>(nullable: true),
                    ATT_UPLOADED = table.Column<bool>(nullable: false),
                    ATT_SIZE = table.Column<double>(nullable: true),
                    ATT_VER_NO = table.Column<int>(nullable: true),
                    ATTACHMENT_ID = table.Column<int>(nullable: false),
                    TRANSACTION_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION_ATTACHMENT", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION_TYPE",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TTP_TYPE_NAME_AR = table.Column<string>(maxLength: 100, nullable: false),
                    TTP_TYPE_NAME_EN = table.Column<string>(maxLength: 100, nullable: false),
                    TTP_DEFAULT_DURATION = table.Column<int>(nullable: true),
                    TTP_IS_DELETED = table.Column<bool>(nullable: true),
                    TTP_TRANSACTION_TYPE_FORM = table.Column<int>(nullable: true),
                    TTP_DELETE_COMMENT = table.Column<string>(nullable: true),
                    TTP_IS_PUBLISHED = table.Column<bool>(nullable: true),
                    TTP_ALLOW_OTHER_ATTACHMENTS = table.Column<bool>(nullable: true),
                    TTP_FORM_BUILDER_ACTIVE = table.Column<bool>(nullable: true),
                    TTP_FORM_BUILDER_DLL_PATH = table.Column<string>(maxLength: 1000, nullable: true),
                    TTP_FORM_BUILDER_TABLE_NAME = table.Column<string>(maxLength: 500, nullable: true),
                    TTP_PRICE = table.Column<decimal>(nullable: true),
                    Schema_Code = table.Column<string>(maxLength: 150, nullable: true),
                    TTP_TYPE_DESC_EN = table.Column<string>(maxLength: 4000, nullable: true),
                    TTP_TYPE_DESC_AR = table.Column<string>(maxLength: 4000, nullable: true),
                    TTP_TEMPLATE_ID = table.Column<int>(nullable: true),
                    TTP_NEED_CLIENT = table.Column<bool>(nullable: true),
                    TTP_CATEGORY_ID = table.Column<int>(nullable: true),
                    TTP_SERVICE_CODE = table.Column<string>(maxLength: 50, nullable: true),
                    TTP_SERVICE_TABLE_NAME = table.Column<string>(maxLength: 50, nullable: true),
                    TTP_SERVICE_NAME = table.Column<string>(maxLength: 150, nullable: true),
                    TTP_SERVICE_ID = table.Column<int>(nullable: true),
                    ATTACHMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATTACHMENT",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ATT_ATTACHMENT_NAME_AR = table.Column<string>(maxLength: 500, nullable: false),
                    ATT_ATTACHMENT_NAME_EN = table.Column<string>(maxLength: 500, nullable: false),
                    ATT_ATTAHCMENT_MANDATORY = table.Column<bool>(nullable: false),
                    ATT_IS_DISABLED = table.Column<bool>(nullable: true),
                    ATT_TYPE = table.Column<int>(nullable: true),
                    TRANSACTION_TYPE_ID = table.Column<int>(nullable: false),
                    TRANSACTION_ATTACHMENT_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACHMENT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATTACHMENT_TRANSACTION_ATTACHMENT_TRANSACTION_ATTACHMENT_ID",
                        column: x => x.TRANSACTION_ATTACHMENT_ID,
                        principalTable: "TRANSACTION_ATTACHMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ATTACHMENT_TRANSACTION_TYPE_TRANSACTION_TYPE_ID",
                        column: x => x.TRANSACTION_TYPE_ID,
                        principalTable: "TRANSACTION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TRANSACTION",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TRANSACTION_STATUS_ID = table.Column<int>(nullable: false),
                    USER_ID = table.Column<int>(nullable: false),
                    WORKFLOW_LEVEL_ID = table.Column<int>(nullable: true),
                    TRA_TRANSACTION_BARCODE = table.Column<string>(maxLength: 15, nullable: false),
                    TRA_TRANSACTION_CREATE_DATE = table.Column<DateTime>(nullable: false),
                    TRANSACTION_PARENT_ID = table.Column<int>(nullable: true),
                    TRA_TRANSACTION_SHIFT_DATE = table.Column<DateTime>(nullable: true),
                    TRA_REFERENCE_NUMBER = table.Column<string>(maxLength: 50, nullable: false),
                    TRA_TRANSACTION_SUBJECT = table.Column<string>(maxLength: 300, nullable: false),
                    TRA_TRANSACTION_CONTENT = table.Column<string>(maxLength: 300, nullable: true),
                    TRA_TRANSACTION_INCOMING_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TRA_TRANSACTION_OUTGOING_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TRA_TRANSACTION_CONTRACT_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TRA_TRANSACTION_PROJECT_NUMBER = table.Column<string>(maxLength: 50, nullable: true),
                    TRA_TRANSACTION_PROJECT_NAME = table.Column<string>(maxLength: 300, nullable: true),
                    TRA_CONSIGNEE_ID = table.Column<int>(nullable: false),
                    TRA_CONSIGNEE_GOV_COMP_ID = table.Column<int>(nullable: true),
                    TRA_CONSIGNEE_NAME = table.Column<string>(maxLength: 50, nullable: true),
                    TRA_IS_COMPLETED = table.Column<bool>(nullable: true),
                    TRA_IS_LAST_LEVEL = table.Column<bool>(nullable: true),
                    TRA_EXTENDED_VALUE_ID = table.Column<int>(nullable: true),
                    TRA_IS_PUBLISHED = table.Column<bool>(nullable: true),
                    TRA_Archivie_Path = table.Column<string>(maxLength: 500, nullable: true),
                    TRA_IMPORTANCY_ID = table.Column<int>(nullable: true),
                    REG_USER_ID = table.Column<int>(nullable: true),
                    TRA_COST = table.Column<decimal>(nullable: true),
                    TRA_PAYMENT_CHANNEL_ID = table.Column<int>(nullable: true),
                    DTS_CLIENT_USER_NAME = table.Column<string>(nullable: true),
                    DTS_CLIENT_USER_ID = table.Column<int>(nullable: true),
                    DTS_SPONSER_ID = table.Column<int>(nullable: true),
                    WF_DOCUMENT_ID = table.Column<string>(maxLength: 150, nullable: true),
                    DTS_REPRESENTATIVE_MOBILE = table.Column<string>(maxLength: 50, nullable: true),
                    DTS_REPRESENTATIVE_EMAIL = table.Column<string>(maxLength: 100, nullable: true),
                    DTS_REPRESENTATIVE_NAME = table.Column<string>(maxLength: 200, nullable: true),
                    DTS_CLIENT_USER_Reference = table.Column<string>(maxLength: 150, nullable: true),
                    DTS_CLIENT_Company_Reference = table.Column<string>(maxLength: 150, nullable: true),
                    ASSIGNMENT_ID = table.Column<string>(maxLength: 200, nullable: true),
                    IsRead = table.Column<bool>(nullable: true),
                    DPW_LOGICAL_STATUS_ID = table.Column<int>(nullable: true),
                    TRA_Expiry_Date = table.Column<DateTime>(type: "date", nullable: true),
                    TRANSACTION_ATTACHMENT_ID = table.Column<int>(nullable: false),
                    TRANSACTION_TYPE_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACTION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_TRANSACTION_ATTACHMENT_TRANSACTION_ATTACHMENT_ID",
                        column: x => x.TRANSACTION_ATTACHMENT_ID,
                        principalTable: "TRANSACTION_ATTACHMENT",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TRANSACTION_TRANSACTION_TYPE_TRANSACTION_TYPE_ID",
                        column: x => x.TRANSACTION_TYPE_ID,
                        principalTable: "TRANSACTION_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Description", "IPAddress", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "4e329bb4-29c3-46f9-be0c-e56dc0c15820", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(142), "Admin", null, "Admin", "ADMIN" },
                    { "2", "dd7c820a-df1f-45cb-9453-29e2df925a22", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(920), "Editor", null, "Editor", "EDITOR" },
                    { "3", "6d97a0e9-fd0a-4966-acb9-5b429b9ca278", new DateTime(2019, 1, 21, 18, 49, 0, 105, DateTimeKind.Local).AddTicks(943), "Viewer", null, "Viewer", "VIEWER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DOB", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "3d4f1a97-c295-4ffb-8490-60c3ee0622bb", new DateTime(1982, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "mirza.sohail@hotmail.com", true, false, null, "Sohail", "mirza.sohail@hotmail.com", "SOHAIL", "AQAAAAEAACcQAAAAEESpa0fvEvSvQJS7uClpZYMUd2aXYRHajdOymHUlYBn5fhJ1svH7pZQ6IOEFKf/8bQ==", "0509705440", true, "e68300a5-8659-4d7f-a609-9ea84d0caa4d", false, "Sohail" },
                    { "2", 0, "8d17c108-59c6-4621-bd68-fbb05386b945", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "mwasghar@hotmail.com", true, false, null, "Waheed", "mmwasghar@hotmail.com", "WAHEED", "AQAAAAEAACcQAAAAEKUFq1dDASVSWp4l6Al4WuinEqZktTWjWRCMMeHawY7qSCIs+bnEbF98ooOdnAPBCw==", "+12899381727", true, "554da14c-ad1f-4fa8-96cc-517b0053a55d", false, "Waheed" },
                    { "3", 0, "24651ad4-5078-4ae4-a938-518e13b50e50", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Editor@erp.com", true, false, null, "Editor", "Editor@hotmail.com", "EDITOR", "AQAAAAEAACcQAAAAEP6TO5zPV8grkizbeZAVRoZ74lweHS/BlaCHM5Y2+6Nkg4QfxDbeFfxjFqx5L4eA5w==", "+12899381727", true, "62bf385d-b168-4970-8cbb-5a3ea0819de9", false, "Editor" },
                    { "4", 0, "097a5747-7167-440c-a3c4-ee18bfcb553e", new DateTime(1982, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Viewer@erp.com", true, false, null, "Viewer", "Viewer@hotmail.com", "VIEWER", "AQAAAAEAACcQAAAAEBaqe7NFzJ0cKcfxq4lcvH7/NB/AYsVSNdzfHLUM3ridZjOw+JeTBBddH/yJdfrQHw==", "+12899381727", true, "632b13af-7fbc-46db-a5a0-1723030dfa53", false, "Viewer" }
                });

            migrationBuilder.InsertData(
                table: "Designation",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("eee1a096-83ea-4d3f-88ee-1da7f6615b77"), "Managing Director", true, "MD" },
                    { new Guid("f03ecb13-3f1a-4fbb-b197-591b81cfd6a1"), "CPM", true, "CPM" },
                    { new Guid("53cf0015-26d2-45d0-a2f0-b92087aaa1cd"), "Manager", true, "Manager" },
                    { new Guid("d4dd6404-7c8f-4073-b97c-cca7959521e8"), "Mechanical", true, "Mechanical" }
                });

            migrationBuilder.InsertData(
                table: "FabricCodes",
                columns: new[] { "Id", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { new Guid("7c0e978f-4b34-4666-82cd-48fa14265741"), "DS", "Dryer Screen", true },
                    { new Guid("fdbfc1ef-759f-4439-9bbd-50036a2efc5a"), "MG", "MG Felt", true },
                    { new Guid("6f2ea20a-0e56-4dfa-9952-91859be12622"), "PF", "Press Felt", true },
                    { new Guid("f704ae37-c067-4d2a-8f58-d74bfc50bae5"), "PUF", "Pickup-Felt", true },
                    { new Guid("b545b876-130a-40e5-9aec-1095d8885757"), "FW", "Forming Wire", true },
                    { new Guid("75eb84c2-c26d-42fd-8c24-a2014f87c4b4"), "FT", "Felt", true }
                });

            migrationBuilder.InsertData(
                table: "FabricTypes",
                columns: new[] { "Id", "Description", "IsActive", "Type" },
                values: new object[,]
                {
                    { new Guid("e26dc385-2b49-4821-afcc-4fce0c95d1d6"), "Single Layer", true, "SL" },
                    { new Guid("43abcb6d-5814-4906-aee7-877926c928a1"), "Double Layer", true, "DL" },
                    { new Guid("bd0e4bd9-840e-4685-97b3-ac085e4ad79f"), "1.5 Layer", true, "1.5L" },
                    { new Guid("06593449-620a-4427-9e47-598dbda83a7e"), "Medium Spiral", true, "MS" },
                    { new Guid("e614b297-cccf-43a3-a2e3-43e9c48cdde4"), "Large Spiral", true, "LS" }
                });

            migrationBuilder.InsertData(
                table: "Person",
                columns: new[] { "Id", "EmailAddress", "EmergencyPhone", "IsActive", "Name", "PrimaryPhone", "SecondaryPhone" },
                values: new object[,]
                {
                    { new Guid("73eb19f8-f9c5-4a7a-be14-ed957a70467f"), "test4@test..com", "444444444", true, "Person 4", "444444444", "444444444" },
                    { new Guid("e2c71c6b-f141-415b-9a5d-ccb7727aeaa4"), "test3@test..com", "333333333", true, "Person 3", "333333333", "333333333" },
                    { new Guid("bbc84742-4bbf-44d6-bb17-911b82dbfc37"), "test2@test..com", "22222222", true, "Person 2", "22222222", "22222222" },
                    { new Guid("d2ee36c6-55a6-41e2-b773-4c3a0c18a915"), "test1@test..com", "1111111", true, "Person 1", "1111111", "1111111" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Code", "Description", "IsActive", "Name", "RegionNo" },
                values: new object[,]
                {
                    { new Guid("259bdb01-5e73-433d-abbe-e47ce06d6d4b"), "LHR", "Lahore", true, "Lahore", 1 },
                    { new Guid("6288accf-398a-47a4-b1d9-33f29cdfd521"), "MUL", "Multan", true, "Multan", 2 },
                    { new Guid("fbf360cd-fb70-44e6-932d-64e12dbcfa39"), "GRW", "Gujranwala", true, "Gujranwala", 3 },
                    { new Guid("5ec19418-88bd-4d27-a885-02424070aa0b"), "PES", "Peshawar", true, "Peshawar", 4 },
                    { new Guid("96db3d6d-4d23-4a28-ada0-7151baeeb752"), "SKP", "Sheikhupura", true, "Sheikhupura", 5 },
                    { new Guid("31b29afc-3c08-44e1-a2b7-a3b8954c3caf"), "FSD", "Faislabad", true, "Faislabad", 6 },
                    { new Guid("0e8c2c9a-f874-48e2-99d7-f4ba65a7ff80"), "SINDH", "Sindh", true, "Sindh", 7 },
                    { new Guid("c835a328-730c-4ec7-b141-59a861b8ee07"), "MID   ", "Middle", true, "Middle", 8 },
                    { new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0"), "MSC", "Msc", true, "Msc", 9 }
                });

            migrationBuilder.InsertData(
                table: "Reports",
                columns: new[] { "Id", "IsActive", "Title" },
                values: new object[,]
                {
                    { new Guid("765b265a-a6f5-4332-af4d-28960bcf41ba"), true, "Performance Report By Dryer Screen" },
                    { new Guid("e436805e-ad6a-4644-b0a8-b67caf3079e9"), true, "Performance Report By Felts" },
                    { new Guid("0b59f606-17b8-4d2d-9131-2c63aefd0718"), true, "Performance Report By Forming Wire" },
                    { new Guid("43f41f34-a69c-49ad-9d7b-4bb1ec9d1e55"), true, "Fabrics Report By Felts" },
                    { new Guid("43383cb7-e170-44e6-936d-baf07818b10a"), true, "Fabrics Report By Forming Wire" },
                    { new Guid("57bace55-524b-4afa-8c31-3ca63099c61e"), true, "Fabrics Report By Dryer Screen" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Description", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("13a02a4a-d055-4812-2b83-08d64cccfc63"), "Order has been Closed", true, "Close" },
                    { new Guid("58e07c1d-f068-4a34-2b80-08d64cccfc63"), "Order has been created", true, "Created" },
                    { new Guid("59e07c1d-f068-4a34-2b80-08d64cccfc63"), "Order has been submitted for approval", true, "Submitted" },
                    { new Guid("5a585ca4-941f-4892-2b81-08d64cccfc63"), "Order has been approved", true, "Approved" },
                    { new Guid("b770f3f8-7b25-478e-2b82-08d64cccfc63"), "Order has been rejected", true, "Rejected" },
                    { new Guid("12a02a4a-d055-4812-2b83-08d64cccfc63"), "Order has been completed", true, "Completed" },
                    { new Guid("13b02a4a-d055-4812-2b83-08d64cccfc63"), "Order has been Sjipped", true, "Shipped" }
                });

            migrationBuilder.InsertData(
                table: "ActionButtons",
                columns: new[] { "Id", "ButtonText", "StatusId" },
                values: new object[,]
                {
                    { new Guid("fab89b94-77e3-48ba-b2b8-d63a9adb4302"), "Back", new Guid("12a02a4a-d055-4812-2b83-08d64cccfc63") },
                    { new Guid("26490b4d-1b1a-470c-8f75-778886f773c0"), "Cancel", new Guid("b770f3f8-7b25-478e-2b82-08d64cccfc63") },
                    { new Guid("61c697fe-0e10-4e9e-9250-fbda8ce5d2ec"), "Close", new Guid("b770f3f8-7b25-478e-2b82-08d64cccfc63") },
                    { new Guid("d9ce84ca-b4be-474d-99ac-97e95dedad7f"), "Update", new Guid("b770f3f8-7b25-478e-2b82-08d64cccfc63") },
                    { new Guid("e2e221a4-a449-4a8a-9fde-0987c62f889a"), "Meeting", new Guid("5a585ca4-941f-4892-2b81-08d64cccfc63") },
                    { new Guid("138a4260-c9c5-4612-9eec-90f9e694ad53"), "Update", new Guid("5a585ca4-941f-4892-2b81-08d64cccfc63") },
                    { new Guid("fa459818-d04e-4fbb-a83c-b56ad66215d0"), "Ship", new Guid("5a585ca4-941f-4892-2b81-08d64cccfc63") },
                    { new Guid("8a897f19-2605-4726-98a7-ab35ef1eb392"), "On-Hold", new Guid("59e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("4e6032cb-a8a1-48a4-9a14-70d6c4a6ac9c"), "Reject", new Guid("59e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("fe3717d5-6f91-4518-869f-c8e84d324ffa"), "Approve", new Guid("59e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("bd581f44-e950-481a-af53-7880f60cafae"), "Cancel", new Guid("58e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("06d9ee9f-3b2c-45e5-bf5e-2a3a5df4df79"), "Save As Draft", new Guid("58e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("af3c18df-1280-4234-8dc5-6ab0ff76048d"), "Create", new Guid("58e07c1d-f068-4a34-2b80-08d64cccfc63") },
                    { new Guid("fa05023a-1255-4734-8330-1290e45001ee"), "Close", new Guid("12a02a4a-d055-4812-2b83-08d64cccfc63") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "4", "3" },
                    { "3", "2" },
                    { "2", "1" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Code", "Description", "IsActive", "Name", "RegionId" },
                values: new object[,]
                {
                    { new Guid("a8b23433-0b69-42fe-a6e7-b93c21a622c6"), "GAW", "Gawadar", true, "Gawadar", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") },
                    { new Guid("70f09e81-8e22-4fb5-a3fb-2c07b23390a1"), "GRW", "Gujranwala", true, "Gujranwala", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") },
                    { new Guid("93f89299-cfc9-4998-9ddd-09c5583dc8c2"), "LHR", "Lahore", true, "Lahore", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") },
                    { new Guid("1eeea024-d7f2-4c83-b5cd-0039def1f538"), "KRI", "Karachi", true, "Karachi", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") },
                    { new Guid("c63a6ad5-e617-4c77-a160-46fa10b1a47b"), "SKT", "Sialkot", true, "Sialkot", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") },
                    { new Guid("af8db26b-bffa-452f-9d7e-a5dc67fa1a2b"), "PSR", "Pasrur", true, "Pasrur", new Guid("2cf6e3e1-cf0d-4cb1-9e01-9315dfd21af0") }
                });

            migrationBuilder.InsertData(
                table: "Fabrics",
                columns: new[] { "Id", "Code", "Description", "FabricCodeId", "FabricTypeId", "IsActive" },
                values: new object[,]
                {
                    { new Guid("ccc3c1a0-4807-4486-b611-c20711b65f66"), "FT", "Felt", new Guid("75eb84c2-c26d-42fd-8c24-a2014f87c4b4"), new Guid("e614b297-cccf-43a3-a2e3-43e9c48cdde4"), true },
                    { new Guid("b9134bc6-8456-400e-8457-f3aa75cbeba4"), "DS", "Dryer Screen", new Guid("7c0e978f-4b34-4666-82cd-48fa14265741"), new Guid("bd0e4bd9-840e-4685-97b3-ac085e4ad79f"), true },
                    { new Guid("3d71bf60-ce6c-4c87-b271-6f0357c017fb"), "FW", "Forming Wire", new Guid("b545b876-130a-40e5-9aec-1095d8885757"), new Guid("43abcb6d-5814-4906-aee7-877926c928a1"), true },
                    { new Guid("20653d3a-ffee-45e8-a346-ca034e43a752"), "MG", "MG Felt", new Guid("fdbfc1ef-759f-4439-9bbd-50036a2efc5a"), new Guid("e26dc385-2b49-4821-afcc-4fce0c95d1d6"), true },
                    { new Guid("ff9ba921-0b10-4e19-ba50-c54b48c6ef47"), "PF", "Press Felt", new Guid("6f2ea20a-0e56-4dfa-9952-91859be12622"), new Guid("e26dc385-2b49-4821-afcc-4fce0c95d1d6"), true },
                    { new Guid("a35d3703-31eb-40a4-8473-17e4541ad3aa"), "PUF", "Pickup-Felt", new Guid("f704ae37-c067-4d2a-8f58-d74bfc50bae5"), new Guid("e26dc385-2b49-4821-afcc-4fce0c95d1d6"), true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionButtons_StatusId",
                table: "ActionButtons",
                column: "StatusId");

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
                name: "IX_ATTACHMENT_TRANSACTION_ATTACHMENT_ID",
                table: "ATTACHMENT",
                column: "TRANSACTION_ATTACHMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTACHMENT_TRANSACTION_TYPE_ID",
                table: "ATTACHMENT",
                column: "TRANSACTION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_City_RegionId",
                table: "City",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentOrderItem_ConsignmentOrderId",
                table: "ConsignmentOrderItem",
                column: "ConsignmentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentOrderItem_FabricId",
                table: "ConsignmentOrderItem",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentOrders_MillId",
                table: "ConsignmentOrders",
                column: "MillId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentOrders_RegionId",
                table: "ConsignmentOrders",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsignmentOrders_StatusId",
                table: "ConsignmentOrders",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStocks_FabricId",
                table: "DailyStocks",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyStocks_MillId",
                table: "DailyStocks",
                column: "MillId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_FabricCodeId",
                table: "Fabrics",
                column: "FabricCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fabrics_FabricTypeId",
                table: "Fabrics",
                column: "FabricTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Mills_CPMId",
                table: "Mills",
                column: "CPMId");

            migrationBuilder.CreateIndex(
                name: "IX_Mills_CityId",
                table: "Mills",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Mills_MDId",
                table: "Mills",
                column: "MDId");

            migrationBuilder.CreateIndex(
                name: "IX_Mills_MangerId",
                table: "Mills",
                column: "MangerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mills_MechanicalId",
                table: "Mills",
                column: "MechanicalId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_FabricId",
                table: "Order",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_MillId",
                table: "Order",
                column: "MillId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_RegionId",
                table: "Order",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComments_ConsignmentOrderId",
                table: "OrderComments",
                column: "ConsignmentOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderComments_StatusId",
                table: "OrderComments",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperMillProfile_MillId",
                table: "PaperMillProfile",
                column: "MillId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperMillProfile_RegionId",
                table: "PaperMillProfile",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperMillProfileDetail_FabricId",
                table: "PaperMillProfileDetail",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperMillProfileDetail_PaperMillProfileId",
                table: "PaperMillProfileDetail",
                column: "PaperMillProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRate_FabricId",
                table: "ProductRate",
                column: "FabricId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_CPMId",
                table: "Receivables",
                column: "CPMId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_MillId",
                table: "Receivables",
                column: "MillId");

            migrationBuilder.CreateIndex(
                name: "IX_Receivables_RegionId",
                table: "Receivables",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_TRANSACTION_ATTACHMENT_ID",
                table: "TRANSACTION",
                column: "TRANSACTION_ATTACHMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_TRANSACTION_TYPE_ID",
                table: "TRANSACTION",
                column: "TRANSACTION_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_ATTACHMENT_ATTACHMENT_ID",
                table: "TRANSACTION_ATTACHMENT",
                column: "ATTACHMENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_ATTACHMENT_TRANSACTION_ID",
                table: "TRANSACTION_ATTACHMENT",
                column: "TRANSACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACTION_TYPE_ATTACHMENT_ID",
                table: "TRANSACTION_TYPE",
                column: "ATTACHMENT_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TRANSACTION_ATTACHMENT_ATTACHMENT_ATTACHMENT_ID",
                table: "TRANSACTION_ATTACHMENT",
                column: "ATTACHMENT_ID",
                principalTable: "ATTACHMENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TRANSACTION_ATTACHMENT_TRANSACTION_TRANSACTION_ID",
                table: "TRANSACTION_ATTACHMENT",
                column: "TRANSACTION_ID",
                principalTable: "TRANSACTION",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TRANSACTION_TYPE_ATTACHMENT_ATTACHMENT_ID",
                table: "TRANSACTION_TYPE",
                column: "ATTACHMENT_ID",
                principalTable: "ATTACHMENT",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ATTACHMENT_TRANSACTION_ATTACHMENT_TRANSACTION_ATTACHMENT_ID",
                table: "ATTACHMENT");

            migrationBuilder.DropForeignKey(
                name: "FK_TRANSACTION_TRANSACTION_ATTACHMENT_TRANSACTION_ATTACHMENT_ID",
                table: "TRANSACTION");

            migrationBuilder.DropForeignKey(
                name: "FK_ATTACHMENT_TRANSACTION_TYPE_TRANSACTION_TYPE_ID",
                table: "ATTACHMENT");

            migrationBuilder.DropTable(
                name: "ActionButtons");

            migrationBuilder.DropTable(
                name: "ApplicationLog");

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
                name: "ConsignmentOrderItem");

            migrationBuilder.DropTable(
                name: "DailyStocks");

            migrationBuilder.DropTable(
                name: "Designation");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderComments");

            migrationBuilder.DropTable(
                name: "PaperMillProfileDetail");

            migrationBuilder.DropTable(
                name: "ProductRate");

            migrationBuilder.DropTable(
                name: "Receivables");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "TempAttachment");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ConsignmentOrders");

            migrationBuilder.DropTable(
                name: "PaperMillProfile");

            migrationBuilder.DropTable(
                name: "Fabrics");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Mills");

            migrationBuilder.DropTable(
                name: "FabricCodes");

            migrationBuilder.DropTable(
                name: "FabricTypes");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "TRANSACTION_ATTACHMENT");

            migrationBuilder.DropTable(
                name: "TRANSACTION");

            migrationBuilder.DropTable(
                name: "TRANSACTION_TYPE");

            migrationBuilder.DropTable(
                name: "ATTACHMENT");
        }
    }
}
