using System.ComponentModel.DataAnnotations;

namespace NbscwMPACarFactory.Configuration.Dto
{
    public class ChangeUiThemeInput
    {
        [Required]
        [MaxLength(32)]
        public string Theme { get; set; }
    }
}