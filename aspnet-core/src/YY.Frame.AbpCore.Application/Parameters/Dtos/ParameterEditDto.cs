
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;
using YY.Frame.AbpCore.Parameters;

namespace  YY.Frame.AbpCore.Parameters.Dtos
{
    public class ParameterEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public long? Id { get; set; }         


        
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