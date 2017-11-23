using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MyBooking.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive price")]
        public int Price { get; set; }

        public string UserName { get; set; }

        public DateTime CreationDate { get; set; }

        public byte[] Image { get; set; }
    }
}