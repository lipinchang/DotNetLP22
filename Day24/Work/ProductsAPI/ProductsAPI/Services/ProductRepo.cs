using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        static List<Product> _products = new List<Product>()
        {
            new Product(){Id = 1, Name ="Pencil",Price=5,Quantity=20},
            new Product(){Id = 2, Name ="Scale",Price=15,Quantity=5},
            new Product(){Id = 3, Name ="Pen",Price=10,Quantity=10}
        };
        public async Task<Product> Add(Product item)
        {
            var product = await Get(item.Id);
            if (product == null)
                _products.Add(item);
            else
                product.Quantity += item.Quantity;
            return item;
        }

        public async Task<Product> Delete(int key)
        {
            var product = await Get(key);
            if (product != null)
            {
                _products.Remove(product);
            }
            return null;
        }

        public async Task<Product> Get(int key)
        {
            var product = _products.SingleOrDefault(x => x.Id == key);
            return product;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return _products;
        }

        public async Task<Product> Update(Product item)
        {
            var product = await Get(item.Id);
            if (product != null)
            {
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                return product;
            }
            return null;
        }
    }
}
