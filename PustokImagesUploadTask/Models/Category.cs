using PustokImagesUploadTask.Base;

namespace PustokImagesUploadTask.Models
{
    public class Category : BaseEntity
    {
        public List<Book>? Books { get; set; }
    }
}
