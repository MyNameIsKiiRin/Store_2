namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CauHinh")]
    public partial class CauHinh
    {
        [Key]
        [StringLength(50)]
        public string MaCH { get; set; }

        [StringLength(50)]
        public string ManHinh { get; set; }

        [StringLength(50)]
        public string HeDieuHanh { get; set; }

        [StringLength(50)]
        public string Camera { get; set; }

        [StringLength(50)]
        public string CPU { get; set; }

        [StringLength(10)]
        public string GPU { get; set; }

        [StringLength(10)]
        public string Ram { get; set; }

        [StringLength(10)]
        public string Rom { get; set; }

        [StringLength(10)]
        public string Pin { get; set; }

        [StringLength(50)]
        public string MaSP { get; set; }
        [StringLength(250)]
        public string TenCH { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
