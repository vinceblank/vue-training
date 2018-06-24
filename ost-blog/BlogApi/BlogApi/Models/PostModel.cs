using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApi.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    }
}