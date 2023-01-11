using PustokImagesUploadTask.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PustokImagesUploadTask.Models
{
    public class Book : BaseEntity
    {
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public double SalePrice { get; set; }
        public double DiscountPrice { get; set; }
        public double CostPrice { get; set; }
        public bool IsAvalible { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsNew { get; set; }

        public Category? Category { get; set; }
        public Author? Author { get; set; }
        public List<BookImage>? BookImages { get; set; }
        [NotMapped]
        public List<IFormFile>? ImageFiles { get; set; }
        [NotMapped]
        public IFormFile? PosterImage { get; set; }
        [NotMapped]
        public IFormFile? HoverImage { get; set; }


    }
}
