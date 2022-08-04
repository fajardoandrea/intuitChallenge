using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intuit.Data
{
	public class DBConnection : DbContext
	{
		public DBConnection(DbContextOptions<DBConnection> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Client>().HasKey(x => new { x.Id });
		}

		public DbSet<Client> Client {get; set;}
	}
}
