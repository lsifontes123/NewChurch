using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyChurch.Web.Helpers
{
    public interface IImageHelper
    {
        Task<string> UploadImageAsync(IFormFile imageFile);
    }
}