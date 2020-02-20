using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyChurch.Web.Data.Entities
{
    public class Ministry
    {
        public int Id { get; set; }


        [Display(Name = "Location")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Location { get; set; }

        [Display(Name = "Funds")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Fund { get; set; }

        [Display(Name = "Leader")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Leader { get; set; }

        [Display(Name = "Sub Leader")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string SubLeader { get; set; }

        [Display(Name = "Biblical Word")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public int BiblicalWord{ get; set; }
        [Display(Name = "Meet Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MeetStartDate { get; set; }

        [Display(Name = "Meet End Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime MeetEndDate { get; set; }


        [Display(Name = "Meet Start Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDateLocal => MeetStartDate.ToLocalTime();

        [Display(Name = "Meet End Date")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDateLocal => MeetEndDate.ToLocalTime();

        [Display(Name = "Is Available?")]
        public bool IsAvailable { get; set; }

        public string Remark { get; set; }

        public MinistryType MinistryType { get; set; }
        public Mentor Mentor { get; set; }

        public Disciple Disciple { get; set; }

        public MinistryImage MinistryImage { get; set; }

        public ICollection<ChurchEvent> ChurchEvents { get; set; }

    }
}
