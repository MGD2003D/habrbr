using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace habrbr.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlogName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatorID = table.Column<int>(type: "integer", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Blog_User_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Text = table.Column<string>(type: "text", nullable: true),
                    AuthorID = table.Column<int>(type: "integer", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Tags = table.Column<string[]>(type: "text[]", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    BlogID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Article_Blog_BlogID",
                        column: x => x.BlogID,
                        principalTable: "Blog",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Article_User_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Text = table.Column<string>(type: "text", nullable: true),
                    AuthorID = table.Column<int>(type: "integer", nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ParentArticleID = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comment_Article_ParentArticleID",
                        column: x => x.ParentArticleID,
                        principalTable: "Article",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Comment_User_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorID",
                table: "Article",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Article_BlogID",
                table: "Article",
                column: "BlogID");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_CreatorID",
                table: "Blog",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorID",
                table: "Comment",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentArticleID",
                table: "Comment",
                column: "ParentArticleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
