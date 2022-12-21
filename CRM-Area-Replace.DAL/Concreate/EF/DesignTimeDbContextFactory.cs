using CRM_Area_Replace.DAL.Concreate.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Area_Replace.DAL.Concreate.EF
{
	public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CRMContext>
	{
		public CRMContext CreateDbContext(string[] args)
		{
			var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

			var builder = new DbContextOptionsBuilder<CRMContext>();
			string connStr = config.GetConnectionString("DB");
			builder.UseSqlServer(connStr);	
			return new CRMContext(builder.Options);

		}
	}
}
