using NuGet.Protocol.Core.Types;
using PustokImagesUploadTask.Base;

namespace PustokImagesUploadTask.Models
{
    public class Author : BaseEntity
    {
        public List<Book>? Books { get; set; }
    }
}
