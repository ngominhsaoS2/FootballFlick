namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter Content")]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public bool Status { get; set; }
    }
}
