﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Models;
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
				Name = cat.Name,
				ProductsCount = cat.Products.Count()
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

		public static IEnumerable<ProductIndexModel> GetPopularProducts(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int _itemsNumber)
		{
			return _tsdbcontxt.Products.Where( x => x.StockCount > 0).
						OrderBy(x => x.StockCount).
							Take(_itemsNumber).Select( p => new ProductIndexModel
							{
								Name = p.Name,
								Id = p.Id,
								ImagePath = p.ImagePath,
								Price = p.Price,
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
		public async static Task<IEnumerable<ProductIndexModel>> GetPaginatableProductsAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int _itemsPerPage, PageModel model)
		{
			return await _tsdbcontxt.Products.Where(x => x.StockCount > 0).
						OrderByDescending(x => x.Id).Skip((model.Page - 1) * _itemsPerPage).
							Take(_itemsPerPage).Select(p => new ProductIndexModel
							{
								Name = p.Name,
								Id = p.Id,
								ImagePath = p.ImagePath,
								Price = p.Price
							}).ToListAsync();
		}

		public static int GetAllProductsNumber(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Products.Count();
		}

		public async static Task<IEnumerable<ProductIndexModel>> GetProductsWithCategory(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int _itemsPerPage, PageModel model)
		{
			return await _tsdbcontxt.Products.Where( x => x.StockCount > 0 && x.Category.Name == model.CategoryName)
						.OrderByDescending(x => x.Id).Skip((model.Page - 1) * _itemsPerPage).
							Take(_itemsPerPage).Select(p => new ProductIndexModel
							{
								Name = p.Name,
								Id = p.Id,
								ImagePath = p.ImagePath,
								Price = p.Price,
								CategoryName = p.Category.Name
							}).ToListAsync();
		}

		public async static Task<Product> GetProductAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int id)
		{
			var product = await _tsdbcontxt.Products.FindAsync(id);
			product.Category = await _tsdbcontxt.Categories.FindAsync(product.CategoryId);
			return product;
		}

		public async static Task<IEnumerable<ProductFullModel>> GetAllProducts(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return await _tsdbcontxt.Products.Select(p => new ProductFullModel
							{
								Name = p.Name,
								Id = p.Id,
								Price = p.Price,
								CategoryName = p.Category.Name,
								MetaDescription = p.MetaDescription,
								StockCount = p.StockCount
							}).ToListAsync();
		}
	}
}