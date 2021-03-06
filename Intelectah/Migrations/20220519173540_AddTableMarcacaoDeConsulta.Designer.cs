// <auto-generated />
using System;
using Intelectah.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Intelectah.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220519173540_AddTableMarcacaoDeConsulta")]
    partial class AddTableMarcacaoDeConsulta
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Intelectah.Models.CadastroDeExames", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdDoTipoDeExame")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observacoes")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CadastroDeExames");
                });

            modelBuilder.Entity("Intelectah.Models.MarcacaoDeConsulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataDaConsulta")
                        .HasColumnType("TEXT");

                    b.Property<int>("IdDoExameCadastrado")
                        .HasColumnType("INTEGER");

                    b.Property<string>("IdDoPaciente")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumeroDeProtocolo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MarcacaoDeConsulta");
                });

            modelBuilder.Entity("Intelectah.Models.Paciente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("Intelectah.Models.TiposDeExame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<string>("NomeDoTipoDeExame")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TiposDeExame");
                });
#pragma warning restore 612, 618
        }
    }
}
