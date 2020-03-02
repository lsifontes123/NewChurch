using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyChurch.Web.Data;
using MyChurch.Web.Data.Entities;
using MyChurch.Web.Helpers;
using MyChurch.Web.Models;

namespace MyChurch.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminsController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly IConverterHelper _converterHelper;
        private readonly IImageHelper _imageHelper;

        public AdminsController(DataContext context,
            IUserHelper userHelper,
            ICombosHelper combosHelper,
            IConverterHelper converterHelper,
            IImageHelper imageHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _converterHelper = converterHelper;
            _imageHelper = imageHelper;
        }

        // GET: Admins
        public IActionResult Index()
        {
            return View(_context.Admins.Include(a => a.User).Include(a => a.Ministries));
        }

        // GET: Admins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .Include(a => a.User)
                .Include(a => a.Ministries)
                .ThenInclude(m => m.MinistryType)
                .Include(a => a.Ministries)
           //     .ThenInclude(m => m.ChurchEvents)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }
        public IActionResult Create()
        {
            return View();
        }
        // GET: Admins/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel view)
        {
            if (ModelState.IsValid)
            {
                var user = await AddUser(view);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already used.");
                    return View(view);
                }

                var admin = new Admin //TODO add more things to Admin. Increase responsibility like Church Events
                {
                    Ministries = new List<Ministry>(),
                    User = user,

                };

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(view);
        }

        private async Task<User> AddUser(AddUserViewModel view)
        {
            var user = new User
            {
                Address = view.Address,
                Document = view.Document,
                Email = view.Username,
                FirstName = view.FirstName,
                LastName = view.LastName,
                PhoneNumber = view.PhoneNumber,
                UserName = view.Username
            };

            var result = await _userHelper.AddUserAsync(user, view.Password);
            if (result != IdentityResult.Success)
            {
                return null;
            }

            var newUser = await _userHelper.GetUserByEmailAsync(view.Username);
            await _userHelper.AddUserToRoleAsync(newUser, "Admin");
            return newUser;
        }


        // GET: Admins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return View(admin);
        }

        // POST: Admins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Admin admin)
        {
            if (id != admin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(admin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdminExists(admin.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: Admins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins
                .FirstOrDefaultAsync(m => m.Id == id);
            if (admin == null)
            {
                return NotFound();
            }

            return View(admin);
        }

        // POST: Admins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            _context.Admins.Remove(admin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.Id == id);
        }      // GET: Admins/AddMinistry/5
        public async Task<IActionResult> AddMinistry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var admin = await _context.Admins.FindAsync(id.Value);
            if (admin == null)
            {
                return NotFound();
            }
            var model = new MinistryViewModel
            {
                AdminId = admin.Id,
                MinistryTypes = _combosHelper.GetComboMinistryTypes()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddMinistry(MinistryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);
                }
                var ministry = await _converterHelper.ToMinistryAsync(model, path, true);
                _context.Ministries.Add(ministry);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.AdminId}");
            }
            return View(model);
        }
        //Create Edit Ministry
        public async Task<IActionResult> EditMinistry(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ministry = await _context.Ministries
                .Include(m => m.Admin)
                .Include(m => m.MinistryType )
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ministry == null)
            {
                return NotFound();
            }
            
            return View(_converterHelper.ToMinistryViewModel(ministry));
        }
        [HttpPost]
        public async Task<IActionResult> EditMinistry(MinistryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = model.ImageUrl;
                if (model.ImageFile != null)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile);

                }
                var ministry = await _converterHelper.ToMinistryAsync(model, path, true);
                _context.Ministries.Update(ministry);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.AdminId}");

            }
            return View(model);
        }

    }
}
