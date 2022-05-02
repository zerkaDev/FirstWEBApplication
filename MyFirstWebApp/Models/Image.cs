using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Models
{
    public class Image
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        private string path = "/Photos/NoImage.png";
        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
    }
}
