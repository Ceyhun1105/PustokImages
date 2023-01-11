using PustokImagesUploadTask.Base;

namespace PustokImagesUploadTask.Models
{
    public class BookImage : BaseEntity
    {

        public int BookId { get; set; }
        public bool? IsPoster { get; set; }
        public Book? Book { get; set; }
    }
}
