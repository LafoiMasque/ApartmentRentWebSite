namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PayTypeInfo")]
    public partial class PayTypeInfo
    {
        [Key]
        public byte TypeCode { get; set; }

        [Required]
        [StringLength(10)]
        public string TypeName { get; set; }
    }
}
