using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Category
    {
        public Category(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Category() { }

        public string Id { get; set; }
        public string Name { get; set; }


    }
}
