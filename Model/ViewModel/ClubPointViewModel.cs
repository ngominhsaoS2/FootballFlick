using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.ViewModel
{
    [Table("ClubPointViewModel")]
    public partial class ClubPointViewModel
    {
        [Key]
        [Column(Order = 0)]
        public string MatchID { get; set; }

        [StringLength(16)]
        public string MatchCode { get; set; }

        [Key]
        [Column(Order = 1)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(50)]
        public string ClubName { get; set; }

        public int? WinPoint { get; set; }

        public int? DrawPoint { get; set; }

        public int? GoalPoint { get; set; }

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
