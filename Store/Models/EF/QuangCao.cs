namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuangCao")]
    public partial class QuangCao
    {
        [Key]
        [StringLength(50)]
        public string MaQQ { get; set; }
        public string Image { get; set; }
        public bool TrangThai { get; set; }


    }
}
