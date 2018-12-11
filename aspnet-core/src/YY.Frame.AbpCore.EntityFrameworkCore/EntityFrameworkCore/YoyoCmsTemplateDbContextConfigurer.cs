using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace YY.Frame.AbpCore.EntityFrameworkCore
{
    public static class YoyoCmsTemplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<YoyoCmsTemplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<YoyoCmsTemplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
