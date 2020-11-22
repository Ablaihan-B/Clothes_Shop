using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Models
{
    public class Item
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Features Features { get; set; }
        public Gender Gender { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

    }
}
