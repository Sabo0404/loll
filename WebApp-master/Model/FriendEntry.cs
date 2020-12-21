using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class FriendEntry
    {
        public long Id { get; set; }
        public long FirstPersonId { get; set; }
        public long SecondPersonId { get; set; }
    }
}
