using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Shop.Models
{
    public class Category : IValidatableObject
    {
        public Category(string Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public Category() { }

        //[Required]
        public string Id { get; set; }


        //[Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Name))
                errors.Add(new ValidationResult("Name is not written"));

            if (string.IsNullOrWhiteSpace(this.Id))
                errors.Add(new ValidationResult("Id is not written"));

            return errors;
            //throw new NotImplementedException();
        }
    }
}
