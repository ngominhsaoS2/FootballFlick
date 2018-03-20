namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubAreaViewModel")]
    public partial class ClubAreaViewModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(250)]
        public string ClubName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long AreaID { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Status { get; set; }
    }
}
