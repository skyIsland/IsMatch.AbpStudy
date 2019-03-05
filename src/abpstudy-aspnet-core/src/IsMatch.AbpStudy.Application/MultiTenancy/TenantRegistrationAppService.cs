using Abp.AutoMapper;
using Abp.Extensions;
using Abp.MultiTenancy;
using Abp.Runtime.Security;
using IsMatch.AbpStudy.Authorization.Roles;
using IsMatch.AbpStudy.Authorization.Users;
using IsMatch.AbpStudy.Editions;
using IsMatch.AbpStudy.MultiTenancy.Dto;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace IsMatch.AbpStudy.MultiTenancy
{
    public class TenantRegistrationAppService : AbpStudyAppServiceBase, ITenantRegistrationAppService
    {
        private readonly EditionManager _editionManager;
        private readonly RoleManager _roleManager;
        private readonly IAbpZeroDbMigrator _abpZeroDbMigrator;
        private readonly IPasswordHasher<User> _passwordHasher;

        public TenantRegistrationAppService(
            EditionManager editionManager,
            RoleManager roleManager,
            IAbpZeroDbMigrator abpZeroDbMigrator,
            IPasswordHasher<User> passwordHasher)
        {
            _editionManager = editionManager;

            _roleManager = roleManager;
            _abpZeroDbMigrator = abpZeroDbMigrator;
            _passwordHasher = passwordHasher;
        }

        /// <summary>
        /// ??????????????????
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public async Task<TenantDto> RegisterTenantAsync(CreateTenantDto input)
        {
            //??????????????????
            Tenant tenant = new Tenant(input.TenancyName, input.TenancyName)
            {
                IsActive = true
            };

            tenant.ConnectionString = input.ConnectionString.IsNullOrEmpty() ? null : SimpleStringCipher.Instance.Encrypt(input.ConnectionString);

            Abp.Application.Editions.Edition defaultEdition = await _editionManager.FindByNameAsync(EditionManager.DefaultEditionName);

            if (defaultEdition != null)
            {
                tenant.EditionId = defaultEdition.Id;
            }
            await TenantManager.CreateAsync(tenant);
            // ???????????????????????????Id
            await CurrentUnitOfWork.SaveChangesAsync();
            // ?????????????????????
            _abpZeroDbMigrator.CreateOrMigrateForTenant(tenant);
            //?????????????????????????????????????????????????????????????????????????????????
            using (CurrentUnitOfWork.SetTenantId(tenant.Id))
            {
                // ????????????????????????
                CheckErrors(await _roleManager.CreateStaticRoles(tenant.Id));
                // ?????????????????????id
                await CurrentUnitOfWork.SaveChangesAsync();
                // ????????????
                Role adminRole = _roleManager.Roles.Single(r => r.Name == StaticRoleNames.Tenants.Admin);
                await _roleManager.GrantAllPermissionsAsync(adminRole);

                // ?????????????????????????????????
                var adminUser = User.CreateTenantAdminUser(tenant.Id, input.AdminEmailAddress);


                // ????????????????????????,??????????????????????????? 123qwe
                adminUser.Password = _passwordHasher.HashPassword(adminUser, input.TenantAdminPassword.IsNullOrWhiteSpace() ? User.DefaultPassword : input.TenantAdminPassword);
                CheckErrors(await UserManager.CreateAsync(adminUser));

                // ?????????????????????id
                await CurrentUnitOfWork.SaveChangesAsync();

                // ??????
                CheckErrors(await UserManager.AddToRoleAsync(adminUser, adminRole.Name));
                await CurrentUnitOfWork.SaveChangesAsync();


            }
            return tenant.MapTo<TenantDto>();


 

        }

        //private void CheckErrors(IdentityResult identityResult)
        //{
        //    identityResult.CheckErrors(LocalizationManager);
        //}

    }
}