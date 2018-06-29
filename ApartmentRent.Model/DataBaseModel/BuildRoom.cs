namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BuildRoom")]
    public partial class BuildRoom
    {
        [Key]
        public Guid RoomId { get; set; }

        public Guid BuildId { get; set; }

        [Required]
        [StringLength(8)]
        public string RoomNo { get; set; }

        public byte? StatusCode { get; set; }

        public byte? Floor { get; set; }

        public double? Area { get; set; }

        [StringLength(128)]
        public string Remark { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
