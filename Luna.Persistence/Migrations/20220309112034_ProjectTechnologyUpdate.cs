using Microsoft.EntityFrameworkCore.Migrations;

namespace Luna.Persistence.Migrations
{
    public partial class ProjectTechnologyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectsId",
                table: "ProjectTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Technologys_TechnologiesId",
                table: "ProjectTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology");

            migrationBuilder.RenameColumn(
                name: "TechnologiesId",
                table: "ProjectTechnology",
                newName: "TechnologyId");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ProjectTechnology",
                newName: "ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTechnology_TechnologiesId",
                table: "ProjectTechnology",
                newName: "IX_ProjectTechnology_TechnologyId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProjectTechnology",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTechnology_ProjectId",
                table: "ProjectTechnology",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectId",
                table: "ProjectTechnology",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Technologys_TechnologyId",
                table: "ProjectTechnology",
                column: "TechnologyId",
                principalTable: "Technologys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectId",
                table: "ProjectTechnology");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTechnology_Technologys_TechnologyId",
                table: "ProjectTechnology");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology");

            migrationBuilder.DropIndex(
                name: "IX_ProjectTechnology_ProjectId",
                table: "ProjectTechnology");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProjectTechnology");

            migrationBuilder.RenameColumn(
                name: "TechnologyId",
                table: "ProjectTechnology",
                newName: "TechnologiesId");

            migrationBuilder.RenameColumn(
                name: "ProjectId",
                table: "ProjectTechnology",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_ProjectTechnology_TechnologyId",
                table: "ProjectTechnology",
                newName: "IX_ProjectTechnology_TechnologiesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTechnology",
                table: "ProjectTechnology",
                columns: new[] { "ProjectsId", "TechnologiesId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Projects_ProjectsId",
                table: "ProjectTechnology",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTechnology_Technologys_TechnologiesId",
                table: "ProjectTechnology",
                column: "TechnologiesId",
                principalTable: "Technologys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
