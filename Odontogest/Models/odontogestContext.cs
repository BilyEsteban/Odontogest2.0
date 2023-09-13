using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Odontogest.Models
{
    public class odontogestContext : DbContext
    {
       
        public odontogestContext(DbContextOptions<odontogestContext> options)
            : base(options)
        {
        }

        public  DbSet<Category> Categories { get; set; }
        public  DbSet<Inventory> Inventories { get; set; }
        public  DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=THE-CARROT;Database=odontogest;Integrated Security=True");
            }
        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__CBD74706662D23AD");

                entity.ToTable("Category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(250)
                    .HasColumnName("Name_Category");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.IdInventory)
                    .HasName("PK__Inventor__E6B6107B361D8002");

                entity.ToTable("Inventory");

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("creation_Date");

                entity.Property(e => e.DateUpdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Update");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.FkCategory).HasColumnName("Fk_Category");

                entity.Property(e => e.FkStore).HasColumnName("Fk_Store");

                entity.Property(e => e.Image).HasMaxLength(250);

                entity.Property(e => e.NameInventory)
                    .HasMaxLength(50)
                    .HasColumnName("Name_Inventory");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.QuantityAvailable)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("Quantity_Available");

                entity.Property(e => e.State).HasMaxLength(20);

                entity.Property(e => e.UserCreation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_creation");

                entity.Property(e => e.UserUpdate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Update");

                entity.HasOne(d => d.FkCategoryNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.FkCategory)
                    .HasConstraintName("Fk_Inventory_Category");

                entity.HasOne(d => d.FkStoreNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.FkStore)
                    .HasConstraintName("Fk_Inventory_store");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.IdStore)
                    .HasName("PK__Store__2A8EB278F30AFE24");

                entity.ToTable("Store");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.NameStore)
                    .HasMaxLength(250)
                    .HasColumnName("Name_Store");

                entity.Property(e => e.NewArticles)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("New_Articles");

                entity.Property(e => e.QuantityArticles)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("Quantity_articles");

                entity.Property(e => e.State).HasMaxLength(20);
            });
            
        }

    }
}
