using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public bool IsPrivate { get; set; }
        // int AverageOtsenka
        public List<Image> Images { get; set; } /*= new List<Image>() { new Image() *//*};*/
        public virtual IEnumerable<UserPost> UsersWhoLiked { get; set; }
        // public string[] KeyWords { get; set; }  Troubles with db, нужно придумать как использовать ключевые слова в рамках этой сущности или абстрагировать этот параметр в виде отдельной сущености
        public DateTime Created { get; } = DateTime.Now;
        public User User { get; set; }
        // Для того чтобы каскадное удаление не работало. По логике все же нужно сделать чтобы при удалении пользователя удалялись все его посты
        public int? UserId { get; set; }

    }
}
