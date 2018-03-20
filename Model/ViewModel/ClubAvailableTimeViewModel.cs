namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubAvailableTimeViewModel")]
    public partial class ClubAvailableTimeViewModel
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
        [StringLength(20)]
        public string Day { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        [Key]
        [Column(Order = 2)]
        public bool Status { get; set; }
    }
}
