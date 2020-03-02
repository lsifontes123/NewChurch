


using System;
using System.Linq;
using System.Threading.Tasks;
using MyChurch.Web.Data.Entities;
using MyChurch.Web.Helpers;

namespace MyChurch.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext context,
            IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRoles();
            var admin = await CheckUserAsync("1010", "Juan", "Zuluaga", "jzuluaga55@gmail.com", "350 634 2747", "Calle Luna Calle Sol", "Admin");
            var mentor = await CheckUserAsync("2020", "Juan", "Zuluaga", "jzuluaga55@hotmail.com", "350 634 2747", "Calle Luna Calle Sol", "Mentor");
            var disciple = await CheckUserAsync("2020", "Juan", "Zuluaga", "carlos.zuluaga@globant.com", "350 634 2747", "Calle Luna Calle Sol", "Disciple");
            await CheckMinistryTypesAsync();
            await CheckAdminsAsync(admin);
            await CheckMentorsAsync(mentor);
            await CheckDisciplesAsync(disciple);
            await CheckMinistriesAsync();
            await CheckChurchEventsAsync();
            await CheckServiceTypesAsync();
        }

        private async Task CheckAdminsAsync(User user)
        {
            if (!_context.Admins.Any())
            {
                _context.Admins.Add(new Admin { User = user });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckRoles()
        {
            await _userHelper.CheckRoleAsync("Admin");
            await _userHelper.CheckRoleAsync("Mentor");
            await _userHelper.CheckRoleAsync("Disciple");
        }

        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, string role)
        {
            var user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, role);
            }

            return user;
        }




        private async Task CheckDisciplesAsync(User user)
        {
            if (!_context.Disciples.Any())
            {
                _context.Disciples.Add(new Disciple { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMinistriesAsync()
        {
            var admin = _context.Admins.FirstOrDefault();
            var ministryType = _context.MinistryTypes.FirstOrDefault();
            if (!_context.Ministries.Any())
            {
                AddMinistry("Calle 43 #23 32", "Poblado", "fdsfsdfsdf", admin, ministryType, 800000M, "blah blah","verde");
                AddMinistry("Calle 12 Sur #2 34", "Envigado", "gsfdgdgsfgs", admin, ministryType, 950000M, "blahBlah","rojo");
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMinistryTypesAsync()
        {
            if (!_context.MinistryTypes.Any())
            {
                _context.MinistryTypes.Add(new MinistryType { Name = "Outreach Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "General Fellowship" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Youth Fellowship" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Marriage Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Women's Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Men's Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Prayer Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "HouseHold Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Childer Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Usher Ministry" });
                _context.MinistryTypes.Add(new MinistryType { Name = "Worship Ministry" });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckMentorsAsync(User user)
        {
            if (!_context.Mentors.Any())
            {
                _context.Mentors.Add(new Mentor { User = user });
                await _context.SaveChangesAsync();
            }
        }

        private void AddMinistry(string location,
            string leader,
            string subLeader,
            Admin admin,
            MinistryType ministryType,
            decimal fund,
            string biblicalWord,
            string name)
        {
            _context.Ministries.Add(new Ministry
            {
                Name = name,
                Location = location,
                Leader = leader,
                SubLeader = subLeader,
                Admin = admin,
                MinistryType = ministryType,
                BiblicalWord = biblicalWord,
                IsAvailable = true,
                Fund = fund

            });
        }
        private async Task CheckServiceTypesAsync()
        {
            if (!_context.ServiceTypes.Any())
            {
                _context.ServiceTypes.Add(new ServiceType { Name = "Consulta" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Urgencia" });
                _context.ServiceTypes.Add(new ServiceType { Name = "Vacunación" });
                await _context.SaveChangesAsync();
            } }
        private async Task CheckChurchEventsAsync()
        {
            var admin = _context.Admins.FirstOrDefault();
            var mentor = _context.Mentors.FirstOrDefault();
            var disciple = _context.Disciples.FirstOrDefault();
            var ministry = _context.Ministries.FirstOrDefault();
            var initialDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            var finalDate = initialDate.AddYears(1);
            if (!_context.ChurchEvents.Any())
            {
                while (initialDate < finalDate)
                {
                    if (initialDate.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var finalDate2 = initialDate.AddHours(10);
                        while (initialDate < finalDate2)
                        {

                            _context.ChurchEvents.Add(new ChurchEvent
                            {
                                Date = initialDate,
                                StartDate = DateTime.Today,
                                EndDate = DateTime.Today.AddYears(1),
                                IsActive = true,
                                Admin = admin,
                                Disciple = disciple,
                                Mentor = mentor,
                                Price = 800000M,
                                Ministry = ministry,
                                Remarks = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris nec iaculis ex. Nullam gravida nunc eleifend, placerat tellus a, eleifend metus. Phasellus id suscipit magna. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Nullam volutpat ultrices ex, sed cursus sem tincidunt ut. Nullam metus lorem, convallis quis dignissim quis, porttitor quis leo. In hac habitasse platea dictumst. Duis pharetra sed arcu ac viverra. Proin dapibus lobortis commodo. Vivamus non commodo est, ac vehicula augue. Nam enim felis, rutrum in tortor sit amet, efficitur hendrerit augue. Cras pellentesque nisl eu maximus tempor. Curabitur eu efficitur metus. Sed ultricies urna et auctor commodo."
                            });
                            initialDate = initialDate.AddMinutes(30);
                        }
                        initialDate = initialDate.AddHours(14);
                    }
                


                     else
                {
                    initialDate = initialDate.AddDays(1);
                }
            }
        }
    

                    await _context.SaveChangesAsync();
            
        }
    }
}




