using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Models;
using TelecommunicationDevicesStore.WebUI.Models;

namespace TelecommunicationDevicesStore.WebUI.Infrastructure
{
	public static class DbSetExtensions
	{
		public async static Task<SystemUser> GetUserAsync(this DbSet<SystemUser> _dbSet, LoginModel model) => await _dbSet.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefaultAsync();
		public async static Task<User> GetUserAsync(this DbSet<User> _dbSet, LoginUserModel model) => await _dbSet.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefaultAsync();
		public async static Task<User> GetUserAsync(this DbSet<User> _dbSet, int id) => await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
		public  static bool UserExists(this DbSet<User> _dbSet, string email) => _dbSet.Any(x => x.Email == email);
		public async static Task<Product> GetProductAsync(this DbSet<Product> _dbSet, int id) => await _dbSet.Where(x => x.Id == id).SingleOrDefaultAsync();
		public static Product GetProduct(this DbSet<Product> _dbSet, int id) =>  _dbSet.Where(x => x.Id == id).SingleOrDefault();
	}
}