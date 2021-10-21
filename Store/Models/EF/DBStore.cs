using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Store.Models.EF
{
    public partial class DBStore : DbContext
    {
        public DBStore()
            : base("name=DBStore")
        {
        }

        public virtual DbSet<BinhLuan> BinhLuans { get; set; }
        public virtual DbSet<CauHinh> CauHinhs { get; set; }
        public virtual DbSet<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }
        public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<LoaiThanhVien> LoaiThanhViens { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<NhaSanXuat> NhaSanXuats { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<Slide> Slides { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<ThanhVien> ThanhViens { get; set; }
        public virtual DbSet<QuangCao> QuangCaos { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CauHinh>()
                .Property(e => e.CPU)
                .IsUnicode(false);

            modelBuilder.Entity<CauHinh>()
                .Property(e => e.GPU)
                .IsFixedLength();

            modelBuilder.Entity<CauHinh>()
                .Property(e => e.Ram)
                .IsUnicode(false);

            modelBuilder.Entity<CauHinh>()
                .Property(e => e.Rom)
                .IsUnicode(false);

            modelBuilder.Entity<CauHinh>()
                .Property(e => e.Pin)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietDonDatHang>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<ChiTietPhieuNhap>()
                .Property(e => e.DonGiaNhap)
                .HasPrecision(18, 0);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<NhaCungCap>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<SanPham>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TinTuc>()
                .Property(e => e.AnhBia)
                .IsUnicode(false);

            modelBuilder.Entity<ThanhVien>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);
        }
    }
}
