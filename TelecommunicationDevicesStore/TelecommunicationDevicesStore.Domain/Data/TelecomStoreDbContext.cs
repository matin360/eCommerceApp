using System;
using System.Data.Entity;
using System.Linq;

namespace TelecommunicationDevicesStore.Domain.Data
{
	public class TelecomStoreDbContext : DbContext
	{
		// Your context has been configured to use a 'TelecomStoreDbContext' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'TelecomStoreDbContext' 
		// connection string in the application configuration file.
		public TelecomStoreDbContext()
			: base("name=TelecomStoreDbContext")
		{
		}
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Customer> Customers { get; set; }
		public virtual DbSet<Category> MyEntities { get; set; }
		public virtual DbSet<Feedback> Feedbacks { get; set; }
		public virtual DbSet<ContactMessage> ContactMessages { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<Service> Services { get; set; }
		public virtual DbSet<CartProducts> CartProducts { get; set; }

	}
}