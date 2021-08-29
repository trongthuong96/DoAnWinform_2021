namespace DoanWinform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTDDH")]
    public partial class CTDDH
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        public int SLDat { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaSP { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string MADDH { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGiaBan { get; set; }

        public virtual DonDatHang DonDatHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
