using System;
using System.Data.Entity;
using System.Linq;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class TelecomStoreDbContext : DbContext
	{
		public TelecomStoreDbContext() : base("name=TelecomStoreDbContext") { }

		public virtual DbSet<User> Customers { get; set; }
		public virtual DbSet<Order> Orders { get; set; }
		public virtual DbSet<CartLine> CartLines { get; set; }
		public virtual DbSet<SystemUser> SystemUsers { get; set; }
		public virtual DbSet<Category> Categories { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<ContactMessage> ContactMessages { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Service> Services { get; set; }
		public virtual DbSet<CarouselItem> CarouselItems { get; set; }
	}
}