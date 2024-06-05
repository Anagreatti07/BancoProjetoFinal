﻿// <auto-generated />
using System;
using ApiProjetoFinal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiProjetoFinal.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiProjetoFinal.Models.Objeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ObjetoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ObjetoCor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObjetoCor");

                    b.Property<DateTime>("ObjetoDtDesaparecimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("ObjetoDtDesaparecimento");

                    b.Property<DateTime?>("ObjetoDtEncontro")
                        .HasColumnType("datetime2")
                        .HasColumnName("ObjetoDtEncontro");

                    b.Property<string>("ObjetoFoto")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObjetoFoto");

                    b.Property<string>("ObjetoLocalDesaparecimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObjetoLocalDesaparecimento");

                    b.Property<string>("ObjetoNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObjetoNome");

                    b.Property<string>("ObjetoObservacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObjetoObservacao");

                    b.Property<byte>("ObjetoStatus")
                        .HasColumnType("tinyint")
                        .HasColumnName("ObjetoStatus");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Objeto");
                });

            modelBuilder.Entity("ApiProjetoFinal.Models.Observacoes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ObsevacaoId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ObjetoId")
                        .HasColumnType("int");

                    b.Property<string>("ObservacaoData")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoData");

                    b.Property<string>("ObservacaoDescricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoDescricao");

                    b.Property<string>("ObservacaoLocal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ObservacaoLocal");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ObjetoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Obsevacoes");
                });

            modelBuilder.Entity("ApiProjetoFinal.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UsuarioId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UsuarioEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioEmail");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioNome");

                    b.Property<string>("UsuarioSenha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioSenha");

                    b.Property<string>("UsuarioTelefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UsuarioTelefone");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ApiProjetoFinal.Models.Objeto", b =>
                {
                    b.HasOne("ApiProjetoFinal.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ApiProjetoFinal.Models.Observacoes", b =>
                {
                    b.HasOne("ApiProjetoFinal.Models.Objeto", "Objeto")
                        .WithMany()
                        .HasForeignKey("ObjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApiProjetoFinal.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objeto");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
