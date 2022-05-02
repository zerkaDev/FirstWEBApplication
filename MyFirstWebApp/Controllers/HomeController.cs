using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFirstWebApp.Models;
using MyFirstWebApp.ViewModels;
using MyFirstWebApp.ViewModels.Enums;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _dbcontext;

        public IConfiguration Configuration { get; }
        public HomeController(ApplicationContext dbcontext, IConfiguration configuration)
        {
            Configuration = configuration;
            _dbcontext = dbcontext;
        }
        public IActionResult AddFavPost(int id)
        {
            //var postId = int.Parse(HttpContext.Request.Path.ToString().Skip(10).ToString());
            if (!User.Identity.IsAuthenticated) return RedirectToAction("Register", "Account");
            var user = _dbcontext.Users.Include(p => p.FavoritePosts).FirstOrDefault(u => u.Login == User.Identity.Name);
            YavnoSukaVstavitZnachenieDB(user.Id, id);
            return Redirect($"/Home/Post/{id}");
        }
        public IActionResult Post(int? id)
        {
            if (id == null) return NotFound();
            //Не уверен что это быстро
            var post = _dbcontext.Posts.Include(p => p.Images).Include(u => u.User).Include(fp=>fp.UsersWhoLiked).FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound();
            var user = _dbcontext.Users.Include(p=>p.Posts).FirstOrDefault(u => u.Login == User.Identity.Name);
            //var LikedUserPost = _dbcontext.Posts.Include(u => u.UsersWhoLiked).FirstOrDefault(p => p.Id == id);
            //var UserLiked = LikedUserPost.UsersWhoLiked.FirstOrDefault(u => u.UserId == user.Id);
            if (post.IsPrivate && !user.Posts.Contains(post)) return Content("Пост привантый! Вы не его владелец! Пожалуйста сделай отоброжение меня более презентабельным!");
            if (user != null && post.UsersWhoLiked.FirstOrDefault(u=>u.UserId == user.Id) != null) ViewBag.IsLiked = true;
            else ViewBag.IsLiked = false;
            ViewBag.LikesCount = post.UsersWhoLiked.Count();
            return View(post);

        }
        public IActionResult Index(int page = 1, SortState sortOrder = SortState.DateAsc)
        {
            int pageSize = 3;

            var posts = _dbcontext.Posts.Include(p => p.Images).Include(u=>u.UsersWhoLiked).Where(p => p.IsPrivate == false);
            // Сортировка по дейтдтайм не работает потому что при проектировании не заметил того что datetime не спарсилось в бд
            ViewBag.Date = "по убыванию";
            ViewBag.Like = "по убыванию";
            switch (sortOrder)
            {
                case SortState.DateAsc:
                    posts = posts.OrderBy(x => x.Id);
                    ViewBag.Date = "по возрастанию";
                    break;
                case SortState.DateDesc:
                    posts = posts.OrderByDescending(x => x.Id);
                    ViewBag.Date = "по убыванию";
                    break;
                case SortState.LikesAsc:
                    posts = posts.OrderBy(x => x.UsersWhoLiked.Count());
                    ViewBag.Like = "по возрастанию";
                    break;
                case SortState.LikesDesc:
                    posts = posts.OrderByDescending(x => x.UsersWhoLiked.Count());
                    ViewBag.Like = "по убыванию";
                    break;
            }

            var count = posts.Count();
            IEnumerable<Post> items = posts.Skip((page - 1) * pageSize).Take(pageSize);
            HomeIndexViewModel viewModel = new HomeIndexViewModel
            {
                Posts = items,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder)
            };

            return View(viewModel);
        }
        private async Task YavnoSukaVstavitZnachenieDB(int userId, int postId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();

                string sqlExpression = $"INSERT INTO UserPost (UserId, PostId) VALUES ({userId}, {postId})";
                SqlCommand command = new SqlCommand(sqlExpression, sqlConnection);
                await command.ExecuteNonQueryAsync();
            }
        }
    }
}
