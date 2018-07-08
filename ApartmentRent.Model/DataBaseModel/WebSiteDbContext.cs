namespace ApartmentRent.Model.DataBaseModel
{
	using System;
	using System.Data.Entity;
	using System.ComponentModel.DataAnnotations.Schema;
	using System.Linq;
	using System.Configuration;

	public partial class WebSiteDbContext : DbContext
	{
		private static readonly string m_connectionString = ConfigurationManager.AppSettings["contextString"];

		public WebSiteDbContext()
			: base(LafoiApp.Common.SecurityEncrypt.DesEncrypt.Decrypt(m_connectionString))
		{
		}

		public virtual DbSet<ActualAmountDetail> ActualAmountDetail { get; set; }
		public virtual DbSet<BillRent> BillRent { get; set; }
		public virtual DbSet<Building> Building { get; set; }
		public virtual DbSet<BuildRoom> BuildRoom { get; set; }
		public virtual DbSet<HouseOwner> HouseOwner { get; set; }
		public virtual DbSet<HouseRenter> HouseRenter { get; set; }
		public virtual DbSet<PayTypeInfo> PayTypeInfo { get; set; }
		public virtual DbSet<RentRecords> RentRecords { get; set; }
		public virtual DbSet<Things> Things { get; set; }
		public virtual DbSet<WaterPowerRent> WaterPowerRent { get; set; }
		public virtual DbSet<WeChatUserInfo> WeChatUserInfo { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ActualAmountDetail>()
				.Property(e => e.RentAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<ActualAmountDetail>()
				.Property(e => e.WaterAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<ActualAmountDetail>()
				.Property(e => e.PowerAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<ActualAmountDetail>()
				.Property(e => e.OtherAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<BillRent>()
				.Property(e => e.BillNo)
				.IsUnicode(false);

			modelBuilder.Entity<BillRent>()
				.Property(e => e.RentAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<BillRent>()
				.Property(e => e.ActualAmount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Building>()
				.Property(e => e.BuildNo)
				.IsUnicode(false);

			modelBuilder.Entity<Building>()
				.Property(e => e.BelongOwnerId)
				.IsUnicode(false);

			modelBuilder.Entity<BuildRoom>()
				.Property(e => e.RoomNo)
				.IsUnicode(false);

			modelBuilder.Entity<HouseOwner>()
				.Property(e => e.IDcard)
				.IsUnicode(false);

			modelBuilder.Entity<HouseOwner>()
				.Property(e => e.TelPhone)
				.IsUnicode(false);

			modelBuilder.Entity<HouseRenter>()
				.Property(e => e.OpenId)
				.IsUnicode(false);

			modelBuilder.Entity<HouseRenter>()
				.Property(e => e.TelPhone)
				.IsUnicode(false);

			modelBuilder.Entity<HouseRenter>()
				.Property(e => e.IDcard)
				.IsUnicode(false);

			modelBuilder.Entity<HouseRenter>()
				.Property(e => e.IDcardMediaId)
				.IsUnicode(false);

			modelBuilder.Entity<HouseRenter>()
				.Property(e => e.IDcardValidDateMediaId)
				.IsUnicode(false);

			modelBuilder.Entity<RentRecords>()
				.Property(e => e.RecordNo)
				.IsUnicode(false);

			modelBuilder.Entity<RentRecords>()
				.Property(e => e.Amount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<RentRecords>()
				.Property(e => e.CashPledge)
				.HasPrecision(10, 2);

			modelBuilder.Entity<Things>()
				.Property(e => e.ThingsNo)
				.IsUnicode(false);

			modelBuilder.Entity<Things>()
				.Property(e => e.ThingsName)
				.IsUnicode(false);

			modelBuilder.Entity<Things>()
				.Property(e => e.Price)
				.HasPrecision(10, 2);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.BillNo)
				.IsUnicode(false);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.FromNum)
				.HasPrecision(6, 0);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.ToNum)
				.HasPrecision(6, 0);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.UnitPrice)
				.HasPrecision(10, 2);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.Account)
				.HasPrecision(10, 2);

			modelBuilder.Entity<WaterPowerRent>()
				.Property(e => e.Amount)
				.HasPrecision(10, 2);

			modelBuilder.Entity<WeChatUserInfo>()
				.Property(e => e.OpenId)
				.IsUnicode(false);

			modelBuilder.Entity<WeChatUserInfo>()
				.Property(e => e.Headimgurl)
				.IsUnicode(false);

			modelBuilder.Entity<WeChatUserInfo>()
				.Property(e => e.Privilege)
				.IsUnicode(false);

			modelBuilder.Entity<WeChatUserInfo>()
				.Property(e => e.Unionid)
				.IsUnicode(false);

			modelBuilder.Entity<WeChatUserInfo>()
				.Property(e => e.IsFollowed)
				.IsUnicode(false);
		}
	}
}
