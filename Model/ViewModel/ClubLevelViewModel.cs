using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.ViewModel
{
    [Table("ClubLevelViewModel")]
    public partial class ClubLevelViewModel
    {
        [Key]
        [Column(Order = 0)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(250)]
        public string ClubName { get; set; }

        [Key]
        [Column(Order = 1)]
        public int LevelID { get; set; }

        [StringLength(16)]
        public string LevelCode { get; set; }

        public double? Multiplier { get; set; }

        [StringLength(250)]
        public string LevelName { get; set; }

        public DateTime? Date { get; set; }






    }
}
