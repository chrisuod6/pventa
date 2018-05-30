using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Actividad.Migrations
{
    public partial class DataInicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NivelesUsuarios",
                columns: table => new
                {
                    CodigoNivel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescripcionNivel = table.Column<string>(nullable: true),
                    NombreNivel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NivelesUsuarios", x => x.CodigoNivel);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    CodigoUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApellidoUsuario = table.Column<string>(nullable: true),
                    ClaveUsuario = table.Column<string>(nullable: true),
                    CuentaUsuario = table.Column<string>(nullable: true),
                    NivelUsuariosCodigoNivel = table.Column<int>(nullable: true),
                    NombreUsuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.CodigoUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_NivelesUsuarios_NivelUsuariosCodigoNivel",
                        column: x => x.NivelUsuariosCodigoNivel,
                        principalTable: "NivelesUsuarios",
                        principalColumn: "CodigoNivel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_NivelUsuariosCodigoNivel",
                table: "Usuarios",
                column: "NivelUsuariosCodigoNivel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "NivelesUsuarios");
        }
    }
}
