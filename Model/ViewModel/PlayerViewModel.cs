using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Model.ViewModel
{
    [Table("PlayerViewModel")]
    public partial class PlayerViewModel
    {
        [Key]
        [Column(Order = 0)]
        public long ID { get; set; }

        public long? UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string NameOfUser { get; set; }

        [StringLength(250)]
        public string UserAddress { get; set; }

        [StringLength(250)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public string UserPhone { get; set; }

        [StringLength(500)]
        public string UserImage { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(30)]
        public string Identification { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(500)]
        public string Image { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        public bool Status { get; set; }

        public long RankNumber { get; set; }

        public int Match { get; set; }

        public int Goal { get; set; }

        public int Assist { get; set; }

        public int YellowCard { get; set; }

        public int RedCard { get; set; }

        public int GoalPoint { get; set; }

        public int AssistPoint { get; set; }

        public int YellowPoint { get; set; }

        public int RedPoint { get; set; }

        public int TotalPoint { get; set; }


    }
}
