
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
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using YY.Frame.AbpCore.Parameters;
using YY.Frame.AbpCore.Parameters.Dtos;
using YY.Frame.AbpCore.Parameters.DomainService;
using YY.Frame.AbpCore.Parameters.Authorization;


namespace YY.Frame.AbpCore.Parameters
{
    /// <summary>
    /// Parameter应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class ParameterAppService : YoyoCmsTemplateAppServiceBase, IParameterAppService
    {
        private readonly IRepository<Parameter, long> _entityRepository;

        private readonly IParameterManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public ParameterAppService(
        IRepository<Parameter, long> entityRepository
        ,IParameterManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取Parameter的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(ParameterPermissions.Query)] 
        public async Task<PagedResultDto<ParameterListDto>> GetPaged(GetParametersInput input)
		{


			//var listFilter = query2 
			//	// .Include(u => u.user.Roles)//.Include(u=> u.BusinessUnits)
			//	//.WhereIf(input.Role.HasValue, u => u.user.Roles.Any(r => r.RoleId == input.Role.Value))
			//	.WhereIf(
			//		!StringExtensions.IsNullOrWhiteSpace(input.FilterText),
			//		u =>
			//			(
			//				u.businessUnits.BusinessName.Contains(input.FilterText)
			//				|| u.gather.GatherName.Contains(input.FilterText)
			//				|| u.gather.MaintainPerson.Contains(input.FilterText)
			//				|| u.gather.MaintainPhone.Contains(input.FilterText)
			//				|| u.gather.GatherAddress.Contains(input.FilterText)
			//				|| u.gather.EquipmentCode.Contains(input.FilterText)
			//				|| u.gather.GatherDesc.Contains(input.FilterText)
			//			)

			//	).WhereIf(
			//		!(businessId == 0),
			//		u => u.gather.BusinessUnitId == businessId
			//	); ;



			var query = _entityRepository.GetAll()
				// TODO:根据传入的参数添加过滤条件
				.WhereIf(!input.FilterText.IsNullOrWhiteSpace(),
				item => item.ParameterCode.Contains(input.FilterText)
				|| item.ParameterDesc.Contains(input.FilterText)
				|| item.ParameterValue.Contains(input.FilterText)
				);
				//.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), item => item.ParameterDesc.Contains(input.FilterText))
				//.WhereIf(!input.FilterText.IsNullOrWhiteSpace(), item => item.ParameterValue.Contains(input.FilterText));
			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<ParameterListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<ParameterListDto>>();

			return new PagedResultDto<ParameterListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取ParameterListDto信息
		/// </summary>
		[AbpAuthorize(ParameterPermissions.Query)] 
		public async Task<ParameterListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<ParameterListDto>();
		}

		/// <summary>
		/// 获取编辑 Parameter
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ParameterPermissions.Create,ParameterPermissions.Edit)]
		public async Task<GetParameterForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetParameterForEditOutput();
ParameterEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<ParameterEditDto>();

				//parameterEditDto = ObjectMapper.Map<List<parameterEditDto>>(entity);
			}
			else
			{
				editDto = new ParameterEditDto();
			}

			output.Parameter = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改Parameter的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ParameterPermissions.Create,ParameterPermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateParameterInput input)
		{

			if (input.Parameter.Id.HasValue)
			{
				await Update(input.Parameter);
			}
			else
			{
				await Create(input.Parameter);
			}
		}


		/// <summary>
		/// 新增Parameter
		/// </summary>
		[AbpAuthorize(ParameterPermissions.Create)]
		protected virtual async Task<ParameterEditDto> Create(ParameterEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

             //var entity2 = ObjectMapper.Map <Parameter>(input);
            var entity=input.MapTo<Parameter>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<ParameterEditDto>();
		}

		/// <summary>
		/// 编辑Parameter
		/// </summary>
		[AbpAuthorize(ParameterPermissions.Edit)]
		protected virtual async Task Update(ParameterEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除Parameter信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(ParameterPermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除Parameter的方法
		/// </summary>
		[AbpAuthorize(ParameterPermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出Parameter为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


