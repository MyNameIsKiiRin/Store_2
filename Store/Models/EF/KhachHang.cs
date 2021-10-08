namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            DonDatHangs = new HashSet<DonDatHang>();
        }

        [Key]
        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Bạn Chưa Nhập Tên")]
        public string TenKH { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Bạn Chưa Nhập Địa Chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [EmailAddress(ErrorMessage ="Sai Định Dạng Email")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Sai Định Dạng Email")]
        [Required(ErrorMessage = "Bạn Chưa Nhập Email")]
        public string Email { get; set; }

        [StringLength(15)]
        [Required(ErrorMessage = "Bạn Chưa Nhập Số Điện Thoại")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Sai Định Dạng Số Điện Thoại")]
        [Phone(ErrorMessage ="Sai Định Dạng Số Điện Thoại")]
        public string SoDienThoai { get; set; }

        [StringLength(50)]
        public string MaThanhVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }

        public virtual ThanhVien ThanhVien { get; set; }
    }
}
