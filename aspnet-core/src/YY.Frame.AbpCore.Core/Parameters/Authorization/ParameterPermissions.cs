

namespace YY.Frame.AbpCore.Parameters.Authorization
{
	/// <summary>
    /// 定义系统的权限名称的字符串常量。
    /// <see cref="ParameterAuthorizationProvider" />中对权限的定义.
    ///</summary>
	public static  class ParameterPermissions
	{
		/// <summary>
		/// Parameter权限节点
		///</summary>
		public const string Node = "Pages.Parameter";

		/// <summary>
		/// Parameter查询授权
		///</summary>
		public const string Query = "Pages.Parameter.Query";

		/// <summary>
		/// Parameter创建权限
		///</summary>
		public const string Create = "Pages.Parameter.Create";

		/// <summary>
		/// Parameter修改权限
		///</summary>
		public const string Edit = "Pages.Parameter.Edit";

		/// <summary>
		/// Parameter删除权限
		///</summary>
		public const string Delete = "Pages.Parameter.Delete";

        /// <summary>
		/// Parameter批量删除权限
		///</summary>
		public const string BatchDelete = "Pages.Parameter.BatchDelete";

		/// <summary>
		/// Parameter导出Excel
		///</summary>
		public const string ExportExcel="Pages.Parameter.ExportExcel";

		 
		 
         
    }

}

