namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Banner")]
    public partial class Banner
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select an Image")]
        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
