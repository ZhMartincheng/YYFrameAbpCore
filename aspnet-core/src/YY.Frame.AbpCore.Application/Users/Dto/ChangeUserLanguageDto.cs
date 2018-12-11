using System.ComponentModel.DataAnnotations;

namespace YY.Frame.AbpCore.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}