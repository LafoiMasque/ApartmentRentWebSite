namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RentRecords
    {
        [Key]
        public Guid RecordId { get; set; }

        [Required]
        [StringLength(20)]
        public string RecordNo { get; set; }

        public Guid RoomId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FromDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }

        public short? StartPowerDegree { get; set; }

        public short? StartWaterDegree { get; set; }

        public Guid OwnerId { get; set; }

        public Guid RenterId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Amount { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CashPledge { get; set; }

        public byte? StatusCode { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? ModifyTime { get; set; }

        public Guid? CreateUserId { get; set; }

        [StringLength(64)]
        public string Remark { get; set; }
    }
}
