namespace AssignmentFPTBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Books = new HashSet<Book>();
        }

        [Required]
        [StringLength(10)]
        [Display(Name = "Category ID")]
        public string CategoryID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
    }
}
