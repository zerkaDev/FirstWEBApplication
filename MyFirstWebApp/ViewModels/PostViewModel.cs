using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels
{
    public class PostViewModel
    {
        [Required(ErrorMessage = "Заголовок обязателен")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Заголовок должен содержать от 2 до 30 символов")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Краткое описание обязателеньно")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Краткое описание должно содержать от 10 до 100 символов")]
        public string ShortDesc { get; set; }
        [Required(ErrorMessage = "Пост должен содержать информацию")]
        public string LongDesc { get; set; }
        public bool IsPrivate { get; set; }
        public IFormFile uploadedFile { get; set; }

    }
}
