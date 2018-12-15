using Abp.EntityHistory;
using System;
using System.Collections.Generic;
using System.Text;
using YY.Frame.AbpCore.Authorization.Users;

namespace YY.Frame.AbpCore.Auditing.Dtos
{
	public class EntityChangeAndUser
	{
		public EntityChange EntityChange { get; set; }

		public User User { get; set; }
	}
}
