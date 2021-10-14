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
        [StringLength(50)]
        public string MaDDH { get; set; }

        public DateTime? NgayDat { get; set; }

        public bool? TinhTrangGiaoHang { get; set; }

        public DateTime? NgayGiao { get; set; }

        public bool? DaThanhToan { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        public int UuDai { get; set; }
        public bool? HuyDon { get; set; }
        public bool? TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonDatHang> ChiTietDonDatHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
