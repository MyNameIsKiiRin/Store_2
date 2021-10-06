namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            BinhLuans = new HashSet<BinhLuan>();
            CauHinhs = new HashSet<CauHinh>();
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
            ChiTietPhieuNhaps = new HashSet<ChiTietPhieuNhap>();
        }

        [Key]
        [StringLength(50)]
        public string MaSP { get; set; }

        public string TenSP { get; set; }
        [StringLength(250)]
        public string TenTat { get; set; }
        [StringLength(250)]
        public string TenURL { get; set; }

        public decimal? DonGia { get; set; }

        public string MoTa { get; set; }

        public int? SoLuongTon { get; set; }

        [StringLength(50)]
        public string MaNCC { get; set; }

        [StringLength(50)]
        public string MaNSX { get; set; }

        [StringLength(50)]
        public string MaLoaiSP { get; set; }

        public bool? TrangThai { get; set; }

        public DateTime? NgayCapNhat { get; set; }

        public bool? Moi { get; set; }

        public int? LuotXem { get; set; }

        public int? LuotBinhChon { get; set; }

        public int? LuotBinhLuan { get; set; }

        public int? SoLanMua { get; set; }
        public string HinhAnh1 { get; set; }

        public string HinhAnh2 { get; set; }

        public string HinhAnh3 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHinh> CauHinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }
    }
}
