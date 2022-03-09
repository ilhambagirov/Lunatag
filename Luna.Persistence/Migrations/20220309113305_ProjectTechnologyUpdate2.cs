using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Persistence.Migrations
{
    public partial class ProjectTechnologyUpdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTechnology");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Technologys",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Technologys_ProjectId",
                table: "Technologys",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Technologys_Projects_ProjectId",
                table: "Technologys",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technologys_Projects_ProjectId",
                table: "Technologys");

            migrationBuilder.DropIndex(
                name: "IX_Technologys_ProjectId",
                table: "Technologys");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Technologys");

            migrationBuilder.CreateTable(
                name: "ProjectTechnology",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TechnologyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTechnology", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectTechnology_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectTechnology_Technologys_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnology_ProjectId",
                table: "ProjectTechnology",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnology_TechnologyId",
                table: "ProjectTechnology",
                column: "TechnologyId");
        }
    }
}
