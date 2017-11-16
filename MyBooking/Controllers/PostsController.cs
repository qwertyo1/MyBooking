using MyBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBooking.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index()
        {
            List<Post> posts = null;

            using (PostContext db = new PostContext())
            {
                posts = db.Posts.ToList();
            }
            return View(posts);
        }

        public ActionResult My()
        {
            List<Post> posts = null;

            using (PostContext db = new PostContext())
            {
                posts = db.Posts.Where(p => p.UserName == User.Identity.Name).ToList();
            }
            return View(posts);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreatePostModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = null;
                DateTime currentDate = DateTime.Now;
                using (PostContext db = new PostContext())
                {
                    post = db.Posts.Where(p => p.Name == model.Name).FirstOrDefault();
                }
                if (post == null)
                {
                    using (PostContext db = new PostContext())
                    {
                        db.Posts.Add(new Post { Name = model.Name, Content = model.Content, Price = model.Price, CreationDate = currentDate, UserName = User.Identity.Name });
                        db.SaveChanges();
                        post = db.Posts.Where(p => p.Name == model.Name).FirstOrDefault();
                    }
                    if (post != null)
                    {
                        return RedirectToAction("Index", "Posts");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Объявление с таким названием уже существует!");
                }
            }
            return View(model);
        }
    }
}