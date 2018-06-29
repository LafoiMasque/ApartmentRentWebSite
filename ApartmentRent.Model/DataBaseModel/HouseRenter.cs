namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseRenter")]
    public partial class HouseRenter
    {
        [Key]
        public Guid RenterId { get; set; }

        [Required]
        [StringLength(32)]
        public string OpenId { get; set; }

        public bool? IsMainRent { get; set; }

        [Required]
        [StringLength(36)]
        public string RenterName { get; set; }

        [StringLength(22)]
        public string TelPhone { get; set; }

        [StringLength(20)]
        public string Job { get; set; }

        [StringLength(64)]
        public string JobLocation { get; set; }

        public Guid? RoomId { get; set; }

        [StringLength(18)]
        public string IDcard { get; set; }

        [StringLength(128)]
        public string IDcardMediaId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? IDcardValidDate { get; set; }

        [StringLength(128)]
        public string IDcardValidDateMediaId { get; set; }

        [StringLength(36)]
        public string ContactName { get; set; }

        [StringLength(36)]
        public string ContactTel { get; set; }

        [StringLength(120)]
        public string Remark { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
