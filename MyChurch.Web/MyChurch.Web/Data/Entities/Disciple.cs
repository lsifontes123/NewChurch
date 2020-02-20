using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyChurch.Web.Data.Entities
{
    public class Disciple
    {
        public int Id { get; set; }

        public User User { get; set; }

        public ICollection<Ministry> Ministries { get; set; }

        public ICollection<MemberImage> MemberImages{ get; set; }
        public ICollection<ChurchEvent> ChurchEvents { get; set; }
    }
}

