namespace DoanWinform.Models
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
            CTDDHs = new HashSet<CTDDH>();
        }

        [Key]
        [StringLength(20)]
        public string MADDH { get; set; }

        public DateTime NgayDatHang { get; set; }

        public DateTime NgayGiaoHang { get; set; }

        [Column(TypeName = "money")]
        public decimal? TongTien { get; set; }

        [StringLength(20)]
        public string MaNSX { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDHs { get; set; }

        public virtual NhaSanXuat NhaSanXuat { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
