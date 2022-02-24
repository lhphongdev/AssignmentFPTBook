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

        [Required]
        [StringLength(10)]
        [Display(Name = "Book ID")]
        public string BookID { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Book name")]
        public string BookName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Category ID")]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Author ID")]
        public string AuthorID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Price")]
        public int Price { get; set; }



        [DataType(DataType.Upload)]
        [Display(Name = "Book Image")]
        public string UrlImage { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Short Description")]
        public string ShortDesc { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Detail Description")]
        public string DetailDesc { get; set; }


        public virtual Author Author { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
