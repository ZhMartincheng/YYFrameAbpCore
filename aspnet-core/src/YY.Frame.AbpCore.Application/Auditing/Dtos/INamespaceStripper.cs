using System;
using System.Collections.Generic;
using System.Text;

namespace YY.Frame.AbpCore.Auditing.Dtos
{
public interface INamespaceStripper
	{
		string StripNameSpace(string serviceName);
	}
}
