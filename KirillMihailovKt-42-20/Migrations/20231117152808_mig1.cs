using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KirillMihailovKt_42_20.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cd_academicdegree",
                columns: table => new
                {
                    academicdegree_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи ученной степени")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_academicdegreeName = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Ученная степень")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_academicdegree_academicdegree_id", x => x.academicdegree_id);
                });

            migrationBuilder.CreateTable(
                name: "Kafedra",
                columns: table => new
                {
                    kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи кафедрыы")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_kafedra_name = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Название кафедры"),
                    c_kafedra_DateFoundation = table.Column<DateTime>(type: "DateTime", nullable: false, comment: "Дата основания кафедры"),
                    c_kafedra_PrepodCount = table.Column<int>(type: "int", nullable: false, comment: "Количество преподавателей в кафедре")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_kafedra_kafedra_id", x => x.kafedra_id);
                });

            migrationBuilder.CreateTable(
                name: "cd_prepod",
                columns: table => new
                {
                    prepod_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор записи преподавателя")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    c_prepod_firstname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Имя преподавателя"),
                    c_prepod_lastname = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Фамилия преподавателя"),
                    c_prepod_middlename = table.Column<string>(type: "nvarchar(Max)", maxLength: 100, nullable: false, comment: "Отчество преподавателя"),
                    c_kafedra_id = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор кафедры"),
                    c_prepod_academicdegreeId = table.Column<int>(type: "int", nullable: false, comment: "Идентификатор ученой степени")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cd_prepod_prepod_id", x => x.prepod_id);
                    table.ForeignKey(
                        name: "fk_f_academicdegree_id",
                        column: x => x.c_prepod_academicdegreeId,
                        principalTable: "cd_academicdegree",
                        principalColumn: "academicdegree_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_f_kafedra_id",
                        column: x => x.c_kafedra_id,
                        principalTable: "Kafedra",
                        principalColumn: "kafedra_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cd_prepod_c_kafedra_id",
                table: "cd_prepod",
                column: "c_kafedra_id");

            migrationBuilder.CreateIndex(
                name: "IX_cd_prepod_c_prepod_academicdegreeId",
                table: "cd_prepod",
                column: "c_prepod_academicdegreeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cd_prepod");

            migrationBuilder.DropTable(
                name: "cd_academicdegree");

            migrationBuilder.DropTable(
                name: "Kafedra");
        }
    }
}
