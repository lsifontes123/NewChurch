using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyChurch.Web.Data.Entities
{
    public class Disciple
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<ChurchEvent> ChurchEvents { get; set; }
        
    }
}

