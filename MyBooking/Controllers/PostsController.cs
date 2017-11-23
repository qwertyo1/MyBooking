using MyBooking.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBooking.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        public ActionResult Index(string searchStr)
        {
            List<Post> posts = null;
            using (PostContext db = new PostContext())
            {
                if (searchStr != null)
                {
                    posts = db.Posts.Where(p => p.Name.Contains(searchStr) || p.Content.Contains(searchStr) || p.UserName.Contains(searchStr)).ToList();
                }
                else
                {
                    posts = db.Posts.ToList();
                }
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
        public ActionResult Create(Post model, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    model.Image = imageData;
                } else
                {
                    model.Image = null;
                }

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
                        db.Posts.Add(new Post { Name = model.Name, Content = model.Content, Price = model.Price, CreationDate = currentDate, UserName = User.Identity.Name, Image = model.Image});
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