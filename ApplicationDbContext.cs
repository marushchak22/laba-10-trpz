using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
namespace YourNamespace.Models
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<BicycleType> BicycleType { get; set; }
		public DbSet<BrandType> BrandType { get; set; }
		public DbSet<BicycleBrand> BicycleBrand { get; set; }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
	}

}

