namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MatchViewModel")]
    public partial class MatchViewModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ID { get; set; }

        [StringLength(16)]
        public string Code { get; set; }

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

        [Required(ErrorMessage = "Please enter HomeClubID")]
        public long? HomeClubID { get; set; }

        [StringLength(16)]
        public string HomeClubCode { get; set; }

        [StringLength(250)]
        public string HomeClubName { get; set; }

        [StringLength(250)]
        public string HomeClubMetaTitle { get; set; }

        public long? VisitingClubID { get; set; }

        [StringLength(16)]
        public string VisitingClubCode { get; set; }

        [StringLength(250)]
        public string VisitingClubName { get; set; }

        [StringLength(250)]
        public string VisitingClubMetaTitle { get; set; }

        public long? StadiumID { get; set; }

        [StringLength(250)]
        public string StadiumMetaTitle { get; set; }

        [StringLength(16)]
        public string StadiumCode { get; set; }

        [StringLength(50)]
        public string StadiumName { get; set; }

        [Required(ErrorMessage = "Please enter Date")]
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required(ErrorMessage = "Please enter ExpectedStartTime")]
        public TimeSpan? ExpectedStartTime { get; set; }

        [Required(ErrorMessage = "Please enter ExpectedEndTime")]
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

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please enter Status")]
        public int Status { get; set; }

        [StringLength(16)]
        public string StatusCode { get; set; }

        [StringLength(250)]
        public string StatusName { get; set; }

        public int? Stt { get; set; }
    }
}
