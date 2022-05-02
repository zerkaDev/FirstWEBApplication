﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Post> Posts { get; set; }   
        public virtual IEnumerable<UserPost> FavoritePosts { get; set; } 
        public string Login { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        //TODO: Auth, pass, login, more info about user
    }
}
