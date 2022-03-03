namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [StringLength(50)]
        public string AdminID { get; set; }

        [StringLength(50)]
        public string MatKhau { get; set; }
    }
}
