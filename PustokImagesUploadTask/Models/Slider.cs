using PustokImagesUploadTask.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokImagesUploadTask.Models
{
    public class Slider : BaseEntity
    {
        public string Name2 { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public string ButtonText { get; set; }
        public string RedirectUrl { get; set; }
        
        [NotMapped]
        public IFormFile? ImageFile { get; set; }


    }
}
