

namespace IsMatch.AbpStudy.PhoneBooks.Persons.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PersonAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class PersonPermissions
	{
		/// <summary>
		/// Person权限节点
		///</summary>
		public const string Node = "Pages.Person";

		/// <summary>
		/// Person查询授权
		///</summary>
		public const string Query = "Pages.Person.Query";

		/// <summary>
		/// Person创建权限
		///</summary>
		public const string Create = "Pages.Person.Create";

		/// <summary>
		/// Person修改权限
		///</summary>
		public const string Edit = "Pages.Person.Edit";

		/// <summary>
		/// Person删除权限
		///</summary>
		public const string Delete = "Pages.Person.Delete";

        /// <summary>
		/// Person批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Person.BatchDelete";

		/// <summary>
		/// Person导出Excel
		///</summary>
		public const string ExportExcel="Pages.Person.ExportExcel";

		 
		 
         
    }

}

