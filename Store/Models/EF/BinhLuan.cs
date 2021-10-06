namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Key]
        [StringLength(50)]
        public string MaBL { get; set; }

        public string NoiDungBL { get; set; }

        [StringLength(50)]
        public string MaThanhVien { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
