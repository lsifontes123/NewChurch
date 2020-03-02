using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyChurch.Web.Data.Entities;

namespace MyChurch.Web.Data
{
    public class DataContext : IdentityDbContext<User>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ChurchEvent> ChurchEvents { get; set; }
        public DbSet<Disciple> Disciples { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Ministry> Ministries { get; set; }
        public DbSet<MinistryType> MinistryTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        public DbSet<FollowUpHistory> FollowUpHistories { get; set; }



    }
}
