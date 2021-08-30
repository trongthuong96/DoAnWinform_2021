namespace DoanWinform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MaCTHD { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string MaHD { get; set; }

        public int SLMua { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaBan { get; set; }

        [Column(TypeName = "money")]
        public decimal ThanhTien { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
