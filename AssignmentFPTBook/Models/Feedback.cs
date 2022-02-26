namespace AssignmentFPTBook.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Feedback
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Username { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(400)]
        [Display(Name = "Content Feedback")]
        public string ContentFeedback { get; set; }


        [StringLength(30)]
        [Display(Name = "Date Sended")]
        public string DateSend { get; set; }

        public virtual Account Account { get; set; }
    }
}
