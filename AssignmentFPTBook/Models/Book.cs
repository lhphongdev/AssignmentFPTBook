namespace AssignmentFPTBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [StringLength(10)]
        public string BookID { get; set; }

        [Required]
        [StringLength(100)]
        public string BookName { get; set; }

        [Required]
        [StringLength(10)]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(10)]
        public string AuthorID { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        [Required]
        [StringLength(500)]
        public string Image { get; set; }

        [Required]
        [StringLength(200)]
        public string ShortDesc { get; set; }

        [Required]
        [StringLength(500)]
        public string DetailDesc { get; set; }

        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
