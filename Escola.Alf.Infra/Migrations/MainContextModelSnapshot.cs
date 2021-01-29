﻿// <auto-generated />
using System;
using Escola.Alf.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escola.Alf.Infra.Migrations
{
    [DbContext(typeof(MainContext))]
    partial class MainContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Escola.Alf.Domain.ComplexType.Prova", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AlunoId")
                        .HasColumnType("int");

                    b.Property<bool>("Deletado")
                        .HasColumnType("bit");

                    b.Property<int?>("ProvaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("ProvaId");

                    b.ToTable("Prova");
                });

            modelBuilder.Entity("Escola.Alf.Domain.Entities.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data de Nascimento");

                    b.Property<bool>("Deletado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("varchar(60)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ProvaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Escola.Alf.Domain.ComplexType.Prova", b =>
                {
                    b.HasOne("Escola.Alf.Domain.Entities.Aluno", null)
                        .WithMany("Provas")
                        .HasForeignKey("AlunoId");

                    b.HasOne("Escola.Alf.Domain.ComplexType.Prova", null)
                        .WithMany("Questoes")
                        .HasForeignKey("ProvaId");
                });

            modelBuilder.Entity("Escola.Alf.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("Escola.Alf.Domain.ComplexType.Prova", "Prova")
                        .WithMany()
                        .HasForeignKey("ProvaId");

                    b.Navigation("Prova");
                });

            modelBuilder.Entity("Escola.Alf.Domain.ComplexType.Prova", b =>
                {
                    b.Navigation("Questoes");
                });

            modelBuilder.Entity("Escola.Alf.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("Provas");
                });
#pragma warning restore 612, 618
        }
    }
}