using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace act.Repositories.Db.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Firstname = table.Column<string>(type: "TEXT", nullable: true),
                    Lastname = table.Column<string>(type: "TEXT", nullable: true),
                    RelationSubjectId = table.Column<int>(type: "INTEGER", nullable: true),
                    RelationObjectId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    SubjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => new { x.SubjectId, x.ObjectId });
                    table.ForeignKey(
                        name: "FK_Relations_Interactions_ObjectId",
                        column: x => x.ObjectId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_Interactions_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Interactions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_RelationSubjectId_RelationObjectId",
                table: "Interactions",
                columns: new[] { "RelationSubjectId", "RelationObjectId" });

            migrationBuilder.CreateIndex(
                name: "IX_Relations_ObjectId",
                table: "Relations",
                column: "ObjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Relations_RelationSubjectId_RelationObjectId",
                table: "Interactions",
                columns: new[] { "RelationSubjectId", "RelationObjectId" },
                principalTable: "Relations",
                principalColumns: new[] { "SubjectId", "ObjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Relations_RelationSubjectId_RelationObjectId",
                table: "Interactions");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Interactions");
        }
    }
}
