namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietPhieuNhap")]
    public partial class ChiTietPhieuNhap
    {
        [Key]
        [Display(Name = "ID")]
        public int MaCTPN { get; set; }
        [Display(Name = "Mã Phiếu Nhập")]
        public int? MaPN { get; set; }
        [Display(Name = "Mã Sản Phẩm")]
        public int? MaSP { get; set; }
        [Display(Name = "Số Lượng Nhập")]
        public int? SoLuongNhap { get; set; }
        [Display(Name = "Đơn Giá Nhập")]
        public decimal? DonGiaNhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
