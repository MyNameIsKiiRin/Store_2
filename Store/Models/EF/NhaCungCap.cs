﻿namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhaCungCap")]
    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            PhieuNhaps = new HashSet<PhieuNhap>();
            SanPhams = new HashSet<SanPham>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaNCC { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên Nhà Cung Cấp")]
        public string TenNCC { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPham> SanPhams { get; set; }
    }
}
