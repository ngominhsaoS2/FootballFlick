using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.EntityFramework
{
    [Table("ClubLevel")]
    public partial class ClubLevel
    {
        [Key]
        [Column(Order = 0)]
        public long ClubID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int LevelID { get; set; }

        public DateTime? Date { get; set; }


    }
}
