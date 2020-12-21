using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Model
{
    public class City : IValidatableObject
    {
        public long Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        public IList<Citizenship> Citizenships { get; set; }

        public City()
        {

        }

        public City(long id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Name.Contains(" "))
                yield return new ValidationResult("Input 'Name' must be a single word");
        }
    }
}