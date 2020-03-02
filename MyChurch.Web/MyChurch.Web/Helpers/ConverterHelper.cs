using MyChurch.Web.Data;
using MyChurch.Web.Data.Entities;
using MyChurch.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _Context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext Context,
            ICombosHelper combosHelper)
        {
            _Context = Context;
            _combosHelper = combosHelper;
        }

        public async Task<Ministry> ToMinistryAsync(MinistryViewModel model, string path, bool isNew)
        {
            var ministry = new Ministry
            {
              //  ChurchEvents = model.ChurchEvents,
                FollowUpHistories = model.FollowUpHistories,
                Id = isNew ? 0 : model.Id,
                ImageUrl = path,
                Name = model.Name,
                Admin = await _Context.Admins.FindAsync(model.AdminId),
                MinistryType = await _Context.MinistryTypes.FindAsync(model.MinistryTypeId)

            };
            if(model.Id != 0)
            {
                ministry.Id = model.Id;
            }
            return ministry;
           
        }
        public MinistryViewModel ToMinistryViewModel(Ministry ministry)
        {
            return new MinistryViewModel
            {
               // ChurchEvents = ministry.ChurchEvents,
                FollowUpHistories = ministry.FollowUpHistories,
                Id = ministry.Id,
                ImageUrl = ministry.ImageUrl,
                Name = ministry.Name,
                Admin = ministry.Admin,
                MinistryType = ministry.MinistryType,
                AdminId = ministry.Admin.Id,
                MinistryTypeId =ministry.MinistryType.Id,
                MinistryTypes = _combosHelper.GetComboMinistryTypes()
            };
        }

       
    }

}
