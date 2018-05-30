using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Actividad.Models;

namespace Actividad.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Actividad.Models.NivelUsuarios", b =>
                {
                    b.Property<int>("CodigoNivel")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DescripcionNivel");

                    b.Property<string>("NombreNivel");

                    b.HasKey("CodigoNivel");

                    b.ToTable("NivelesUsuarios");
                });

            modelBuilder.Entity("Actividad.Models.Usuarios", b =>
                {
                    b.Property<int>("CodigoUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApellidoUsuario");

                    b.Property<string>("ClaveUsuario");

                    b.Property<string>("CuentaUsuario");

                    b.Property<int?>("NivelUsuariosCodigoNivel");

                    b.Property<string>("NombreUsuario");

                    b.HasKey("CodigoUsuario");

                    b.HasIndex("NivelUsuariosCodigoNivel");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Actividad.Models.Usuarios", b =>
                {
                    b.HasOne("Actividad.Models.NivelUsuarios", "NivelUsuarios")
                        .WithMany("Usuarios")
                        .HasForeignKey("NivelUsuariosCodigoNivel");
                });
        }
    }
}
