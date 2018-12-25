using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace YY.Frame.AbpCore.Parameters
{
	public class Parameter : FullAuditedEntity<long>
	{
		public string ParameterCode { get; set; }

		public string ParameterValue { get; set; }

		public string ParameterDesc { get; set; }
	}
}
