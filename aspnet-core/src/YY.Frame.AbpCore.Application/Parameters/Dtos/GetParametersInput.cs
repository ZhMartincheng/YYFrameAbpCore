
using Abp.Runtime.Validation;
using YY.Frame.Dtos;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.AbpCore.Parameters.Dtos
{
    public class GetParametersInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
