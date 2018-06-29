namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Building")]
    public partial class Building
    {
        [Key]
        public Guid BuildId { get; set; }

        [StringLength(20)]
        public string BuildNo { get; set; }

        [StringLength(36)]
        public string BuildName { get; set; }

        [StringLength(300)]
        public string AddressName { get; set; }

        [StringLength(36)]
        public string BelongOwnerId { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }
    }
}
