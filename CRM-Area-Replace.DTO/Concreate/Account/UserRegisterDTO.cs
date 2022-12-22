using CRM_Area_Replace.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Area_Replace.DTO.Concreate.Account
{
    public class UserRegisterDTO:BaseDTO
    {
        [Required]
        [EmailAddress]
        [Display(Name ="E-Posta")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Şifre")]
        [StringLength(100, MinimumLength = 6, ErrorMessage ="Şifre en az 6 karakter olmalıdır ve en az bir büyükharf ile bir özel karakter içermelidir")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage ="Şifreler uyuşmuyor")]
        [Display(Name ="Şifre Tekrar")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
