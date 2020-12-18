using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Citizenship
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public long CityId { get; set; }
    }
}
