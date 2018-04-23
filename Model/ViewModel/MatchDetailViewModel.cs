namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchDetailViewModel")]
    public partial class MatchDetailViewModel
    {
        [Key]
        [Column(Order = 0)]
        public long MatchID { get; set; }

        [StringLength(16)]
        public string MatchCode { get; set; }

        [StringLength(250)]
        public string MatchMetaTitle { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(250)]
        public string ClubName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PlayerID { get; set; }

        [StringLength(50)]
        public string PlayerName { get; set; }

        [StringLength(30)]
        public string PlayerIdentification { get; set; }

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

        [Key]
        [Column(Order = 3)]
        public bool Status { get; set; }
    }
}
