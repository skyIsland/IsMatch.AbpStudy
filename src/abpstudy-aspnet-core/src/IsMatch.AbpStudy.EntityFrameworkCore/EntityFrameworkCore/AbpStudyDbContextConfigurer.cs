using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace IsMatch.AbpStudy.EntityFrameworkCore
{
    public static class AbpStudyDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpStudyDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpStudyDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
