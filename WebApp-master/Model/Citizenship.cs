using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Citizenship
    {
        public long Id { get; set; }
        [Remote("MustBeUniqueCitizenship", controller: "Citizenships", AdditionalFields = nameof(CityId))]
        public long PersonId { get; set; }
        [Remote("MustBeUniqueCitizenship", controller: "Citizenships", AdditionalFields = nameof(PersonId))]
        public long CityId { get; set; }

        public Citizenship() {}
    }

    public class CitizenshipView
    {
        public Citizenship Citizenship { get; set; }
        public string PersonName { get; set; }
        public string CityName { get; set; }

        public CitizenshipView() { }
    }
}
