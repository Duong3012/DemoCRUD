namespace DemoCRUD.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [Key]
        public int masp { get; set; }

        public int maloai { get; set; }

        [StringLength(100)]
        public string tensp { get; set; }

        public int? soluong { get; set; }

        public int? giatien { get; set; }

        [StringLength(40)]
        public string hinhanh { get; set; }

        public virtual theloai theloai { get; set; }
    }
}
