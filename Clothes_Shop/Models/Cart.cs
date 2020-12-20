using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Cart 
    {

        public Cart(string Id,string ItemId, string UserId) {
            this.Id = Id;
            this.ItemId = ItemId;
            this.UserId = UserId;
        }

        public Cart() {}
        
        [Required]
        public string Id { get; set; }

        [Required]
        public string ItemId { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}
