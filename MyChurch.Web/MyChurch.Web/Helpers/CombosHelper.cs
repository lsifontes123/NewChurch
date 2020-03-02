using Microsoft.AspNetCore.Mvc.Rendering;
using MyChurch.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _Context;

        public CombosHelper(DataContext Context)
        {
            _Context = Context;
        }
        public IEnumerable<SelectListItem> GetComboMinistryTypes()
        { 
            var list = _Context.MinistryTypes.Select(mt => new SelectListItem
            {
                Text = mt.Name,
                Value = $"{mt.Id}"})
                .OrderBy(mt => mt.Text)
                .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Select a ministry type...]",
                Value = "0"
            });

            return list;
        }

       
    }
}
