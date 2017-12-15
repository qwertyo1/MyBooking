using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using MyBooking.Controllers;
using MyBooking.Models;
using System.Linq;
using System.Collections.Generic;

[assembly: OwinStartup("ProductionConfiguration", typeof(MyBooking.App_Start.Startup))]

namespace MyBooking.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
                List<Post> posts = null;
                using (PostContext db = new PostContext())
                {
                    posts = db.Posts.ToList();
                    LuceneSearch.AddUpdateLuceneIndex(posts);
                }
            // Дополнительные сведения о настройке приложения см. на странице https://go.microsoft.com/fwlink/?LinkID=316888
        }
    }
}
