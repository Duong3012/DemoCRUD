namespace DemoCRUD.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("nguoidung")]
    public partial class nguoidung
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string hoTen { get; set; }

        [StringLength(200)]
        public string diachi { get; set; }

        [StringLength(11)]
        public string dienthoai { get; set; }

        [StringLength(50)]
        public string username { get; set; }

        [StringLength(50)]
        public string password { get; set; }
    }
}
