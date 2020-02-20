using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyChurch.Web.Data.Entities
{
    public class MinistryImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string ImageUrl { get; set; }

        public ICollection<Ministry> Ministries { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
