using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dependency;

public partial class BookDBContext : DbContext
{
    public BookDBContext()
    {
    }

    public BookDBContext(DbContextOptions<BookDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBook> TbBooks { get; set; }

    public virtual DbSet<TbPurchase> TbPurchases { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GB6LURR;Database=Book;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbBook>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__TB_Book__3DE0C20787F6FFDD");

            entity.ToTable("TB_Book");

            entity.Property(e => e.BookAuthur).HasMaxLength(50);
            entity.Property(e => e.BookCover).HasMaxLength(300);
            entity.Property(e => e.BookName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<TbPurchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__TB_Purch__6B0A6BBECA445CF6");

            entity.ToTable("TB_Purchase");

            entity.Property(e => e.DateTime).HasColumnName("Date_Time");

            entity.HasOne(d => d.Book).WithMany(p => p.TbPurchases)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK_TB_Purchase_TB_Book");

            entity.HasOne(d => d.User).WithMany(p => p.TbPurchases)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_TB_Purchase_TB_User");
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__TB_User__1788CC4C0E05BA5F");

            entity.ToTable("TB_User");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(25);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
