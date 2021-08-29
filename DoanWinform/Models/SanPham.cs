namespace DoanWinform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            CTDDHs = new HashSet<CTDDH>();
            CTHDs = new HashSet<CTHD>();
        }

        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [StringLength(20)]
        public string MaLSP { get; set; }

        [Required]
        [StringLength(150)]
        public string TenSP { get; set; }

        [StringLength(10)]
        public string DVT { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaSP { get; set; }

        [StringLength(300)]
        public string ChiTietSP { get; set; }

        public int SoLuong { get; set; }

        [Column(TypeName = "image")]
        public byte[] HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDDH> CTDDHs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHDs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
