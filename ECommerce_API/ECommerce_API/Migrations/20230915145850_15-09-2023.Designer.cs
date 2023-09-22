﻿// <auto-generated />
using System;
using ECommerce_API.Datas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerce_API.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20230915145850_15-09-2023")]
    partial class _15092023
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ECommerce_API.Models.AvaliacaoProd", b =>
                {
                    b.Property<int>("Id_Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Rate"));

                    b.Property<string>("Comment_Rate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Star_Rate")
                        .HasColumnType("int");

                    b.Property<string>("Title_Rate")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Rate");

                    b.ToTable("AvaliacoesProd");
                });

            modelBuilder.Entity("ECommerce_API.Models.Cliente", b =>
                {
                    b.Property<int>("Id_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Client"));

                    b.Property<string>("Mail_Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password_Client")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Client");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ECommerce_API.Models.Compra", b =>
                {
                    b.Property<int>("Id_Compra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Compra"));

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data_Compra")
                        .HasColumnType("datetime2");

                    b.Property<int>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<int>("MetPag_Compra")
                        .HasColumnType("int");

                    b.Property<float>("QuantProd_Compra")
                        .HasColumnType("real");

                    b.Property<float>("Total_Compra")
                        .HasColumnType("real");

                    b.HasKey("Id_Compra");

                    b.HasIndex("ClienteId");

                    b.HasIndex("HistoricoId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ECommerce_API.Models.Estoque", b =>
                {
                    b.Property<int>("Id_Estoque")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Estoque"));

                    b.Property<int>("Quant_Estoque")
                        .HasColumnType("int");

                    b.HasKey("Id_Estoque");

                    b.ToTable("Estoques");
                });

            modelBuilder.Entity("ECommerce_API.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id_Fornecedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Fornecedor"));

                    b.Property<string>("Contato_Fornecedor")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Desc_Fornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<string>("Nome_Fornecedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Social_Fornecedor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Fornecedor");

                    b.HasIndex("EstoqueId");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ECommerce_API.Models.Historico", b =>
                {
                    b.Property<int>("Id_Historico")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Historico"));

                    b.HasKey("Id_Historico");

                    b.ToTable("Historicos");
                });

            modelBuilder.Entity("ECommerce_API.Models.HistoricoProd", b =>
                {
                    b.Property<int?>("HistoricoId")
                        .HasColumnType("int");

                    b.Property<int?>("ProdutoId")
                        .HasColumnType("int");

                    b.HasKey("HistoricoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("HistoricosProds");
                });

            modelBuilder.Entity("ECommerce_API.Models.ImgProd", b =>
                {
                    b.Property<int>("Id_Img")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Img"));

                    b.Property<string>("Name_Img")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProdutoId")
                        .HasColumnType("int");

                    b.Property<string>("Src_Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_Img");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ImgProds");
                });

            modelBuilder.Entity("ECommerce_API.Models.Produto", b =>
                {
                    b.Property<int>("Id_Prod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Prod"));

                    b.Property<string>("CodeBar_Prod")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int?>("EstoqueId")
                        .HasColumnType("int");

                    b.Property<int?>("FornecedorId")
                        .HasColumnType("int");

                    b.Property<string>("Name_Prod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Val_Prod")
                        .HasColumnType("float");

                    b.HasKey("Id_Prod");

                    b.HasIndex("EstoqueId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ECommerce_API.Models.Usuario", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_User"));

                    b.Property<string>("CPF_User")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("Email_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name_User")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password_User")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id_User");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ECommerce_API.Models.Compra", b =>
                {
                    b.HasOne("ECommerce_API.Models.Cliente", "Cliente_Compra")
                        .WithMany("Compras_Client")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ECommerce_API.Models.Historico", "Historico_Compra")
                        .WithMany("Compras_Historico")
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Cliente_Compra");

                    b.Navigation("Historico_Compra");
                });

            modelBuilder.Entity("ECommerce_API.Models.Fornecedor", b =>
                {
                    b.HasOne("ECommerce_API.Models.Estoque", "Estoque")
                        .WithMany("Fornecedores_Estoque")
                        .HasForeignKey("EstoqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("ECommerce_API.Models.HistoricoProd", b =>
                {
                    b.HasOne("ECommerce_API.Models.Historico", "Historico")
                        .WithMany("Produtos_Historico")
                        .HasForeignKey("HistoricoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ECommerce_API.Models.Produto", "Produto")
                        .WithMany("Historicos_Prod")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Historico");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("ECommerce_API.Models.ImgProd", b =>
                {
                    b.HasOne("ECommerce_API.Models.Produto", "Produto_Img")
                        .WithMany("Imgs_Prod")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto_Img");
                });

            modelBuilder.Entity("ECommerce_API.Models.Produto", b =>
                {
                    b.HasOne("ECommerce_API.Models.Estoque", "Estoque_Prod")
                        .WithMany("Produtos_Estoque")
                        .HasForeignKey("EstoqueId");

                    b.HasOne("ECommerce_API.Models.Fornecedor", "Fornecedor")
                        .WithMany("Produtos_Fornecedor")
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Estoque_Prod");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("ECommerce_API.Models.Cliente", b =>
                {
                    b.Navigation("Compras_Client");
                });

            modelBuilder.Entity("ECommerce_API.Models.Estoque", b =>
                {
                    b.Navigation("Fornecedores_Estoque");

                    b.Navigation("Produtos_Estoque");
                });

            modelBuilder.Entity("ECommerce_API.Models.Fornecedor", b =>
                {
                    b.Navigation("Produtos_Fornecedor");
                });

            modelBuilder.Entity("ECommerce_API.Models.Historico", b =>
                {
                    b.Navigation("Compras_Historico");

                    b.Navigation("Produtos_Historico");
                });

            modelBuilder.Entity("ECommerce_API.Models.Produto", b =>
                {
                    b.Navigation("Historicos_Prod");

                    b.Navigation("Imgs_Prod");
                });
#pragma warning restore 612, 618
        }
    }
}
