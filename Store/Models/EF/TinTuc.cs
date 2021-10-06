namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [StringLength(50)]
        public string MaTT { get; set; }

        public string TieuDe { get; set; }

        public DateTime? NgayDang { get; set; }

        public bool? TinKhuyenMai { get; set; }

        public bool? TinMoi { get; set; }

        public bool? HuongDanKyThuat { get; set; }

        [StringLength(100)]
        public string AnhBia { get; set; }
        public bool TrangThai { get; set; }
        public string Link { get; set; }
    }
}
