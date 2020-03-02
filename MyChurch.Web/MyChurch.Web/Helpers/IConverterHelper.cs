using MyChurch.Web.Data.Entities;
using MyChurch.Web.Models;
using System.Threading.Tasks;

namespace MyChurch.Web.Helpers
{
    public interface IConverterHelper
    {
        Task<Ministry> ToMinistryAsync(MinistryViewModel model, string path, bool isNew);
        MinistryViewModel ToMinistryViewModel(Ministry ministry);
    }
}