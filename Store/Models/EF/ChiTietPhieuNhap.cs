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
        [StringLength(50)]
        public string MaCTPN { get; set; }

        [StringLength(50)]
        public string MaPN { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        public int? SoLuongNhap { get; set; }

        public decimal? DonGiaNhap { get; set; }

        public virtual PhieuNhap PhieuNhap { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
