

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using IsMatch.AbpStudy.Authorization;

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Authorization
{
    /// <summary>
    /// ???????????????????????????
    /// ???????????????????????????
    /// See <see cref="PhoneNumberPermissions" /> for all permission names. PhoneNumber
    ///</summary>
    public class PhoneNumberAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PhoneNumberAuthorizationProvider()
		{

		}

        public PhoneNumberAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PhoneNumberAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// ??????????????????PhoneNumber ????????????
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PhoneNumberPermissions.Node , L("PhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.Query, L("QueryPhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.Create, L("CreatePhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.Edit, L("EditPhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.Delete, L("DeletePhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.BatchDelete, L("BatchDeletePhoneNumber"));
			entityPermission.CreateChildPermission(PhoneNumberPermissions.ExportExcel, L("ExportExcelPhoneNumber"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, AbpStudyConsts.LocalizationSourceName);
		}
    }
}