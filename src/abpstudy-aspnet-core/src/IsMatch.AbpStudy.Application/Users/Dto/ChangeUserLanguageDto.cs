using System.ComponentModel.DataAnnotations;

namespace IsMatch.AbpStudy.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}