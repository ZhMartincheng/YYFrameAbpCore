using Abp.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using YY.Frame.AbpCore.Authorization.Users;

namespace YY.Frame.AbpCore.Auditing.Dtos
{
	public class AuditLogAndUser
	{
		public AuditLog AuditLog { get; set; }

		public User User { get; set; }
	}
}
