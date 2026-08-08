using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodShareAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Rol = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAlimento = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    FechaDonacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Disponible = table.Column<bool>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donaciones_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DonacionId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Donaciones_DonacionId",
                        column: x => x.DonacionId,
                        principalTable: "Donaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitudes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SolicitudId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EstadoEntrega = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entregas_Solicitudes_SolicitudId",
                        column: x => x.SolicitudId,
                        principalTable: "Solicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_UsuarioId",
                table: "Donaciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Entregas_SolicitudId",
                table: "Entregas",
                column: "SolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_DonacionId",
                table: "Solicitudes",
                column: "DonacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_UsuarioId",
                table: "Solicitudes",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
