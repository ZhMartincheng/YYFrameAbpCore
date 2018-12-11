
using Abp.Runtime.Validation;
using YY.Frame.Dtos;
using YY.Frame.AbpCore.Persons;

namespace YY.Frame.AbpCore.Persons.Dtos
{
    public class GetBooksInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
