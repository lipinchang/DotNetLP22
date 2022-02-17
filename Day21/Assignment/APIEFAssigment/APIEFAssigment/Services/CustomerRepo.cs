using APIEFAssigment.Services;

namespace APIEFAssigment.Models
{
    public class CustomerRepo : IRepo<int, Customer>
    {
        private readonly OfficeContext _context;
        public CustomerRepo(OfficeContext context)
        {
            _context = context;
        }
        public CustomerRepo()
        {

        }
        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Customer GetT(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer Delete(int key)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == key);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
            return customer;

        }

        public Customer Update(Customer item)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == item.Id);
            if (customer != null)
            {
                customer.Name = item.Name;
                customer.Age = item.Age;
               
                _context.Customers.Update(customer);
                _context.SaveChanges();
               
            }
            return customer;
        }
    }
}
