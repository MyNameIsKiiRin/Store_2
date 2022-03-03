namespace Store.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonDatHang")]
    public partial class DonDatHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonDatHang()
        {
            ChiTietDonDatHangs = new HashSet<ChiTietDonDatHang>();
        }

        [Key]
        [Display(Name = "ID")]
        public int MaDDH { get; set; }
        [Display(Name = "Ngày Đặt")]
        public DateTime? NgayDat { get; set; }
        [Display(Name = "Tình Trạng Giao Hàng")]
        public bool? TinhTrangGiaoHang { get; set; }
        [Display(Name = "Ngày Giao")]
        public DateTime? NgayGiao { get; set; }
        [Display(Name = "Đã Thanh Toán")]
        public bool? DaThanhToan { get; set; }
        [Display(Name = "Khách Hàng")]
        public int? MaKH { get; set; }
        [Display(Name = "Ưu Đãi")]
        public int? UuDai { get; set; }
        [Display(Name = "HỦy Đơn")]
        public bool? HuyDon { get; set; }
        [Display(Name = "Trạng Thái")]
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
