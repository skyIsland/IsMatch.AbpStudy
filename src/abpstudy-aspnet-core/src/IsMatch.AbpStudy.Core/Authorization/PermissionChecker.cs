using Abp.Authorization;
using IsMatch.AbpStudy.Authorization.Roles;
using IsMatch.AbpStudy.Authorization.Users;

namespace IsMatch.AbpStudy.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
