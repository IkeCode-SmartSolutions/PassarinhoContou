using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PassarinhoContou.Model.Migrations
{
    public partial class _100_FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PrefixCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Owner = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefixCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuffixCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Owner = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuffixCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(500)", nullable: false),
                    NickName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MessagePrefixes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    PrefixCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagePrefixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessagePrefixes_PrefixCategories",
                        column: x => x.PrefixCategoryId,
                        principalTable: "PrefixCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrefixCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CategoryText = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    PrefixCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefixCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrefixCategoryTranslations_PrefixCategories",
                        column: x => x.PrefixCategoryId,
                        principalTable: "PrefixCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MessageSuffixes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    SuffixCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageSuffixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageSuffixes_SuffixCategories",
                        column: x => x.SuffixCategoryId,
                        principalTable: "SuffixCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuffixCategoryTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryText = table.Column<string>(type: "varchar(100)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    PrefixCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuffixCategoryTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuffixCategoryTranslations_SuffixCategories",
                        column: x => x.PrefixCategoryId,
                        principalTable: "SuffixCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConnectedDevices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConfirmationCode = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DeviceId = table.Column<string>(type: "varchar(500)", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectedDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectedDevices_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PrefixesTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MessageText = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    PrefixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrefixesTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrefixesTranslations_MessagePrefixes",
                        column: x => x.PrefixId,
                        principalTable: "MessagePrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    FromUserId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MessageType = table.Column<int>(nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    SelectedPrefixId = table.Column<int>(nullable: false),
                    SelectedSuffixId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ToUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_FromUser",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_MessagePrefixes",
                        column: x => x.SelectedPrefixId,
                        principalTable: "MessagePrefixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_MessageSuffixes",
                        column: x => x.SelectedSuffixId,
                        principalTable: "MessageSuffixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_ToUser",
                        column: x => x.ToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SuffixesTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LanguageId = table.Column<int>(nullable: false),
                    MessageText = table.Column<string>(type: "text", nullable: false),
                    Owner = table.Column<int>(nullable: false),
                    SuffixId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuffixesTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuffixesTranslations_MessageSuffixes",
                        column: x => x.SuffixId,
                        principalTable: "MessageSuffixes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectedDevices_UserId",
                table: "ConnectedDevices",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessagePrefixes_PrefixCategoryId",
                table: "MessagePrefixes",
                column: "PrefixCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SelectedPrefixId",
                table: "Messages",
                column: "SelectedPrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SelectedSuffixId",
                table: "Messages",
                column: "SelectedSuffixId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToUserId",
                table: "Messages",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MessageSuffixes_SuffixCategoryId",
                table: "MessageSuffixes",
                column: "SuffixCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefixCategoryTranslations_PrefixCategoryId",
                table: "PrefixCategoryTranslations",
                column: "PrefixCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PrefixesTranslations_PrefixId",
                table: "PrefixesTranslations",
                column: "PrefixId");

            migrationBuilder.CreateIndex(
                name: "IX_SuffixCategoryTranslations_PrefixCategoryId",
                table: "SuffixCategoryTranslations",
                column: "PrefixCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SuffixesTranslations_SuffixId",
                table: "SuffixesTranslations",
                column: "SuffixId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectedDevices");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PrefixCategoryTranslations");

            migrationBuilder.DropTable(
                name: "PrefixesTranslations");

            migrationBuilder.DropTable(
                name: "SuffixCategoryTranslations");

            migrationBuilder.DropTable(
                name: "SuffixesTranslations");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MessagePrefixes");

            migrationBuilder.DropTable(
                name: "MessageSuffixes");

            migrationBuilder.DropTable(
                name: "PrefixCategories");

            migrationBuilder.DropTable(
                name: "SuffixCategories");
        }
    }
}
