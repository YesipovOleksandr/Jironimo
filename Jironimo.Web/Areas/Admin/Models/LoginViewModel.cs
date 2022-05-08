using System.ComponentModel.DataAnnotations;

namespace Jironimo.Web.Areas.Admin.Models
{
        public class LoginViewModel
        {
            [Required(ErrorMessage = "Не указан Login")]
            public string Login { get; set; }

            [Required(ErrorMessage = "Не указан пароль")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
}
