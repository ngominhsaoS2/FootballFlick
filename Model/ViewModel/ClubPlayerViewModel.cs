namespace Model.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubPlayerViewModel")]
    public partial class ClubPlayerViewModel
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ClubID { get; set; }

        [StringLength(16)]
        public string ClubCode { get; set; }

        [StringLength(250)]
        public string ClubName { get; set; }

        public long? OwnerID { get; set; }

        [Key]
        [Column(Order = 1)]
        public long PlayerID { get; set; }

        public long? UserID { get; set; }

        [Required(ErrorMessage = "Please enter PlayerName")]
        [StringLength(50)]
        public string PlayerName { get; set; }

        [StringLength(30)]
        public string PlayerIdentification { get; set; }

        [StringLength(250)]
        public string PlayerAddress { get; set; }

        [EmailAddress(ErrorMessage = "Please use a real email")]
        [StringLength(250)]
        public string PlayerEmail { get; set; }

        [StringLength(50)]
        public string PlayerPhone { get; set; }

        [StringLength(500)]
        public string PlayerImage { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public bool Status { get; set; }
    }
}
