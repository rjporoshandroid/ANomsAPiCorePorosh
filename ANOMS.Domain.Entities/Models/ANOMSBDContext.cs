using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ANOMS.Domain.Entities.Models
{
    public partial class ANOMSBDContext : DbContext
    {
        public ANOMSBDContext()
        {
        }

        public ANOMSBDContext(DbContextOptions<ANOMSBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<NCategory> NCategory { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<PCategory> PCategory { get; set; }
        public virtual DbSet<PrdtPackage> PrdtPackage { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<Usersd> Usersd { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Initial Catalog=ANOMSBD;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrndId);

                entity.Property(e => e.BrndId).HasColumnName("brnd_ID");

                entity.Property(e => e.BrndName)
                    .HasColumnName("brnd_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.PcId)
                    .HasConstraintName("FK_Brand_P_Category");

                entity.HasOne(d => d.UserByNavigation)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.UserBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Brand_Usersd");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.PcId, e.PrdtId, e.BrndId, e.PkgId });

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.PrdtId).HasColumnName("prdt_ID");

                entity.Property(e => e.BrndId).HasColumnName("brnd_ID");

                entity.Property(e => e.PkgId).HasColumnName("pkg_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpDate)
                    .HasColumnName("exp_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalQunty).HasColumnName("total_Qunty");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Brnd)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.BrndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Brand");

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.PcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_P_Category");

                entity.HasOne(d => d.Pkg)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.PkgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Prdt_Package");

                entity.HasOne(d => d.Prdt)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.PrdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Inventory_Product");
            });

            modelBuilder.Entity<NCategory>(entity =>
            {
                entity.HasKey(e => e.NId);

                entity.ToTable("N_Category");

                entity.Property(e => e.NId).HasColumnName("n_ID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.NType)
                    .HasColumnName("n_Type")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.HasKey(e => e.NtfnId);

                entity.Property(e => e.NtfnId).HasColumnName("ntfn_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.MsgBang)
                    .HasColumnName("msg_bang")
                    .HasMaxLength(250);

                entity.Property(e => e.NId).HasColumnName("n_ID");

                entity.Property(e => e.NMsg)
                    .HasColumnName("n_msg")
                    .HasMaxLength(250);

                entity.Property(e => e.NtfnDateMsg)
                    .HasColumnName("ntfn_date_msg")
                    .HasColumnType("datetime");

                entity.Property(e => e.NtfnFor).HasColumnName("ntfn_for");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.Property(e => e.Validity)
                    .HasColumnName("validity")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.N)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.NId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_N_Category");

                entity.HasOne(d => d.NtfnForNavigation)
                    .WithMany(p => p.NotificationsNtfnForNavigation)
                    .HasForeignKey(d => d.NtfnFor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Usersd1");

                entity.HasOne(d => d.UserByNavigation)
                    .WithMany(p => p.NotificationsUserByNavigation)
                    .HasForeignKey(d => d.UserBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Usersd");
            });

            modelBuilder.Entity<PCategory>(entity =>
            {
                entity.HasKey(e => e.PcId);

                entity.ToTable("P_Category");

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.PcName)
                    .HasColumnName("pc_Name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PrdtPackage>(entity =>
            {
                entity.HasKey(e => e.PkgId);

                entity.ToTable("Prdt_Package");

                entity.Property(e => e.PkgId).HasColumnName("pkg_ID");

                entity.Property(e => e.BrndId).HasColumnName("brnd_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImageBution)
                    .HasColumnName("image_bution")
                    .HasMaxLength(50);

                entity.Property(e => e.ImageId).HasColumnName("image_ID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.MinQuantity).HasColumnName("min_Quantity");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.PkgGrade)
                    .HasColumnName("pkg_Grade")
                    .HasMaxLength(50);

                entity.Property(e => e.PkgName)
                    .IsRequired()
                    .HasColumnName("pkg_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.PrdtId).HasColumnName("prdt_ID");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Brnd)
                    .WithMany(p => p.PrdtPackage)
                    .HasForeignKey(d => d.BrndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prdt_Package_Brand");

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.PrdtPackage)
                    .HasForeignKey(d => d.PcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prdt_Package_P_Category");

                entity.HasOne(d => d.Prdt)
                    .WithMany(p => p.PrdtPackage)
                    .HasForeignKey(d => d.PrdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prdt_Package_Product");

                entity.HasOne(d => d.UserByNavigation)
                    .WithMany(p => p.PrdtPackage)
                    .HasForeignKey(d => d.UserBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prdt_Package_Usersd");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.HasKey(e => new { e.PcId, e.PrdtId, e.BrndId, e.PkgId });

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.PrdtId).HasColumnName("prdt_ID");

                entity.Property(e => e.BrndId).HasColumnName("brnd_ID");

                entity.Property(e => e.PkgId).HasColumnName("pkg_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.InPrice).HasColumnName("in_Price");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PrevPrice).HasColumnName("prevPrice");

                entity.Property(e => e.SellPrice).HasColumnName("sell_Price");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Brnd)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.BrndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_Brand");

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.PcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_P_Category");

                entity.HasOne(d => d.Pkg)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.PkgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_Prdt_Package");

                entity.HasOne(d => d.Prdt)
                    .WithMany(p => p.Price)
                    .HasForeignKey(d => d.PrdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Price_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.PrdtId);

                entity.Property(e => e.PrdtId)
                    .HasColumnName("prdt_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.PrdtName)
                    .HasColumnName("prdt_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Prdt)
                    .WithOne(p => p.InversePrdt)
                    .HasForeignKey<Product>(d => d.PrdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Product");
            });

            modelBuilder.Entity<ProductOrder>(entity =>
            {
                entity.HasKey(e => e.OId);

                entity.ToTable("Product_Order");

                entity.Property(e => e.OId).HasColumnName("o_ID");

                entity.Property(e => e.BrndId).HasColumnName("brnd_ID");

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderBy)
                    .HasColumnName("orderBy")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderNo).HasColumnName("orderNo");

                entity.Property(e => e.PaymentSta)
                    .HasColumnName("paymentSta")
                    .HasMaxLength(50);

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.PkgId).HasColumnName("pkg_ID");

                entity.Property(e => e.PrdtId).HasColumnName("prdt_ID");

                entity.Property(e => e.UserBy).HasColumnName("userBy");

                entity.HasOne(d => d.Brnd)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.BrndId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order_Brand");

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.PcId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order_P_Category");

                entity.HasOne(d => d.Pkg)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.PkgId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order_Prdt_Package");

                entity.HasOne(d => d.Prdt)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.PrdtId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order_Product");

                entity.HasOne(d => d.UserByNavigation)
                    .WithMany(p => p.ProductOrder)
                    .HasForeignKey(d => d.UserBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Order_Usersd");
            });

            modelBuilder.Entity<UserDetails>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.SId });

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SId).HasColumnName("s_ID");

                entity.Property(e => e.DueStatus)
                    .HasColumnName("due_Status")
                    .HasMaxLength(50);

                entity.Property(e => e.EnrollFrom)
                    .HasColumnName("enrollFrom")
                    .HasMaxLength(50);

                entity.Property(e => e.Entrydate)
                    .HasColumnName("entrydate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.TotalAroundOrder).HasColumnName("total_Around_Order");

                entity.Property(e => e.TotalTimeOrdered).HasColumnName("total_Time_Ordered");

                entity.Property(e => e.UserBy).HasColumnName("userBy");
            });

            modelBuilder.Entity<Usersd>(entity =>
            {
                entity.HasIndex(e => e.SId)
                    .HasName("IX_Usersd")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Contact)
                    .HasColumnName("contact")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.EntryDate)
                    .HasColumnName("entryDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifyDate)
                    .HasColumnName("modifyDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.PcId).HasColumnName("pc_ID");

                entity.Property(e => e.SId).HasColumnName("s_ID");

                entity.Property(e => e.SName)
                    .HasColumnName("s_Name")
                    .HasMaxLength(50);

                entity.Property(e => e.TId).HasColumnName("t_ID");

                entity.Property(e => e.UserBy)
                    .HasColumnName("userBy")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Pc)
                    .WithMany(p => p.Usersd)
                    .HasForeignKey(d => d.PcId)
                    .HasConstraintName("FK_Usersd_P_Category");

                entity.HasOne(d => d.T)
                    .WithMany(p => p.Usersd)
                    .HasForeignKey(d => d.TId)
                    .HasConstraintName("FK_Usersd_User_Type");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.HasKey(e => e.TId);

                entity.ToTable("User_Type");

                entity.Property(e => e.TId).HasColumnName("t_ID");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.TName)
                    .HasColumnName("t_Name")
                    .HasMaxLength(50);
            });
        }
    }
}
