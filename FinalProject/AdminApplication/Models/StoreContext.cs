using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AdminApplication.Models
{
    public partial class StoreContext : DbContext
    {
        public StoreContext()
        {
        }

        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; } = null!;
        public virtual DbSet<DanhGia> DanhGias { get; set; } = null!;
        public virtual DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public virtual DbSet<DonHang> DonHangs { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<SanPham> SanPhams { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-O14444V\\SQLEXPRESS;user Id = sa; password = 1; database = Store");
                optionsBuilder.UseSqlServer("server=YENNHI\\SQLEXPRESS;user Id = sa; password = 1; database = Store");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.UserAd);

                entity.ToTable("Admin");

                entity.Property(e => e.UserAd).HasColumnName("UserAD");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.MaCtdh);

                entity.ToTable("ChiTietDonHang");

                entity.HasIndex(e => e.MaCtdh, "IX_ChiTietDonHang")
                    .IsUnique();

                entity.Property(e => e.MaCtdh).HasColumnName("MaCTDH");

                entity.Property(e => e.MaDh)
                    .HasMaxLength(50)
                    .HasColumnName("MaDH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<DanhGia>(entity =>
            {
                entity.HasKey(e => e.MaDg);

                entity.ToTable("DanhGia");

                entity.Property(e => e.MaDg).HasColumnName("MaDG");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .HasColumnName("MaKH");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.MucDg).HasColumnName("MucDG");

                entity.Property(e => e.NhanXet).HasMaxLength(300);

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DanhGias)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DanhGia_KhachHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.DanhGias)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_DanhGia_SanPham");
            });

            modelBuilder.Entity<DanhMuc>(entity =>
            {
                entity.HasKey(e => e.MaDm);

                entity.ToTable("DanhMuc");

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.TenDm)
                    .HasMaxLength(200)
                    .HasColumnName("TenDM");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.ToTable("DonHang");

                entity.HasIndex(e => e.Id, "IX_DonHang")
                    .IsUnique();

                entity.Property(e => e.MaDh).HasColumnName("MaDH");

                entity.Property(e => e.DiaChiGiao).HasMaxLength(200);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NganHangNhan).HasMaxLength(50);

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.NgayLap).HasColumnType("datetime");

                entity.Property(e => e.NgayNhan).HasColumnType("datetime");

                entity.Property(e => e.PhuongThucTt)
                    .HasMaxLength(50)
                    .HasColumnName("PhuongThucTT");

                entity.Property(e => e.SoThe)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TongTien).HasColumnType("money");

                entity.Property(e => e.TrangThaiDh)
                    .HasMaxLength(50)
                    .HasColumnName("TrangThaiDH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHang_KhachHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh);

                entity.ToTable("KhachHang");

                entity.HasIndex(e => e.Id, "IX_KhachHang")
                    .IsUnique();

                entity.Property(e => e.MaKh).HasColumnName("MaKH");

                entity.Property(e => e.DiaChiKh)
                    .HasMaxLength(200)
                    .HasColumnName("DiaChiKH");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength();

                entity.Property(e => e.TenKh)
                    .HasMaxLength(150)
                    .HasColumnName("TenKH");

                entity.Property(e => e.UserId)
                    .HasMaxLength(50)
                    .HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.KhachHangs)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_User");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp).HasColumnName("MaSP");

                entity.Property(e => e.DacDiem).HasMaxLength(1000);

                entity.Property(e => e.Gia).HasColumnType("money");

                entity.Property(e => e.HinhAnh).HasMaxLength(50);

                entity.Property(e => e.MaDm).HasColumnName("MaDM");

                entity.Property(e => e.MoTa).HasMaxLength(1000);

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.Property(e => e.TenSp)
                    .HasMaxLength(1000)
                    .HasColumnName("TenSP");

                entity.Property(e => e.TrangThai).HasMaxLength(50);

                entity.HasOne(d => d.MaDmNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDm)
                    .HasConstraintName("FK_SanPham_DanhMuc");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("User");

                entity.HasIndex(e => e.Id, "IX_User")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
