using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ExpoBlog.Migrations
{
    public partial class initcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Bytes = table.Column<byte[]>(nullable: true),
                    ContentLength = table.Column<long>(nullable: false),
                    ContentType = table.Column<string>(maxLength: 128, nullable: true),
                    FileName = table.Column<string>(maxLength: 128, nullable: true),
                    Time = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blobs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PRI = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogRolls",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AvatarId = table.Column<Guid>(nullable: true),
                    GitHubId = table.Column<string>(maxLength: 64, nullable: true),
                    NickName = table.Column<string>(maxLength: 64, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    URL = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogRolls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogRolls_Blobs_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Blobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CatalogId = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    IsPage = table.Column<bool>(nullable: false),
                    Summary = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Url = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostId = table.Column<Guid>(nullable: false),
                    Tag = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blobs_FileName",
                table: "Blobs",
                column: "FileName");

            migrationBuilder.CreateIndex(
                name: "IX_Blobs_Time",
                table: "Blobs",
                column: "Time");

            migrationBuilder.CreateIndex(
                name: "IX_BlogRolls_AvatarId",
                table: "BlogRolls",
                column: "AvatarId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogRolls_GitHubId",
                table: "BlogRolls",
                column: "GitHubId");

            migrationBuilder.CreateIndex(
                name: "IX_Catalogs_PRI",
                table: "Catalogs",
                column: "PRI");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CatalogId",
                table: "Posts",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_IsPage",
                table: "Posts",
                column: "IsPage");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Time",
                table: "Posts",
                column: "Time");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Title",
                table: "Posts",
                column: "Title")
                .Annotation("MySql:FullTextIndex", "FULLTEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_Url",
                table: "Posts",
                column: "Url",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostId",
                table: "PostTags",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_Tag",
                table: "PostTags",
                column: "Tag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogRolls");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Blobs");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Catalogs");
        }
    }
}
