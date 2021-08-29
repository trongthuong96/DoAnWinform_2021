namespace DoanWinform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhieuKhuyenMai")]
    public partial class PhieuKhuyenMai
    {
        [Key]
        [StringLength(50)]
        public string MaKM { get; set; }

        [StringLength(10)]
        public string MaNV { get; set; }

        [StringLength(20)]
        public string MaHD { get; set; }

        [Column(TypeName = "money")]
        public decimal GiaKM { get; set; }

        public DateTime NgayBatDau { get; set; }

        public DateTime NgayKetThuc { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
