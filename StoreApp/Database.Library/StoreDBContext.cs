using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Library
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductOrdered> ProductOrdereds { get; set; }
        public virtual DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(40);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(28);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(28);

                entity.Property(e => e.Phone).HasMaxLength(12);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.TransactionNumber)
                    .HasName("PK__Customer__E733A2BEEA874EE5");

                entity.ToTable("CustomerOrder");

                entity.Property(e => e.TransactionNumber).ValueGeneratedNever();

                entity.Property(e => e.TransactionTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Custo__17C286CF");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Store__16CE6296");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.StoreId, e.ProductId })
                    .HasName("Pk_Inventory");

                entity.ToTable("Inventory");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__Produ__0C50D423");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.StartTime })
                    .HasName("Pk_Price");

                entity.ToTable("Price");

                entity.Property(e => e.StartTime)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price1)
                    .HasColumnType("money")
                    .HasColumnName("Price");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Prices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Price__ProductId__0880433F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ProductOrdered>(entity =>
            {
                entity.HasKey(e => new { e.TransactionNumber, e.ProductId })
                    .HasName("Pk_Order");

                entity.ToTable("ProductOrdered");

                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductOrdereds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductOr__Produ__10216507");

                entity.HasOne(d => d.TransactionNumberNavigation)
                    .WithMany(p => p.ProductOrdereds)
                    .HasForeignKey(d => d.TransactionNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductOr__Trans__18B6AB08");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("ZIP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
