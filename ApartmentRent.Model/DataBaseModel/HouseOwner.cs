namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HouseOwner")]
    public partial class HouseOwner
    {
        [Key]
        public Guid OwnerId { get; set; }

        [Required]
        [StringLength(36)]
        public string OwnerName { get; set; }

        [StringLength(18)]
        public string IDcard { get; set; }

        [StringLength(22)]
        public string TelPhone { get; set; }

        [StringLength(60)]
        public string ContactAddress { get; set; }

        [StringLength(120)]
        public string Remark { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
