using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using IsMatch.AbpStudy.Authorization.Roles;
using IsMatch.AbpStudy.Authorization.Users;
using IsMatch.AbpStudy.MultiTenancy;
using IsMatch.AbpStudy.PhoneBooks.Persons;
using IsMatch.AbpStudy.PhoneBooks.PhoneNumbers;
using Abp.Localization;

namespace IsMatch.AbpStudy.EntityFrameworkCore
{
    public class AbpStudyDbContext : AbpZeroDbContext<Tenant, Role, User, AbpStudyDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public AbpStudyDbContext(DbContextOptions<AbpStudyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }

        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationLanguageText>().Property(p => p.Value).HasMaxLength(500);


            base.OnModelCreating(modelBuilder);
        }
    }
}
