using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Comments
    {
        public Comments(string Id, string Content, Item Item , IdentityUser Author)
        {
            this.Id = Id;
            this.Content = Content;
            this.Item = Item;
            this.Author = Author;
        }

        public Comments() { }

        public string Id { get; set; }
        public string Content { get; set; }
        public Item Item  { get; set; }
       
        public IdentityUser Author { get; set; }

    }
}
