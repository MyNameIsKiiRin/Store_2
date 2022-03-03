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
        [Display(Name = "ID")]
        public int MaSP { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSP { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Tắt")]
        public string TenTat { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên URL")]
        public string TenURL { get; set; }
        [Display(Name = "Đơn Giá Hiển Thị")]
        public decimal? DonGia { get; set; }
        [Display(Name = "Mô Tả")]
        public string MoTa { get; set; }
        [Display(Name = "Số Lượng Tồn")]
        public int? SoLuongTon { get; set; }
        [Display(Name = "Nhà Cung Cấp")]
        public int? MaNCC { get; set; }
        [Display(Name = "Nhà Sản Xuất")]
        public int? MaNSX { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public int? MaLoaiSP { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool? TrangThai { get; set; }
        [Display(Name = "Ngày Chỉnh Sửa")]
        public DateTime? NgayCapNhat { get; set; }
        [Display(Name = "Sản Phẩm Mới")]
        public bool? Moi { get; set; }
        [Display(Name = "Lượt Bình Luận")]
        public int? LuotBinhLuan { get; set; }
        [Display(Name = "Số Lần Mua")]
        public int? SoLanMua { get; set; }
        [Display(Name = "Hình Ảnh 1")]
        public string HinhAnh1 { get; set; }
        [Display(Name = "Hình Ảnh 2")]
        public string HinhAnh2 { get; set; }
        [Display(Name = "Hình Ảnh 3")]
        public string HinhAnh3 { get; set; }
        [Display(Name ="Đơn Giá Gốc")]
        public decimal? DonGiaGoc { get; set; }

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
