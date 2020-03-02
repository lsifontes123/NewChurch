using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyChurch.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyChurch.Web.Models
{
    public class MinistryViewModel : Ministry
    {
            public int AdminId { get; set; }

            [Required(ErrorMessage = "The field {0} is mandatory.")]
            [Display(Name = "Ministry Type")]
            [Range(1, int.MaxValue, ErrorMessage = "You must select Ministry type.")]
            public int MinistryTypeId { get; set; }

            [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

            public IEnumerable<SelectListItem> MinistryTypes { get; set; }
        

    }
}
