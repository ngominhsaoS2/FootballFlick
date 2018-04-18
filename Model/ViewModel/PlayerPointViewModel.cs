namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlayerPointViewModel")]
    public partial class PlayerPointViewModel
    {
        [Key]
        [Column(Order = 0)]
        public long MatchID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long PlayerID { get; set; }

        [StringLength(50)]
        public string PlayerName { get; set; }

        [StringLength(30)]
        public string PlayerIdentification { get; set; }

        public int? GoalPoint { get; set; }

        public int? AssistPoint { get; set; }

        public int? FairplayPoint { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Status { get; set; }
    }
}
