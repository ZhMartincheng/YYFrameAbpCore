

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YY.Frame.AbpCore.Persons;

namespace YY.Frame.AbpCore.Persons.Dtos
{
    public class CreateOrUpdateBookInput
    {
        [Required]
        public BookEditDto Book { get; set; }

    }
}