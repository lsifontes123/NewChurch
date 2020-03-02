using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Data.Entities
{
    public class Mentor
    {
        public int Id { get; set; }
        public User User{ get; set; }

        public ICollection<ChurchEvent> ChurchEvents { get; set; }
        
    }

}

