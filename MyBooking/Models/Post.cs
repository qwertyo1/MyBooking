using System;

namespace MyBooking.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public int Price { get; set; }
        public string UserName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}