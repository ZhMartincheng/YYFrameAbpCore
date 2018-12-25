using Abp.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace YY.Frame.AbpCore.Users.Dto
{
	public class ChangePasswordInput
	{
		[Required]
		[DisableAuditing]
		public string CurrentPassword { get; set; }

		[Required]
		[DisableAuditing]
		public string NewPassword { get; set; }
	}
}
