

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.AbpCore.Parameters.Dtos
{
    public class ParameterListDto : FullAuditedEntityDto<long> 
    {

        
		/// <summary>
		/// ParameterCode
		/// </summary>
		[MinLength(2, ErrorMessage="ParameterCode小于最小长度")]
		[Required(ErrorMessage="ParameterCode不能为空")]
		public string ParameterCode { get; set; }



		/// <summary>
		/// ParameterValue
		/// </summary>
		[Required(ErrorMessage="ParameterValue不能为空")]
		public string ParameterValue { get; set; }



		/// <summary>
		/// ParameterDesc
		/// </summary>
		public string ParameterDesc { get; set; }




    }
}