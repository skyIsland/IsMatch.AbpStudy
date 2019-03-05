

using System.Linq;
using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;
using IsMatch.AbpStudy.Authorization;

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Authorization
{
    /// <summary>
    /// ???????????????????????????
    /// ???????????????????????????
    /// See <see cref="PersonPermissions" /> for all permission names. Person
    ///</summary>
    public class PersonAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

		public PersonAuthorizationProvider()
		{

		}

        public PersonAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public PersonAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

		public override void SetPermissions(IPermissionDefinitionContext context)
		{
			// ??????????????????Person ????????????
			var pages = context.GetPermissionOrNull(AppLtmPermissions.Pages) ?? context.CreatePermission(AppLtmPermissions.Pages, L("Pages"));

			var administration = pages.Children.FirstOrDefault(p => p.Name == AppLtmPermissions.Pages_Administration) ?? pages.CreateChildPermission(AppLtmPermissions.Pages_Administration, L("Administration"));

			var entityPermission = administration.CreateChildPermission(PersonPermissions.Node , L("Person"));
			entityPermission.CreateChildPermission(PersonPermissions.Query, L("QueryPerson"));
			entityPermission.CreateChildPermission(PersonPermissions.Create, L("CreatePerson"));
			entityPermission.CreateChildPermission(PersonPermissions.Edit, L("EditPerson"));
			entityPermission.CreateChildPermission(PersonPermissions.Delete, L("DeletePerson"));
			entityPermission.CreateChildPermission(PersonPermissions.BatchDelete, L("BatchDeletePerson"));
			entityPermission.CreateChildPermission(PersonPermissions.ExportExcel, L("ExportExcelPerson"));


		}

		private static ILocalizableString L(string name)
		{
			return new LocalizableString(name, AbpStudyConsts.LocalizationSourceName);
		}
    }
}