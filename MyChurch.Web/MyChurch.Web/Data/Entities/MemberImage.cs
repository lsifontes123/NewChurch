using System.ComponentModel.DataAnnotations;

namespace MyChurch.Web.Data.Entities
{
    public class MemberImage
    {
        public int Id { get; set; }

        [Display(Name = "Image")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string ImageUrl { get; set; }

        public Mentor Mentor{ get; set; }

        public Disciple Disciple { get; set; }

        // TODO: Change the path when publish
        public string ImageFullPath => $"https://TBD.azurewebsites.net{ImageUrl.Substring(1)}";
    }
}
