﻿using Abp.UI;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YY.Frame.AbpCore.ExcelExport;

namespace YY.Frame.AbpCore.Controllers
{
public 	class FileController:YoyoCmsTemplateControllerBase
	{
		private readonly IAppFolders _appFolders;

		public FileController(IAppFolders appFolders)
		{
			_appFolders = appFolders;
		}

		//[DisableAuditing]
		public ActionResult DownloadTempFile(FileDto file)
		{
			var filePath = Path.Combine(_appFolders.TempFileDownloadFolder, file.FileToken);
			if (!System.IO.File.Exists(filePath))
			{
				throw new UserFriendlyException(L("RequestedFileDoesNotExists"));
			}

			var fileBytes = System.IO.File.ReadAllBytes(filePath);
			System.IO.File.Delete(filePath);
			return File(fileBytes, file.FileType, file.FileName);
		}
	}
}
