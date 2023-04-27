using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeAStepAPI.Migrations
{
    /// <inheritdoc />
    public partial class _01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scenes",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false),
                    storyId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenes", x => x._Id);
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false),
                    OwnSceneId = table.Column<int>(type: "int", nullable: true),
                    NextSceneId = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x._Id);
                    table.ForeignKey(
                        name: "FK_Choices_Scenes_NextSceneId",
                        column: x => x.NextSceneId,
                        principalTable: "Scenes",
                        principalColumn: "_Id");
                    table.ForeignKey(
                        name: "FK_Choices_Scenes_OwnSceneId",
                        column: x => x.OwnSceneId,
                        principalTable: "Scenes",
                        principalColumn: "_Id");
                });

            migrationBuilder.CreateTable(
                name: "SceneEffects",
                columns: table => new
                {
                    _Id = table.Column<int>(type: "int", nullable: false),
                    sceneId = table.Column<int>(type: "int", nullable: false),
                    hpChange = table.Column<int>(type: "int", nullable: true),
                    goldChange = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SceneEffects", x => x._Id);
                    table.ForeignKey(
                        name: "FK_SceneEffects_Scenes_sceneId",
                        column: x => x.sceneId,
                        principalTable: "Scenes",
                        principalColumn: "_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Choices_NextSceneId",
                table: "Choices",
                column: "NextSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_OwnSceneId",
                table: "Choices",
                column: "OwnSceneId");

            migrationBuilder.CreateIndex(
                name: "IX_SceneEffects_sceneId",
                table: "SceneEffects",
                column: "sceneId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "SceneEffects");

            migrationBuilder.DropTable(
                name: "Scenes");
        }
    }
}
