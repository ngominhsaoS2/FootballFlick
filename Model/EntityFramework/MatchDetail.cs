namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchDetail")]
    public partial class MatchDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(16)]
        public string MatchCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PlayerID { get; set; }

        public int? Goal { get; set; }

        public int? Assist { get; set; }

        public int? YellowCard { get; set; }

        public int? RedCard { get; set; }

        public int? TimeOccur { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
