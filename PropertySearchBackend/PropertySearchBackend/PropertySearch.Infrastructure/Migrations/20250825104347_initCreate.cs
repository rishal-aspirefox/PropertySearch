using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PropertySearch.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    StateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Properties_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spaces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Size = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spaces_Properties_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6c7a4b20-5f33-4a1c-8e5d-3a2f0c123456", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d7a4b61a-7f33-4d2c-9fc2-0d94a7e7c6f7", 0, "7c3d4527-77be-48ae-a7bb-993b8f779c68", "Admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEGkjwkbi0S+xI4L6k66/svhooc3wb8nGhv1l0HcG25qG+KrtNz3qeZ9dXbgvUvAGhg==", null, false, "8b9a6f12-3f62-4a4a-9425-4dbe49e2c63d", false, "Admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("3966addb-172c-43f0-afb7-7a53ca03bb59"), "IND", "India" },
                    { new Guid("5ddb4208-6a29-49e6-8011-5a2224cec5de"), "AUS", "Australia" },
                    { new Guid("ce6af6ca-30f7-4df5-9abf-5b9c5b2e4195"), "UK", "United Kingdom" },
                    { new Guid("f1d1a7b6-68a6-4d89-8cc9-b0b6e83a8767"), "USA", "United States" },
                    { new Guid("fab9a17c-4d8f-468b-9d90-a9afba263d98"), "CAN", "Canada" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6c7a4b20-5f33-4a1c-8e5d-3a2f0c123456", "d7a4b61a-7f33-4d2c-9fc2-0d94a7e7c6f7" });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "Code", "CountryId", "Name" },
                values: new object[,]
                {
                    { new Guid("4b805e95-4827-46c5-a2bd-4702871b3be5"), "CA", new Guid("f1d1a7b6-68a6-4d89-8cc9-b0b6e83a8767"), "California" },
                    { new Guid("89fd420c-c260-42f8-99bf-f15f9c0c8967"), "ON", new Guid("fab9a17c-4d8f-468b-9d90-a9afba263d98"), "Ontario" },
                    { new Guid("c5a345e8-c0fa-4a51-81fa-7ec0334e378c"), "LDN", new Guid("ce6af6ca-30f7-4df5-9abf-5b9c5b2e4195"), "London" },
                    { new Guid("ec300f25-fddd-4d70-85b2-d55d297e48d7"), "NSW", new Guid("5ddb4208-6a29-49e6-8011-5a2224cec5de"), "New South Wales" },
                    { new Guid("ffcb5e16-71b2-4976-b859-4f7a58c177bf"), "MH", new Guid("3966addb-172c-43f0-afb7-7a53ca03bb59"), "Maharashtra" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "City", "CountryId", "CreatedAt", "Description", "PostalCode", "Price", "StateId", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0039260c-1391-43fb-994d-acd845399ddc"), "5 Hill Rd", "Blue Mountains", new Guid("5ddb4208-6a29-49e6-8011-5a2224cec5de"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Spacious plot of land in the scenic Blue Mountains, ideal for building or investment.", "2780", 600000m, new Guid("ec300f25-fddd-4d70-85b2-d55d297e48d7"), "Land", null },
                    { new Guid("02fcd393-4074-4cee-b92c-ff873e9cf88e"), "22 Baker St", "London", new Guid("ce6af6ca-30f7-4df5-9abf-5b9c5b2e4195"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Family house in central London.", "NW16XE", 800000m, new Guid("c5a345e8-c0fa-4a51-81fa-7ec0334e378c"), "House", null },
                    { new Guid("05fb82f6-fe00-4605-9546-81c03bba0a9c"), "99 Altamount Rd", "Mumbai", new Guid("3966addb-172c-43f0-afb7-7a53ca03bb59"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Ultra-luxury condo in South Mumbai.", "400026", 30000000m, new Guid("ffcb5e16-71b2-4976-b859-4f7a58c177bf"), "Condo", null },
                    { new Guid("1b3af3ce-cf6d-4af0-b352-5c79b13a893c"), "67 Sunset Blvd", "Los Angeles", new Guid("f1d1a7b6-68a6-4d89-8cc9-b0b6e83a8767"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Affordable studio in downtown LA.", "90028", 150000m, new Guid("4b805e95-4827-46c5-a2bd-4702871b3be5"), "Apartment", null },
                    { new Guid("44040603-ed61-4b7e-a4cb-e2625a126d21"), "12 George St", "Sydney", new Guid("5ddb4208-6a29-49e6-8011-5a2224cec5de"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Large house in Sydney suburb.", "2000", 1200000m, new Guid("ec300f25-fddd-4d70-85b2-d55d297e48d7"), "House", null },
                    { new Guid("520c4026-1436-4b9c-a996-f0776b2b3131"), "15 Tower St", "London", new Guid("ce6af6ca-30f7-4df5-9abf-5b9c5b2e4195"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Modern apartment near Canary Wharf.", "E145HQ", 950000m, new Guid("c5a345e8-c0fa-4a51-81fa-7ec0334e378c"), "Apartment", null },
                    { new Guid("746ef692-61b6-4780-a02f-a36c1c96f4c5"), "123 Main St", "Los Angeles", new Guid("f1d1a7b6-68a6-4d89-8cc9-b0b6e83a8767"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Modern 2BHK apartment near downtown Los Angeles.", "90001", 250000m, new Guid("4b805e95-4827-46c5-a2bd-4702871b3be5"), "Apartment", null },
                    { new Guid("94827cea-127a-480d-9781-111e27d17256"), "45 Bay St", "Toronto", new Guid("fab9a17c-4d8f-468b-9d90-a9afba263d98"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Luxury condo with lake view in Toronto.", "M5J2X2", 450000m, new Guid("89fd420c-c260-42f8-99bf-f15f9c0c8967"), "Condo", null },
                    { new Guid("c97eca96-eb6f-4859-b69c-7c7f5028d24c"), "78 Marine Drive", "Mumbai", new Guid("3966addb-172c-43f0-afb7-7a53ca03bb59"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Spacious villa in Mumbai with private pool.", "400020", 15000000m, new Guid("ffcb5e16-71b2-4976-b859-4f7a58c177bf"), "Villa", null },
                    { new Guid("ce993b27-6852-4f24-87ae-4163a81bf8ea"), "56 Greenfield Rd", "Ottawa", new Guid("fab9a17c-4d8f-468b-9d90-a9afba263d98"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Farmhouse in Ontario countryside.", "K1A0B1", 2000000m, new Guid("89fd420c-c260-42f8-99bf-f15f9c0c8967"), "House", null }
                });

            migrationBuilder.InsertData(
                table: "Spaces",
                columns: new[] { "Id", "CreatedAt", "Description", "PropertyId", "Size", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("1f8e9140-6436-48c1-8877-4b791f5389aa"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Master bedroom with attached bathroom.", new Guid("746ef692-61b6-4780-a02f-a36c1c96f4c5"), 200f, "Bedroom", null },
                    { new Guid("376f54b3-e5cf-46e9-a202-f3c2961b2c75"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Spacious garage suitable for two vehicles and storage.", new Guid("02fcd393-4074-4cee-b92c-ff873e9cf88e"), 300f, "Garage", null },
                    { new Guid("3eaa205a-a8a2-4436-a716-73617039498c"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Open-plan living room with modern decor and entertainment area.", new Guid("05fb82f6-fe00-4605-9546-81c03bba0a9c"), 400f, "Living Room", null },
                    { new Guid("4a1eccc5-d9ad-42a7-842c-57d4d2be7c1f"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Private landscaped garden.", new Guid("94827cea-127a-480d-9781-111e27d17256"), 800f, "Garden", null },
                    { new Guid("5a1d9fb0-6d93-4d91-a0c0-d630e91a9d49"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Master bedroom with ensuite bathroom and balcony view.", new Guid("ce993b27-6852-4f24-87ae-4163a81bf8ea"), 200f, "Bedroom", null },
                    { new Guid("5d546e7d-ab65-413a-b4f3-71cdfff51f80"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "2-car parking garage.", new Guid("1b3af3ce-cf6d-4af0-b352-5c79b13a893c"), 500f, "Garage", null },
                    { new Guid("6497a348-d03d-4ccc-b7a2-115a588ed337"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Modern kitchen with island and high-end appliances.", new Guid("c97eca96-eb6f-4859-b69c-7c7f5028d24c"), 150f, "Kitchen", null },
                    { new Guid("8e07e7ef-9ff2-4de5-af69-dc976cefd76e"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Two-car garage with storage space and automatic door.", new Guid("c97eca96-eb6f-4859-b69c-7c7f5028d24c"), 220f, "Garage", null },
                    { new Guid("9813899c-035b-4451-b947-90d39739c3e8"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Elegant living room with fireplace and entertainment setup.", new Guid("520c4026-1436-4b9c-a996-f0776b2b3131"), 450f, "Living Room", null },
                    { new Guid("b4bb1cff-d02f-4981-943e-af1fa11dc1e1"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Well-maintained garden with outdoor seating and plants.", new Guid("05fb82f6-fe00-4605-9546-81c03bba0a9c"), 500f, "Garden", null },
                    { new Guid("bdb47a89-5aa8-4eda-baba-7515b97231b2"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Cozy bedroom with built-in wardrobe and large window.", new Guid("ce993b27-6852-4f24-87ae-4163a81bf8ea"), 180f, "Bedroom", null },
                    { new Guid("d7f6c0d4-bf2c-4e4f-9e1f-3a0524523b30"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Spacious living area with balcony.", new Guid("746ef692-61b6-4780-a02f-a36c1c96f4c5"), 350f, "Living Room", null },
                    { new Guid("f16c0f05-c758-416e-8d30-bd764dc2389b"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Spacious living room with natural light and modern furniture.", new Guid("94827cea-127a-480d-9781-111e27d17256"), 350f, "Living Room", null },
                    { new Guid("f812ebe2-0320-4e74-83e4-a4553d80e499"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Modular kitchen with modern fittings.", new Guid("1b3af3ce-cf6d-4af0-b352-5c79b13a893c"), 180f, "Kitchen", null },
                    { new Guid("f9319ede-ddcd-4abe-9f5f-97291254906c"), new DateTime(2025, 8, 21, 13, 29, 0, 0, DateTimeKind.Local), "Guest bedroom with comfortable bed and study desk.", new Guid("02fcd393-4074-4cee-b92c-ff873e9cf88e"), 160f, "Bedroom", null }
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
                name: "IX_Properties_CountryId",
                table: "Properties",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Price",
                table: "Properties",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_StateId",
                table: "Properties",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_Type",
                table: "Properties",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_PropertyId",
                table: "Spaces",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_Size",
                table: "Spaces",
                column: "Size");

            migrationBuilder.CreateIndex(
                name: "IX_Spaces_Type",
                table: "Spaces",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Spaces");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
