
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Authorization;
using Abp.Linq.Extensions;
using Abp.Domain.Repositories;
using Abp.Application.Services;
using Abp.Application.Services.Dto;


using YY.Frame.AbpCore.Parameters.Dtos;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.AbpCore.Parameters
{
    /// <summary>
    /// Parameter应用层服务的接口方法
    ///</summary>
    public interface IParameterAppService : IApplicationService
    {
        /// <summary>
		/// 获取Parameter的分页列表信息
		///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<PagedResultDto<ParameterListDto>> GetPaged(GetParametersInput input);


		/// <summary>
		/// 通过指定id获取ParameterListDto信息
		/// </summary>
		Task<ParameterListDto> GetById(EntityDto<long> input);


        /// <summary>
        /// 返回实体的EditDto
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<GetParameterForEditOutput> GetForEdit(NullableIdDto<long> input);


        /// <summary>
        /// 添加或者修改Parameter的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateOrUpdate(CreateOrUpdateParameterInput input);


        /// <summary>
        /// 删除Parameter信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task Delete(EntityDto<long> input);


        /// <summary>
        /// 批量删除Parameter
        /// </summary>
        Task BatchDelete(List<long> input);


		/// <summary>
        /// 导出Parameter为excel表
        /// </summary>
        /// <returns></returns>
		//Task<FileDto> GetToExcel();

    }
}
