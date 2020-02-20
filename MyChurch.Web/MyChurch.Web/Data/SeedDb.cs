using MyChurch.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        public SeedDb(DataContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckMinistryTypesAsync();
            await CheckMentorsAsync();
            await CheckDisciplesAsync();
            await CheckMinistriesAsync();
        }
        private async Task CheckMinistryTypesAsync()
        {
            if (!_context.MinistryTypes.Any())
            {
                _context.MinistryTypes.Add(new Entities.MinistryType { Name = "Adoracion" });
                _context.MinistryTypes.Add(new Entities.MinistryType { Name = "Matrimonio" });
                _context.MinistryTypes.Add(new Entities.MinistryType{ Name = "Jovenes" });
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckDisciplesAsync()
        {
            if (!_context.Disciples.Any())
            {
                AddDisciple("876543", "Ramon", "Gamboa", "234 3232", "310 322 3221", "Calle Luna Calle Sol");
                AddDisciple("654565", "Julian", "Martinez", "343 3226", "300 322 3221", "Calle 77 #22 21");
                AddDisciple("214231", "Carmenza", "Ruis", "450 4332", "350 322 3221", "Carrera 56 #22 21");
                await _context.SaveChangesAsync();
            }
        }
        private void AddDisciple(string document, string firstName, string lastName, string fixedPhone, string cellPhone, string address)
        {
            _context.Disciples.Add(new Disciple
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = firstName,
                FixedPhone = fixedPhone,
                LastName = lastName
            });
        }
        private async Task CheckMinistriesAsync()
        {
            var mentor = _context.Mentors.FirstOrDefault();
            var ministryType = _context.MinistryTypes.FirstOrDefault();
            if (!_context.Ministries.Any())
            {
                AddMinistry("Calle 43 #23 32", "Poblado","pepe", mentor, ministryType, 2538,"blahBlah");
                AddMinistry("Calle 43 #23 32", "Poblado", "pepe", mentor, ministryType, 2538, "blahBlah");
                await _context.SaveChangesAsync();
            }
        }
        private async Task CheckMentorsAsync()
        {
            if (!_context.Mentors.Any())
            {
                AddMentor("8989898", "Juan", "Zuluaga", "234 3232", "310 322 3221", "Calle Luna Calle Sol");
                AddMentor("7655544", "Jose", "Cardona", "343 3226", "300 322 3221", "Calle 77 #22 21");
                AddMentor("6565555", "Maria", "López", "450 4332", "350 322 3221", "Carrera 56 #22 21");
                await _context.SaveChangesAsync();
            }
        }
        private void AddMentor(
            string document,
            string firstName,
            string lastName,
            string fixedPhone,
            string cellPhone,
            string address)
        {
            _context.Mentors.Add(new Mentor
            {
                Address = address,
                CellPhone = cellPhone,
                Document = document,
                FirstName = firstName,
                FixedPhone = fixedPhone,
                LastName = lastName
            });
        }

        private void AddMinistry(
            string location,
            string leader,
            string subLeader,
            Mentor mentor,
            MinistryType ministryType,
            decimal fund,
            string biblicalWord)
        {
            _context.Ministries.Add(new Ministry
            {
                Location = location,
                Leader = leader,
                SubLeader = subLeader,
                Mentor = mentor,
                MinistryType= ministryType,
                BiblicalWord = biblicalWord,
                IsAvailable = true,
                Fund = fund
            });
        }
    }


}
