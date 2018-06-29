namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WaterPowerRent")]
    public partial class WaterPowerRent
    {
        [Key]
        public Guid WaterPowerId { get; set; }

        [Required]
        [StringLength(36)]
        public string BillNo { get; set; }

        public byte? Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FromNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ToNum { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UnitPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Account { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(128)]
        public string Remark { get; set; }
    }
}
