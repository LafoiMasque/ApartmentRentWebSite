namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Things
    {
        public Guid ThingsId { get; set; }

        [Required]
        [StringLength(36)]
        public string ThingsNo { get; set; }

        [StringLength(64)]
        public string ThingsName { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Price { get; set; }

        public Guid RoomId { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(120)]
        public string Remark { get; set; }
    }
}
