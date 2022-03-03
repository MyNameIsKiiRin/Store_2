namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThanhVien")]
    public partial class ThanhVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhVien()
        {
            BinhLuans = new HashSet<BinhLuan>();
            KhachHangs = new HashSet<KhachHang>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaThanhVien { get; set; }

        [StringLength(50)]
        [Display(Name = "Họ Tên")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài Khoản")]
        public string TaiKhoan { get; set; }

        [StringLength(50)]
        
        [Display(Name = "Mật Khẩu")]
        public string MatKhau { get; set; }

        [StringLength(100)]
        [Display(Name = "Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        
        public string Email { get; set; }

        [StringLength(15)]
        [Display(Name = "Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
