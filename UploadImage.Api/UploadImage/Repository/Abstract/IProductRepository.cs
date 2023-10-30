using UploadImage.Models.Domain;

namespace UploadImage.Repository.Abstract
{
    public interface IProductRepository
    {
        bool Add(Product model);
        IEnumerable<Product> GetAll();
    }
}
