using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IsMatch.AbpStudy.Authorization.Roles;
using IsMatch.AbpStudy.Authorization.Users;
using IsMatch.AbpStudy.MultiTenancy;

namespace IsMatch.AbpStudy.EntityFrameworkCore
{
    public class AbpStudyDbContext : AbpZeroDbContext<Tenant, Role, User, AbpStudyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpStudyDbContext(DbContextOptions<AbpStudyDbContext> options)
            : base(options)
        {
        }
    }
}
