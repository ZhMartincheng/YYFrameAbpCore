using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace YY.Frame.AbpCore
{
	public class AppFolders : IAppFolders, ISingletonDependency
	{
		public string TempFileDownloadFolder { get; set; }

		public string SampleProfileImagesFolder { get; set; }

		public string WebLogsFolder { get; set; }
	}
}
