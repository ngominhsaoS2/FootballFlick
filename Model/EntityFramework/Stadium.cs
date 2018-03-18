namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stadium")]
    public partial class Stadium
    {
        public long ID { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter Address")]
        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        [EmailAddress(ErrorMessage = "Please user your real Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Phone")]
        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
