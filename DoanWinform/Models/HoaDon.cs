namespace DoanWinform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHDs = new HashSet<CTHD>();
            PhieuKhuyenMais = new HashSet<PhieuKhuyenMai>();
        }

        [Key]
        [StringLength(20)]
        public string MaHD { get; set; }

        public DateTime NgayLapHD { get; set; }

        [StringLength(20)]
        public string MaKH { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhieuKhuyenMai> PhieuKhuyenMais { get; set; }
    }
}
