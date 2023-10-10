﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Odontogest.Models;

namespace Odontogest.Migrations
{
    [DbContext(typeof(odontogestContext))]
    [Migration("20231009193731_Inventarios")]
    partial class Inventarios
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Odontogest.Models.Category", b =>
                {
                    b.Property<int>("IdCategory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name_Category");

                    b.HasKey("IdCategory")
                        .HasName("PK__Category__CBD74706662D23AD");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Odontogest.Models.Inventory", b =>
                {
                    b.Property<int>("IdInventory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreationDate")
                        .HasColumnType("datetime")
                        .HasColumnName("creation_Date");

                    b.Property<DateTime?>("DateUpdate")
                        .HasColumnType("datetime")
                        .HasColumnName("Date_Update");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("FkCategory")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Category");

                    b.Property<int?>("FkStore")
                        .HasColumnType("int")
                        .HasColumnName("Fk_Store");

                    b.Property<string>("Image")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameInventory")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name_Inventory");

                    b.Property<decimal?>("Price")
                        .HasColumnType("money");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal?>("QuantityAvailable")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Quantity_Available");

                    b.Property<string>("State")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UserCreation")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("User_creation");

                    b.Property<string>("UserUpdate")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("User_Update");

                    b.HasKey("IdInventory")
                        .HasName("PK__Inventor__E6B6107B361D8002");

                    b.HasIndex("FkCategory");

                    b.HasIndex("FkStore");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("Odontogest.Models.Store", b =>
                {
                    b.Property<int>("IdStore")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NameStore")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Name_Store");

                    b.Property<decimal>("NewArticles")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("New_Articles");

                    b.Property<decimal>("QuantityArticles")
                        .HasColumnType("numeric(18,2)")
                        .HasColumnName("Quantity_articles");

                    b.Property<string>("State")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdStore")
                        .HasName("PK__Store__2A8EB278F30AFE24");

                    b.ToTable("Store");
                });

            modelBuilder.Entity("Odontogest.Models.Inventory", b =>
                {
                    b.HasOne("Odontogest.Models.Category", "FkCategoryNavigation")
                        .WithMany("Inventories")
                        .HasForeignKey("FkCategory")
                        .HasConstraintName("Fk_Inventory_Category");

                    b.HasOne("Odontogest.Models.Store", "FkStoreNavigation")
                        .WithMany("Inventories")
                        .HasForeignKey("FkStore")
                        .HasConstraintName("Fk_Inventory_store");

                    b.Navigation("FkCategoryNavigation");

                    b.Navigation("FkStoreNavigation");
                });

            modelBuilder.Entity("Odontogest.Models.Category", b =>
                {
                    b.Navigation("Inventories");
                });

            modelBuilder.Entity("Odontogest.Models.Store", b =>
                {
                    b.Navigation("Inventories");
                });
#pragma warning restore 612, 618
        }
    }
}