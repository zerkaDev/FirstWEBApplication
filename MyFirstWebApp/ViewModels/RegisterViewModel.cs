using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Неверное значение логина")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Не указана почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Не указан возраст")]
        [Range(14,100, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Неверное значение имени")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Неверное значение фамилии")]
        public string LastName { get; set; }
    }
}
