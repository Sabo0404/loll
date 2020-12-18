using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Person
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateTimeOfBirth { get; set; }
        public IList<Citizenship> Citizenships { get; set; }
        public IList<FriendEntry> Friends { get; set; }

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
