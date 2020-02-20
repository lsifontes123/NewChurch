using Microsoft.EntityFrameworkCore;
using MyChurch.Web.Data.Entities;

namespace MyChurch.Web.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<ChurchEvent> ChurchEvents { get; set; }
        public DbSet<Disciple> Disciples { get; set; }
        public DbSet<MemberImage> MemberImages { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Ministry> Ministries { get; set; }
        public DbSet<MinistryImage> MinistryImages { get; set; }
        public DbSet<MinistryType> MinistryTypes { get; set; }


    }
}
