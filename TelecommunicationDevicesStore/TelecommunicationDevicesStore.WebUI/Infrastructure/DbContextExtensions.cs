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
		public static IEnumerable<MenuIndexModel> GetAllMenus(this TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Menus.Where(m => m.IsActive).Select(m => new MenuIndexModel
			{
				Name = m.Name,
				ControllerName = m.ControllerName,
				ActionName = m.ActionName
			}).ToList();
		}

		public static IEnumerable<CategoryIndexModel> GetAllCategories(this TelecomStoreDbContext _tsdbcontxt)
		{
			return _tsdbcontxt.Categories.Select(cat => new CategoryIndexModel
			{
				Name = cat.Name,
				ProductsCount = cat.Products.Count()
			}).ToList();
		}
		public static async Task<IEnumerable<CategoryFullModel>> GetAllFullCategories(this TelecomStoreDbContext _tsdbcontxt)
		{
			return await _tsdbcontxt.Categories.Select(cat => new CategoryFullModel
			{
				Id = cat.Id,
				Name = cat.Name,
				ProductsCount = cat.Products.Count()
			}).ToListAsync();
		}
		public static IEnumerable<CarouselItemIndexModel> GetAllCarouselItems(this TelecomStoreDbContext _tsdbcontxt)
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
								ImageData = p.ImageData,
								ImageMimeType = p.ImageMimeType,
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
				SlideNumber = f.SlideNumber
			}).ToList();
		}
		public async static Task<IEnumerable<ProductIndexModel>> GetPaginatableProductsAsync(this TelecomStoreDbContext _tsdbcontxt, int _itemsPerPage, PageModel model)
		{
			return await _tsdbcontxt.Products.Where(x => x.StockCount > 0).
						OrderByDescending(x => x.Id).Skip((model.Page - 1) * _itemsPerPage).
							Take(_itemsPerPage).Select(p => new ProductIndexModel
							{
								Name = p.Name,
								Id = p.Id,
								ImageData = p.ImageData,
								ImageMimeType = p.ImageMimeType,
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
								ImageData = p.ImageData,
								ImageMimeType = p.ImageMimeType,
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

		public async static Task<IEnumerable<CustomerFullModel>> GetAllCustomers(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return await _tsdbcontxt.Customers.Select(c => new CustomerFullModel
			{
				Id = c.Id,
				Email = c.Email,
				UserName = c.UserName
			}).ToListAsync();
		}

		public async static Task<IEnumerable<OrderFullModel>> GetAllOrders(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return await _tsdbcontxt.Orders.Select(ord => new OrderFullModel
			{
				Id = ord.Id,
				Line1 = ord.Line1,
				Line2 = ord.Line2,
				Line3 = ord.Line3,
				City = ord.City,
				Country = ord.Country,
				CustomerName = ord.User.UserName,
				TotalPrice = ord.TotalPrice
			}).ToListAsync();
		}
		public async static Task<IEnumerable<UserMessageFullModel>> GetAllUserMessages(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			return await _tsdbcontxt.ContactMessages.Select(um => new UserMessageFullModel
			{
				Id = um.Id,
				UserName = um.UserName,
				UserEmail = um.UserEmail,
				UserPhoneNumber = um.UserPhoneNumber,
				SubmittedDate = um.SubmittedDate,
				Message = um.Message
			}).ToListAsync();
		}

		public async static Task<ProductDetailsModel> GetProductDetailsAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int id)
		{
			var product = await _tsdbcontxt.Products.FindAsync(id);
			product.Category = await _tsdbcontxt.Categories.FindAsync(product.CategoryId);

			return new ProductDetailsModel
			{
				Id = product.Id,
				Name = product.Name,
				MetaDescription = product.MetaDescription,
				Category = new CategoryIndexModel
				{
					Name = product.Category.Name,
				},
				StockCount = product.StockCount,
				Price = product.Price,
				ImageData = product.ImageData,
				ImageMimeType = product.ImageMimeType
			};
		}

		public async static Task<OrderDetailsModel> GetOrderDetailsAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int id)
		{
			var order = await _tsdbcontxt.Orders.Select(ord => new OrderDetailsModel
			{
				Id = ord.Id,
				Line1 = ord.Line1,
				Line2 = ord.Line2,
				Line3 = ord.Line3,
				City = ord.City,
				Country = ord.Country,
				CustomerName = ord.User.UserName,
				TotalPrice = ord.TotalPrice,
				CartLines = ord.CartLines
			}).FirstOrDefaultAsync();

			foreach (var item in order.CartLines)
			{
				item.Product = await _tsdbcontxt.Products.FindAsync(item.ProductId);
				item.Product.Category = await _tsdbcontxt.Categories.FindAsync(item.Product.CategoryId);
			}
			
			return order;
		}

		public static Dictionary<string, int> GetElementsCounts(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt)
		{
			Dictionary<string, int> elementsCounts = new Dictionary<string, int>();

			elementsCounts.Add("Products", _tsdbcontxt.Products.Count());
			elementsCounts.Add("Cutomers", _tsdbcontxt.Customers.Count());
			elementsCounts.Add("Orders", _tsdbcontxt.Orders.Count());
			elementsCounts.Add("Contact Messages", _tsdbcontxt.ContactMessages.Count());
			elementsCounts.Add("Categories", _tsdbcontxt.Categories.Count());
			return elementsCounts;
		}


		// iud
		public async static Task<int> AddUserAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, User user)
		{
			_tsdbcontxt.Customers.Add(user);
			return await _tsdbcontxt.SaveChangesAsync();
		}
		public async static Task<int> SaveProductAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, ProductEditModel model)
		{
			var category = await _tsdbcontxt.Categories.Where(x => x.Name == model.CategoryName).FirstOrDefaultAsync();
			var product = new Product
			{
				Id = model.Id,
				Name = model.Name,
				MetaDescription = model.MetaDescription,
				CategoryId = category.Id,
				Price = model.Price,
				StockCount = model.StockCount,
				ImageData = model.ImageData,
				ImageMimeType = model.ImageMimeType
			};
			if (product.Id == 0)
				_tsdbcontxt.Products.Add(product);
			else
			{
				Product dbEntry = await _tsdbcontxt.Products.FindAsync(product.Id);
				if (dbEntry != null)
				{
					dbEntry.Name = product.Name;
					dbEntry.MetaDescription = product.MetaDescription;
					dbEntry.Price = product.Price;
					dbEntry.CategoryId = product.CategoryId;
					dbEntry.StockCount = product.StockCount;
					dbEntry.ImageData = product.ImageData;
					dbEntry.ImageMimeType = product.ImageMimeType;
				}
			}
			return await _tsdbcontxt.SaveChangesAsync();
		}

		public async static Task<Product> RemoveProductAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int id)
		{
			Product dbEntry = _tsdbcontxt.Products.Find(id);
			if (dbEntry != null)
			{
				_tsdbcontxt.Products.Remove(dbEntry);
				await _tsdbcontxt.SaveChangesAsync();
			}
			return dbEntry;
		}
		public async static Task<Category> RemoveCategoryAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, int id)
		{
			Category dbEntry = _tsdbcontxt.Categories.Find(id);
			if (dbEntry != null)
			{
				_tsdbcontxt.Categories.Remove(dbEntry);
				await _tsdbcontxt.SaveChangesAsync();
			}
			return dbEntry;
		}
		public async static Task<int> AddContactMessageAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, ContactMessage model)
		{
			model.SubmittedDate = DateTime.Now;
			_tsdbcontxt.ContactMessages.Add(model);
			return await _tsdbcontxt.SaveChangesAsync();
		}
		public async static Task<int> AddCategoryAsync(this TelecommunicationDevicesStore.Domain.Data.TelecomStoreDbContext _tsdbcontxt, CategoryEditModel model)
		{
			Category category = new Category(model.Name);
			_tsdbcontxt.Categories.Add(category);
			return await _tsdbcontxt.SaveChangesAsync();
		}
	}
}