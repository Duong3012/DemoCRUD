namespace DemoCRUD.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("theloai")]
    public partial class theloai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public theloai()
        {
            sanphams = new HashSet<sanpham>();
        }

        [Key]
        public int maloai { get; set; }

        [StringLength(100)]
        public string tenloai { get; set; }

        [StringLength(200)]
        public string mota { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }
    }
}
