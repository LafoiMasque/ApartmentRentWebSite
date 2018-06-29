namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BillRent")]
    public partial class BillRent
    {
        [Key]
        public Guid RentId { get; set; }

        [Required]
        [StringLength(36)]
        public string BillNo { get; set; }

        public Guid RoomId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public Guid OwnerId { get; set; }

        public Guid RenterId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RentAmount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal ActualAmount { get; set; }

        public byte? TypeCode { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public Guid CreateUserId { get; set; }

        [StringLength(64)]
        public string Remark { get; set; }
    }
}
