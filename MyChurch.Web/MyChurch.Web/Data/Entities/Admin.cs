using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Data.Entities
{
    public class Admin
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Ministry> Ministries { get; set; }
        public ICollection<ChurchEvent> ChurchEvents{ get; set; }
    }
}
