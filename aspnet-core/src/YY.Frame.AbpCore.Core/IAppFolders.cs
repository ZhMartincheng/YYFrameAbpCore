using System;
using System.Collections.Generic;
using System.Text;

namespace YY.Frame.AbpCore
{
	public interface IAppFolders
	{
		string TempFileDownloadFolder { get; }

		string SampleProfileImagesFolder { get; }

		string WebLogsFolder { get; set; }
	}
}
