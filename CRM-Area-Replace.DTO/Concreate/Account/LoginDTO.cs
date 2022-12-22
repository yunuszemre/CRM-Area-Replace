using CRM_Area_Replace.DTO.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Area_Replace.DTO.Concreate.Account
{
	public class LoginDTO : BaseDTO
	{
		[Required]
		[EmailAddress]
		[Display(Name = "Kullanıcı Adı")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name ="Şifre")]
		public string Password { get; set; }

		[Display(Name ="Beni Hatırla")]
		public bool RememberMe { get; set; }
	}
}
