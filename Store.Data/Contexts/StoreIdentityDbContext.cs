﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store.Data.Entites.IdentityEntites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Contexts
{
	public class StoreIdentityDbContext : IdentityDbContext<AppUser>
	{
		public StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options) : base(options)
		{
		}
	}
}
