namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActualAmountDetail")]
    public partial class ActualAmountDetail
    {
        [Key]
        public Guid RentId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RentAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WaterAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PowerAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OtherAmount { get; set; }
    }
}
