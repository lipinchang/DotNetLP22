using PassingInputAssignmentApp.Models;

namespace PassingInputAssignmentApp.Services
{
    public class ProductService
    {
        private readonly IRepo<int, Product> _repo;
        public ProductService(IRepo<int, Product> repo)
        {
            _repo = repo;
        }
        public Product ProductCheck(Product product)
        {
            var myProduct = _repo.Get(product.Id);
            if (myProduct != null)
            {
                if(product.Id == myProduct.Id)
                {
                    return product;
                }
            }
            return null;
        }
    }
}
