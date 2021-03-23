using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Infrastructure
{
	public static class DbContextExtensions
	{
		public static IEnumerable<MenuIndexModel> GetAllMenus(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Menus.Where(m => m.IsActive).Select(m => new MenuIndexModel
			{
				Name = m.Name,
				ControllerName = m.ControllerName,
				ActionName = m.ActionName
			}).ToList();
		}

		public static IEnumerable<CategoryIndexModel> GetAllCategories(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Categories.Select(cat => new CategoryIndexModel
			{
				Name = cat.Name
			}).ToList();
		}

		public static IEnumerable<CarouselItemIndexModel> GetAllCarouselItems(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.CarouselItems.Select(carItm => new CarouselItemIndexModel
			{
				Heading = carItm.Heading,
				Description = carItm.Description,
				ImagePath = carItm.ImagePath,
				ActionLink = carItm.ActionLink,
				TextLink = carItm.TextLink,
				ControllerLink = carItm.ControllerLink,
				SlideNumber = carItm.SlideNumber
			}).ToList();
		}

		public static IEnumerable<ServiceIndexModel> GetAllServices(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Services.Select(s => new ServiceIndexModel
			{
				Name = s.Name,
				Description = s.Description,
				ImagePath = s.ImagePath,
			}).ToList();
		}

		public static IEnumerable<ProductIndexModel> GetPopularProducts(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Products.
						OrderByDescending(x => x.Customers.Count()).
							Take(8).Select( p => new ProductIndexModel
							{
								Name = p.Name,
								Id = p.Id,
								ImagePath = p.ImagePath,
								Price = p.Price,
								ShorDescription = p.ShorDescription,
								CustomersCount = p.Customers.Count()
							}).ToList();
		}

		public static IEnumerable<FeedbackIndexModel> GetAllFEeedbacks(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Feedbacks.Select(f => new FeedbackIndexModel
			{
				UserName = f.UserName,
				WrittenDate = f.WrittenDate,
				Message = f.Message,
				SlideNumber = f.SlideNumber,
				UserImage = f.Customer.Picture
			}).ToList();
		}
	}
}