﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TelecommunicationDevicesStore.Domain.Data;
using TelecommunicationDevicesStore.WebUI.Areas.Admin.Data;

namespace TelecommunicationDevicesStore.WebUI.Infrastructure
{
	public static class DbSetExtensions
	{
		public async static Task<SystemUser> GetUserAsync(this DbSet<SystemUser> _dbSet, LoginModel model)
		{
			return await _dbSet.Where(x => x.Email == model.Email && x.Password == model.Password).SingleOrDefaultAsync();
		}
	}
}