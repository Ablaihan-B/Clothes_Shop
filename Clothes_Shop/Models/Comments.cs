using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Comments
    {

        public string Id { get; set; }
        public string Content { get; set; }
        public Item Item  { get; set; }
       // public IdentityUser Author { get; set; }

    }
}
