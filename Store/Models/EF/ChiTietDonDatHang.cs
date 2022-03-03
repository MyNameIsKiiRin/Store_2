namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonDatHang")]
    public partial class ChiTietDonDatHang
    {
        [Key]
        [Display(Name = "ID")]
        public int MaCTDDH { get; set; }
        [Display(Name = "Đơn Đặt Hàng")]
        public int? MaDDH { get; set; }
        [Display(Name = "Mã Sản Phẩm")]
        public int? MaSP { get; set; }
        [Display(Name = "Tên Sản Phẩm")]
        public string TenSP { get; set; }
        [Display(Name = "Số Lượng")]
        public int? SoLuong { get; set; }
        [Display(Name = "Đơn Giá")]
        public decimal? DonGia { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
