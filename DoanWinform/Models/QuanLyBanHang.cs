using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DoanWinform.Models
{
    public partial class QuanLyBanHang : DbContext
    {
        public QuanLyBanHang()
            : base("name=QuanLyBanHang")
        {
        }

        public virtual DbSet<CTDDH> CTDDHs { get; set; }
        public virtual DbSet<CTHD> CTHDs { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<PhieuKhuyenMai> PhieuKhuyenMais { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTDDH>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CTDDH>()
                .Property(e => e.MADDH)
                .IsUnicode(false);

            modelBuilder.Entity<CTDDH>()
                .Property(e => e.DonGiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.GiaBan)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTHD>()
                .Property(e => e.ThanhTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.MADDH)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.TongTien)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.MaNSX)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<DonDatHang>()
                .HasMany(e => e.CTDDHs)
                .WithRequired(e => e.DonDatHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.HoaDon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiSanPham>()
                .Property(e => e.MaLSP)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasOptional(e => e.TaiKhoan)
                .WithRequired(e => e.NhanVien);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.MaNSX)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhaSanXuat>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhuyenMai>()
                .Property(e => e.MaKM)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhuyenMai>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhuyenMai>()
                .Property(e => e.MaHD)
                .IsUnicode(false);

            modelBuilder.Entity<PhieuKhuyenMai>()
                .Property(e => e.GiaKM)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.MaLSP)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DVT)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.GiaSP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTDDHs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SanPham>()
                .HasMany(e => e.CTHDs)
                .WithRequired(e => e.SanPham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.TenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<TaiKhoan>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);
        }
    }
}
