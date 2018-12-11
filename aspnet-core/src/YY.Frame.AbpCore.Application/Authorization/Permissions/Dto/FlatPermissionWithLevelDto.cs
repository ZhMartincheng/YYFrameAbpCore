using System.Collections.Generic;

namespace YY.Frame.Application.Authorization.Permissions.Dto
{
	public class FlatPermissionWithLevelDto//: FlatPermissionDto
	{
		public string title { get; set; }
		public string key { get; set; }
		/// <summary>
		/// 是否展开
		/// </summary>
		public bool expanded { get; set; } = true;

		/// <summary>
		/// IsLeaf函数返回true若指定的成员是叶成员
		/// </summary>
		public bool isLeaf { get; set; }
		public int level { get; set; } = 0;

		public List<FlatPermissionWithLevelDto> children { get; set; }
	}
}
