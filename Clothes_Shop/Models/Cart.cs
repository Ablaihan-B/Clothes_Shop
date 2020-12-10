using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Cart
    {

        public Cart(string Id,Item Item, IdentityUser User ) {
            this.Id = Id;
            this.Item = Item;
            this.User = User;
        }

        public Cart() {}

        public string Id { get; set; }
        public Item Item { get; set; }

        public IdentityUser User { get; set; }

    }
}
