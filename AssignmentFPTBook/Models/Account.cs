namespace AssignmentFPTBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Fullname")]
        public string Fullname { get; set; }


        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress(ErrorMessage = "Invalid Email address")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [Display(Name = "Role")]
        public int State { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
