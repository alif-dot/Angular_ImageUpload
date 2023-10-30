using UploadImage.Models.Domain;
using UploadImage.Repository.Abstract;

namespace UploadImage.Repository.Implementation
{
    public class ProductRepostory : IProductRepository
    {
        private readonly DatabaseContext _context;
        public ProductRepostory(DatabaseContext context)
        {
            _context = context;
        }
        public bool Add(Product model)
        {
            try
            {
                _context.Product.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();
        }
    }
}
