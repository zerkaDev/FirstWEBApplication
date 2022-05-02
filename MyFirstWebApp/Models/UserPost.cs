using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class UserPost
    {
        [Key, Column(Order = 0)]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Key, Column(Order = 1)]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
