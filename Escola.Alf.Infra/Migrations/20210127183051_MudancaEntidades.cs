using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escola.Alf.Infra.Migrations
{
    public partial class MudancaEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prova_Professores_ProfessorId",
                table: "Prova");

            migrationBuilder.DropTable(
                name: "Professores");

            migrationBuilder.RenameColumn(
                name: "ProfessorId",
                table: "Prova",
                newName: "AlunoId");

            migrationBuilder.RenameIndex(
                name: "IX_Prova_ProfessorId",
                table: "Prova",
                newName: "IX_Prova_AlunoId");

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    DatadeNascimento = table.Column<DateTime>(name: "Data de Nascimento", type: "datetime2", nullable: false),
                    ProvaId = table.Column<int>(type: "int", nullable: true),
                    Deletado = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Prova_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Prova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ProvaId",
                table: "Alunos",
                column: "ProvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prova_Alunos_AlunoId",
                table: "Prova",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prova_Alunos_AlunoId",
                table: "Prova");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.RenameColumn(
                name: "AlunoId",
                table: "Prova",
                newName: "ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_Prova_AlunoId",
                table: "Prova",
                newName: "IX_Prova_ProfessorId");

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deletado = table.Column<bool>(type: "bit", nullable: false),
                    Disciplina = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", unicode: false, maxLength: 60, nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ProvaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professores_Prova_ProvaId",
                        column: x => x.ProvaId,
                        principalTable: "Prova",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Professores_ProvaId",
                table: "Professores",
                column: "ProvaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prova_Professores_ProfessorId",
                table: "Prova",
                column: "ProfessorId",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
