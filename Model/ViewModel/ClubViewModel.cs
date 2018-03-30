namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubViewModel")]
    public partial class ClubViewModel
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

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        public long? OwnerID { get; set; }

        [StringLength(50)]
        public string OwnerName { get; set; }

        [StringLength(50)]
        public string NameOfOwner { get; set; }

        public long? CaptainID { get; set; }

        [StringLength(50)]
        public string CaptainName { get; set; }

        [StringLength(30)]
        public string CaptainIdentification { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public int LevelID { get; set; }

        [StringLength(16)]
        public string LevelCode { get; set; }

        [StringLength(250)]
        public string LevelName { get; set; }

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

        [Key]
        [Column(Order = 1)]
        public bool Status { get; set; }
    }
}
