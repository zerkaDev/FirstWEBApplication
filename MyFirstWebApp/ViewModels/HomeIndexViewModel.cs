using MyFirstWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public PageViewModel PageViewModel { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}
