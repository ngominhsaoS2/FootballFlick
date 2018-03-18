namespace Model.EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Match")]
    public partial class Match
    {
        public long ID { get; set; }

        [StringLength(16)]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter Name")]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        [Column(TypeName = "xml")]
        public string MoreImages { get; set; }

        public long? HomeClubID { get; set; }

        public long? VisitingClubID { get; set; }

        public long? StadiumID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public TimeSpan? ExpectedStartTime { get; set; }

        public TimeSpan? ExpectedEndTime { get; set; }

        [StringLength(250)]
        public string HoldAddress { get; set; }

        public decimal? Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        public DateTime? ExpiredDateToSign { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public TimeSpan? RealStartTime { get; set; }

        public TimeSpan? RealEndTime { get; set; }

        public int? HomeClubGoal { get; set; }

        public int? VisitingClubGoal { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescriptions { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }
    }
}
