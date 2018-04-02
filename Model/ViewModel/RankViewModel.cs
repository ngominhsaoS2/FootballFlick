using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.ViewModel
{
    [Table("RankViewModel")]
    public partial class RankViewModel
    {
        [Key]
        [Column(Order = 0)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(250)]
        public string ClubName { get; set; }

        [StringLength(250)]
        public string ClubMetaTitle { get; set; }

        [StringLength(250)]
        public string ClubDescription { get; set; }

        [StringLength(500)]
        public string ClubImage { get; set; }

        public int LevelID { get; set; }

        [StringLength(250)]
        public string LevelName { get; set; }

        [StringLength(250)]
        public string LevelMetaTitle { get; set; }

        [StringLength(50)]
        public string LevelColor { get; set; }

        public int? JoinPoint { get; set; }

        public int? WinPoint { get; set; }

        public int? DrawPoint { get; set; }

        public int? GoalPoint { get; set; }

        public int? TotalPoint { get; set; }

        public int? Joined { get; set; }

        public int? Win { get; set; }

        public int? Draw { get; set; }

        public int? Lose { get; set; }

        public long? RankNumber { get; set; }

        public int? HomeGoalFor { get; set; }

        public int? HomeGoalAgainst { get; set; }

        public int? VisitingGoalFor { get; set; }

        public int? VisitingGoalAgainst { get; set; }

        public int? TotalGoalFor { get; set; }

        public int? TotalGoalAgainst { get; set; }

        public int? HomeCancel { get; set; }

        public int? VisitingCancel { get; set; }


    }
}
