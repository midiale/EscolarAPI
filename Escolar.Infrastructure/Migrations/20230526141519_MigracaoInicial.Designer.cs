﻿// <auto-generated />
using System;
using Escolar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Escolar.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230526141519_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Escolar.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EscolaId")
                        .HasColumnType("int");

                    b.Property<int>("ExAluno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Mae")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Serie")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("EscolaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Escolar.Domain.Entities.Escola", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImagemUrl")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Escolas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImagemUrl = "ccs.jpg",
                            Nome = "Caminhos do Saber"
                        },
                        new
                        {
                            Id = 2,
                            ImagemUrl = "jp.jpg",
                            Nome = "Jean Piaget"
                        },
                        new
                        {
                            Id = 3,
                            ImagemUrl = "cult.jpg",
                            Nome = "Cultura"
                        });
                });

            modelBuilder.Entity("Escolar.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("Escolar.Domain.Entities.Escola", "Escola")
                        .WithMany("Alunos")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escola");
                });

            modelBuilder.Entity("Escolar.Domain.Entities.Escola", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
