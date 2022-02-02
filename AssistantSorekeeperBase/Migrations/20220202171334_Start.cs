using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AssistantSorekeeperBase.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Users");

            migrationBuilder.EnsureSchema(
                name: "Warehouses");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Remove = table.Column<bool>(type: "boolean", nullable: false),
                    RemoveLUId = table.Column<int>(type: "integer", nullable: true),
                    LastLoginDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Peoples",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peoples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "LinksUserPeople",
                schema: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    PeoplesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinksUserPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinksUserPeople_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinksUserPeople_Peoples_PeoplesId",
                        column: x => x.PeoplesId,
                        principalSchema: "Users",
                        principalTable: "Peoples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nomenclature",
                schema: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InsertedLUPId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedLUPId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedLUPId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomenclature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nomenclature_LinksUserPeople_DeletedLUPId",
                        column: x => x.DeletedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Nomenclature_LinksUserPeople_InsertedLUPId",
                        column: x => x.InsertedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nomenclature_LinksUserPeople_UpdatedLUPId",
                        column: x => x.UpdatedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                schema: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InsertedLUPId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedLUPId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedLUPId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_LinksUserPeople_DeletedLUPId",
                        column: x => x.DeletedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Warehouses_LinksUserPeople_InsertedLUPId",
                        column: x => x.InsertedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Warehouses_LinksUserPeople_UpdatedLUPId",
                        column: x => x.UpdatedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LinkWarehousesNomenclature",
                schema: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Past = table.Column<bool>(type: "boolean", nullable: false),
                    WarehousesId = table.Column<int>(type: "integer", nullable: false),
                    NomenclatureId = table.Column<int>(type: "integer", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InsertedLUPId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedLUPId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedLUPId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkWarehousesNomenclature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LinkWarehousesNomenclature_LinksUserPeople_DeletedLUPId",
                        column: x => x.DeletedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkWarehousesNomenclature_LinksUserPeople_InsertedLUPId",
                        column: x => x.InsertedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkWarehousesNomenclature_LinksUserPeople_UpdatedLUPId",
                        column: x => x.UpdatedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LinkWarehousesNomenclature_Nomenclature_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalSchema: "Warehouses",
                        principalTable: "Nomenclature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkWarehousesNomenclature_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalSchema: "Warehouses",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovementHistory",
                schema: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WarehousesRecipientId = table.Column<int>(type: "integer", nullable: false),
                    WarehousesSenderId = table.Column<int>(type: "integer", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InsertedLUPId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedLUPId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedLUPId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementHistory_LinksUserPeople_DeletedLUPId",
                        column: x => x.DeletedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementHistory_LinksUserPeople_InsertedLUPId",
                        column: x => x.InsertedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementHistory_LinksUserPeople_UpdatedLUPId",
                        column: x => x.UpdatedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementHistory_Warehouses_WarehousesRecipientId",
                        column: x => x.WarehousesRecipientId,
                        principalSchema: "Warehouses",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementHistory_Warehouses_WarehousesSenderId",
                        column: x => x.WarehousesSenderId,
                        principalSchema: "Warehouses",
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovementHistoryItems",
                schema: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovementHistoryId = table.Column<int>(type: "integer", nullable: false),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    NomenclatureId = table.Column<int>(type: "integer", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InsertedLUPId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedLUPId = table.Column<int>(type: "integer", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedLUPId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementHistoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementHistoryItems_LinksUserPeople_DeletedLUPId",
                        column: x => x.DeletedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementHistoryItems_LinksUserPeople_InsertedLUPId",
                        column: x => x.InsertedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementHistoryItems_LinksUserPeople_UpdatedLUPId",
                        column: x => x.UpdatedLUPId,
                        principalSchema: "Users",
                        principalTable: "LinksUserPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovementHistoryItems_MovementHistory_MovementHistoryId",
                        column: x => x.MovementHistoryId,
                        principalSchema: "Warehouses",
                        principalTable: "MovementHistory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementHistoryItems_Nomenclature_NomenclatureId",
                        column: x => x.NomenclatureId,
                        principalSchema: "Warehouses",
                        principalTable: "Nomenclature",
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
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LinksUserPeople_PeoplesId",
                schema: "Users",
                table: "LinksUserPeople",
                column: "PeoplesId");

            migrationBuilder.CreateIndex(
                name: "IX_LinksUserPeople_UserId",
                schema: "Users",
                table: "LinksUserPeople",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkWarehousesNomenclature_DeletedLUPId",
                schema: "Warehouses",
                table: "LinkWarehousesNomenclature",
                column: "DeletedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkWarehousesNomenclature_InsertedLUPId",
                schema: "Warehouses",
                table: "LinkWarehousesNomenclature",
                column: "InsertedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkWarehousesNomenclature_NomenclatureId",
                schema: "Warehouses",
                table: "LinkWarehousesNomenclature",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkWarehousesNomenclature_UpdatedLUPId",
                schema: "Warehouses",
                table: "LinkWarehousesNomenclature",
                column: "UpdatedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkWarehousesNomenclature_WarehousesId",
                schema: "Warehouses",
                table: "LinkWarehousesNomenclature",
                column: "WarehousesId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistory_DeletedLUPId",
                schema: "Warehouses",
                table: "MovementHistory",
                column: "DeletedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistory_InsertedLUPId",
                schema: "Warehouses",
                table: "MovementHistory",
                column: "InsertedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistory_UpdatedLUPId",
                schema: "Warehouses",
                table: "MovementHistory",
                column: "UpdatedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistory_WarehousesRecipientId",
                schema: "Warehouses",
                table: "MovementHistory",
                column: "WarehousesRecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistory_WarehousesSenderId",
                schema: "Warehouses",
                table: "MovementHistory",
                column: "WarehousesSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistoryItems_DeletedLUPId",
                schema: "Warehouses",
                table: "MovementHistoryItems",
                column: "DeletedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistoryItems_InsertedLUPId",
                schema: "Warehouses",
                table: "MovementHistoryItems",
                column: "InsertedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistoryItems_MovementHistoryId",
                schema: "Warehouses",
                table: "MovementHistoryItems",
                column: "MovementHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistoryItems_NomenclatureId",
                schema: "Warehouses",
                table: "MovementHistoryItems",
                column: "NomenclatureId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementHistoryItems_UpdatedLUPId",
                schema: "Warehouses",
                table: "MovementHistoryItems",
                column: "UpdatedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomenclature_DeletedLUPId",
                schema: "Warehouses",
                table: "Nomenclature",
                column: "DeletedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomenclature_InsertedLUPId",
                schema: "Warehouses",
                table: "Nomenclature",
                column: "InsertedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Nomenclature_UpdatedLUPId",
                schema: "Warehouses",
                table: "Nomenclature",
                column: "UpdatedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_DeletedLUPId",
                schema: "Warehouses",
                table: "Warehouses",
                column: "DeletedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_InsertedLUPId",
                schema: "Warehouses",
                table: "Warehouses",
                column: "InsertedLUPId");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_UpdatedLUPId",
                schema: "Warehouses",
                table: "Warehouses",
                column: "UpdatedLUPId");
        }

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
                name: "LinkWarehousesNomenclature",
                schema: "Warehouses");

            migrationBuilder.DropTable(
                name: "MovementHistoryItems",
                schema: "Warehouses");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MovementHistory",
                schema: "Warehouses");

            migrationBuilder.DropTable(
                name: "Nomenclature",
                schema: "Warehouses");

            migrationBuilder.DropTable(
                name: "Warehouses",
                schema: "Warehouses");

            migrationBuilder.DropTable(
                name: "LinksUserPeople",
                schema: "Users");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Peoples",
                schema: "Users");
        }
    }
}
