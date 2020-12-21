using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Person
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Birthday")]
        public DateTime DateTimeOfBirth { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password do not match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "City")]
        public IList<Citizenship> Citizenships { get; set; }
        public IList<FriendEntry> Friends { get; set; }

        public Person()
        {

        }

        public Person(long id, string name, string surname, Gender gender, DateTime dateTimeOfBirth)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            Gender = gender;
            DateTimeOfBirth = dateTimeOfBirth;
        }
    }

    public enum Gender
    {
        None,
        Male,
        Female,
        Other
    }
}
