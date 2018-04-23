namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StatusCategory")]
    public partial class StatusCategory
    {
        public int ID { get; set; }

        public int? Stt { get; set; }

        [Required(ErrorMessage = "Please enter Code")]
        [StringLength(16)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(250)]
        public string Name { get; set; }

        public int? Type { get; set; }

        [StringLength(50)]
        public string ForTable { get; set; }  

        public bool? ShowInAdmin { get; set; }

        public bool? ShowInClient { get; set; }

        public bool Status { get; set; }
    }
}
