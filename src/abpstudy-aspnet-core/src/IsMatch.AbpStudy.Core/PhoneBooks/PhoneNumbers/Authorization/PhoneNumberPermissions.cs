

namespace IsMatch.AbpStudy.PhoneBooks.PhoneNumbers.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="PhoneNumberAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class PhoneNumberPermissions
	{
		/// <summary>
		/// PhoneNumber权限节点
		///</summary>
		public const string Node = "Pages.PhoneNumber";

		/// <summary>
		/// PhoneNumber查询授权
		///</summary>
		public const string Query = "Pages.PhoneNumber.Query";

		/// <summary>
		/// PhoneNumber创建权限
		///</summary>
		public const string Create = "Pages.PhoneNumber.Create";

		/// <summary>
		/// PhoneNumber修改权限
		///</summary>
		public const string Edit = "Pages.PhoneNumber.Edit";

		/// <summary>
		/// PhoneNumber删除权限
		///</summary>
		public const string Delete = "Pages.PhoneNumber.Delete";

        /// <summary>
		/// PhoneNumber批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.PhoneNumber.BatchDelete";

		/// <summary>
		/// PhoneNumber导出Excel
		///</summary>
		public const string ExportExcel="Pages.PhoneNumber.ExportExcel";

		 
		 
         
    }

}

