using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyBooking.Models
{
    public class PostContext : DbContext
    {
        public PostContext() :
            base("DefaultConnection")
        { }

        public DbSet<Post> Posts { get; set; }

        public System.Data.Entity.DbSet<MyBooking.Models.CreatePostModel> CreatePostModels { get; set; }
    }
}