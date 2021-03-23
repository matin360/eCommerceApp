namespace TelecommunicationDevicesStore.Domain.Migrations
{
    using System;
	using System.Configuration;
	using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using TelecommunicationDevicesStore.Domain.Data;

	internal sealed class Configuration : DbMigrationsConfiguration<TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext context)
        {
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            context.Menus.AddOrUpdate(new Menu
            {
                Id = 1,
                Name = "About",
                ActionName = "Index",
                ControllerName = "About",
                IsActive = true
            },
            new Menu
            {
                Id = 2,
                Name = "Products",
                ActionName = "Index",
                ControllerName = "Product",
                IsActive = true
            },
             new Menu
             {
                 Id = 6,
                 Name = "Contact",
                 ActionName = "Index",
                 ControllerName = "Contact",
                 IsActive = true
             },
            new Menu
            {
                Id = 3,
                Name = "Sign Up",
                ActionName = "Index",
                ControllerName = "SignUp",
                IsActive = true
            });
			context.CarouselItems.AddOrUpdate(new CarouselItem
			{
				Id = 1,
				ImagePath = "banner2.jpg",
				Heading = "Our Latest Product",
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page",
				ActionLink = "Index",
				ControllerLink = "Product",
				TextLink = "See more products",
				SlideNumber = "first-slide"
			},
			new CarouselItem
			{
				Id = 2,
				ImagePath = "banner2.jpg",
				Heading = "Our Latest Product",
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page",
				ActionLink = "Index",
				ControllerLink = "About",
				TextLink = "Read more about us",
				SlideNumber = "second-slide"
			},
			new CarouselItem
			{
				Id = 3,
				ImagePath = "banner2.jpg",
				Heading = "Our Latest Product",
				Description = "It is a long established fact that a reader will be distracted by the readable content of a page",
				ActionLink = "Index",
				ControllerLink = "Product",
				TextLink = "See more Products",
				SlideNumber = "third-slide"
			});
			#region data
			//context.SystemUsers.AddOrUpdate(new SystemUser
			//{
			//    Id = 1,
			//    UserName = "Admin",
			//    Email = ConfigurationManager.AppSettings["email"],
			//    Password = ConfigurationManager.AppSettings["password"],
			//    UserRole = Roles.UserRole.Admin
			//});
			context.Customers.AddOrUpdate(new Customer
			{
				Id = 2,
				UserName = "Jhon Smith",
				Email = "jhon@gmail.com",
				Password = "123456smith",
				Picture = "lllll.png"
			});
			//context.Categories.AddOrUpdate(new Category
			//{
			//    Id = 1,
			//    Name = "Modems",
			//},
			//new Category
			//{
			//    Id = 2,
			//    Name = "Mobile phones",
			//},
			//new Category
			//{
			//    Id = 3,
			//    Name = "Landline telephones",
			//},
			//new Category
			//{
			//    Id = 4,
			//    Name = "Fax machines",
			//},
			//new Category
			//{
			//    Id = 5,
			//    Name = "Teleprinters",
			//},
			//new Category
			//{
			//    Id = 6,
			//    Name = "Routers",
			//});
			context.Services.AddOrUpdate(new Service
			{
				Id = 1,
				Description = "Exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea",
				Name = "Secure payments",
				ImagePath = "service2.png"
			},
			new Service
			{
				Id = 2,
				Description = "Exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea",
				Name = "Affordable products",
				ImagePath = "service4.png"
			},
			new Service
			{
				Id = 3,
				Description = "Exerci tation ullamcorper suscipit lobortis nisl ut aliquip ex ea",
				Name = "1 year warranty",
				ImagePath = "service5.png"
			});
			context.Feedbacks.AddOrUpdate(new Feedback
			{
				Id = 1,
				UserName = "Jhon Smith",
				WrittenDate = DateTime.Now,
				Message = "You guys rock! Thank you for making it painless, pleasant and most of all hassle free! I wish I would have thought of it first. I am really satisfied with my first laptop",
				CustomerId = 2,
				SlideNumber = 0
			},
			new Feedback
			{
				Id = 2,
				UserName = "Jhon Smith",
				WrittenDate = DateTime.Now,
				Message = "You guys rock! Thank you for making it painless, pleasant and most of all hassle free! I wish I would have thought of it first. I am really satisfied with my first laptop",
				CustomerId = 2,
				SlideNumber = 1
				
			},
			new Feedback
			{
				Id = 3,
				UserName = "Jhon Smith",
				WrittenDate = DateTime.Now,
				Message = "You guys rock! Thank you for making it painless, pleasant and most of all hassle free! I wish I would have thought of it first. I am really satisfied with my first laptop",
				CustomerId = 2,
				SlideNumber = 2
			});
			//context.Products.AddOrUpdate(new Product
			//{
			//    Id = 1,
			//    Name = "Xiaomi Redmi Note 10 4/64GB Grey",
			//    ShorDescription = "Storage: 64 GB | Battery : 5000(mAh) | RAM: 4 GB | Processor: Qualcomm |",
			//    MetaDescription = "Production Company: Xiaomi | Production Year: 2012 | Screen: 6.43'' | Resolution: 1080x2400 | Main camera: 48 mpx + 8 mpx + 2 mpx + 2 mpx | Storage: 128 GB | Battery : 5000(mAh) | RAM: 4 GB | Processor: Qualcomm |",
			//    ImagePath = "xiaominote10pro.png",
			//    CategoryId = 2,
			//    Price = 479.99m,
			//    StockCount = 30
			//},
			//new Product
			//{
			//    Id = 2,
			//    Name = "Xiaomi Redmi Note 10 6/128GB Grey",
			//    ShorDescription = "Storage: 128 GB | Battery : 5000(mAh) | RAM: 6 GB | Processor: Qualcomm |",
			//    MetaDescription = "Production Company: Xiaomi | Production Year: 2012 | Screen: 6.43'' | Resolution: 1080x2400 | Main camera: 48 mpx + 8 mpx + 2 mpx + 2 mpx | Storage: 128 GB | Battery : 5000(mAh) | RAM: 4 GB | Processor: Qualcomm |",
			//    ImagePath = "xiaominote10pro.png",
			//    CategoryId = 2,
			//    Price = 522.99m,
			//    StockCount = 30
			//});
			#endregion
			context.SaveChanges();
        }
    }
}
