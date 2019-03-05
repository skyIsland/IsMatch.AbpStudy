using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using IsMatch.AbpStudy.Configuration;
using IsMatch.AbpStudy.Web;

namespace IsMatch.AbpStudy.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class AbpStudyDbContextFactory : IDesignTimeDbContextFactory<AbpStudyDbContext>
    {
        public AbpStudyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AbpStudyDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            AbpStudyDbContextConfigurer.Configure(builder, configuration.GetConnectionString(AbpStudyConsts.ConnectionStringName));

            return new AbpStudyDbContext(builder.Options);
        }
    }
}
