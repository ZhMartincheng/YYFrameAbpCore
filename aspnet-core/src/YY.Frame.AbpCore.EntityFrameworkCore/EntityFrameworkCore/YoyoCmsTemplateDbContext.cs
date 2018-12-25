using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using YY.Frame.AbpCore.Authorization.Roles;
using YY.Frame.AbpCore.Authorization.Users;
using YY.Frame.AbpCore.MultiTenancy;
using YY.Frame.AbpCore.Persons;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.AbpCore.EntityFrameworkCore
{
    public class YoyoCmsTemplateDbContext : AbpZeroDbContext<Tenant, Role, User, YoyoCmsTemplateDbContext>
    {
		/* Define a DbSet for each entity of the application */
		public DbSet<Book> Books { get; set; }

	    public DbSet<Parameter> Parameters { get; set; }
		public YoyoCmsTemplateDbContext(DbContextOptions<YoyoCmsTemplateDbContext> options)
            : base(options)
        {
        }
    }
}
