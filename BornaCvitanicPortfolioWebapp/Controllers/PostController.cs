using BornaCvitanicPortfolioWebapp.DAL;
using BornaCvitanicPortfolioWebapp.Model.Portfolio;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BornaCvitanicPortfolioWebapp.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext _dbContext;
        private UserManager<IdentityUser> _userManager;

        public PostController(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var posts = this._dbContext.Posts.ToList();
            return View(posts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                this._dbContext.Posts.Add(post);
                this._dbContext.SaveChanges();

                var lastPost = this._dbContext.Posts.OrderByDescending(p => p.Id).First();

                return View("UploadPhoto", lastPost);

            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var post = this._dbContext.Posts.Where(p => p.Id==id).FirstOrDefault();
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> EditPost(int id)
        {
            var post = this._dbContext.Posts.Single(p => p.Id == id);
            var ok = await this.TryUpdateModelAsync(post);

            if (ok && this.ModelState.IsValid)
            {
                this._dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var post = this._dbContext.Posts.Where(p => p.Id == id).First();

            this._dbContext.Posts.Remove(post);
            this._dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UploadImage(int postId, IFormFile file)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = file.FileName;
            string fileNameWithPath = Path.Combine(path, fileName);

            bool fileExists = System.IO.File.Exists(fileNameWithPath);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var post = this._dbContext.Posts.Where(p => p.Id == postId).First();

            post.ImagePath = fileName;

            var ok = await this.TryUpdateModelAsync(post);

            if (ok)
            {
                this._dbContext.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
