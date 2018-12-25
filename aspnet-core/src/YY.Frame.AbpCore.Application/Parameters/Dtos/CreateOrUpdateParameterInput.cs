

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YY.Frame.AbpCore.Parameters;

namespace YY.Frame.AbpCore.Parameters.Dtos
{
    public class CreateOrUpdateParameterInput
    {
        [Required]
        public ParameterEditDto Parameter { get; set; }

    }
}