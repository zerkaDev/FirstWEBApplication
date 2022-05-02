using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFirstWebApp.Models;
using MyFirstWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyFirstWebApp.Controllers
{
    public class AccountController : Controller
    {
        ApplicationContext _dbcontext;
        IWebHostEnvironment _appEnvironment;
        public AccountController(ApplicationContext dbcontext, IWebHostEnvironment appEnvironment)
        {
            _dbcontext = dbcontext;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Post()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Register", "Account");
        }
        [HttpPost]
        public async Task<IActionResult> Post(PostViewModel postViewModel)
        {
            //Не уверен что это проверка нужна
            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {
                    var images = new List<Image>() { new Image { Path = "/Photos/NoImage.png" } };
                    if (postViewModel.uploadedFile != null)
                    {
                        string path = "/Photos/" + postViewModel.uploadedFile.FileName;
                        using(var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                        {
                            await postViewModel.uploadedFile.CopyToAsync(fileStream);
                        }
                        images = new List<Image>() { new Image { Path = path } };
                    }
                    User currentUser = _dbcontext.Users.FirstOrDefault(u => u.Login == User.Identity.Name);
                    Post post = new Post()
                    {
                        Images = images,
                        IsPrivate = postViewModel.IsPrivate,
                        Title = postViewModel.Title,
                        ShortDesc = postViewModel.ShortDesc,
                        LongDesc = postViewModel.LongDesc,
                        User = currentUser
                    };
                    _dbcontext.Posts.Add(post);
                    _dbcontext.SaveChanges();
                    return Redirect($"/Home/Post/{post.Id}");
                }
                return View(postViewModel);
            }
            return RedirectToAction("Register", "Account");
        }
        //TODO: Во вью сделать как то чтоб фотки растягивались
        public IActionResult MyPosts()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(_dbcontext.Posts.Where(p=>p.User.Login == User.Identity.Name).Include(i=>i.Images));
            }
            return RedirectToAction("Register", "Account");
        }
        public IActionResult Favorits()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _dbcontext.Users.FirstOrDefault(l => l.Login == User.Identity.Name);
                var fp = _dbcontext.Posts.Include(p => p.UsersWhoLiked).Include(i=>i.Images);
                List<Post> favposts = new List<Post>();
                foreach (var item in fp)
                {
                    foreach (var favpost in item.UsersWhoLiked)
                    {
                        if (favpost.UserId == user.Id) favposts.Add(favpost.Post);
                    }
                }

                return View(favposts);
            }
            return RedirectToAction("Register", "Account");
        }
        public IActionResult Settings()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View(_dbcontext.Users.FirstOrDefault(l=>l.Login == User.Identity.Name)); 
            }
            return RedirectToAction("Register", "Account");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = _dbcontext.Users.FirstOrDefault(u => u.Login == model.Login && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Login);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Неверный логин или пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
         {
            if (ModelState.IsValid)
            {
                //лучше сделать вместо ключа уникальным логин
                User user = _dbcontext.Users.FirstOrDefault(u => u.Login == model.Login);
                if (user == null)
                {
                    _dbcontext.Users.Add(new Models.User
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        Login = model.Login,
                        Password = model.Password,
                        Age = model.Age,
                        Email = model.Email
                    });
                    _dbcontext.SaveChanges();
                    await Authenticate(model.Login);
                    return RedirectToAction("Index", "Home");
                }
                else ModelState.AddModelError("", "Пользователь уже зарегестрирован");
            }
            return View(model);
        }
        private async Task Authenticate(string UserName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, UserName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
