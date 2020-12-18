using System;
using System.Collections.Generic;

namespace WebApp.Model
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<Citizenship> Citizenships { get; set; }

        public City(long id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}