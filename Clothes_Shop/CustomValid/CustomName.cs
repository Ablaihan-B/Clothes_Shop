using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.CustomValid
{
    public class CustomName:ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            String name = value.ToString();
            return base.IsValid(name);
        }
    }
}
