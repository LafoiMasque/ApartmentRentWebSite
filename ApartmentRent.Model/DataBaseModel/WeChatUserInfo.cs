namespace ApartmentRent.Model.DataBaseModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WeChatUserInfo")]
    public partial class WeChatUserInfo
    {
        [Key]
        [StringLength(32)]
        public string OpenId { get; set; }

        [StringLength(32)]
        public string NickName { get; set; }

        public int? Sex { get; set; }

        [StringLength(32)]
        public string Province { get; set; }

        [StringLength(32)]
        public string City { get; set; }

        [StringLength(32)]
        public string Country { get; set; }

        [StringLength(128)]
        public string Headimgurl { get; set; }

        [StringLength(128)]
        public string Privilege { get; set; }

        [StringLength(32)]
        public string Unionid { get; set; }

        [StringLength(4)]
        public string IsFollowed { get; set; }

        public DateTime? CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(32)]
        public string CreateName { get; set; }
    }
}
