using CustomerAssignmentApplication.Models;

namespace CustomerAssignmentApplication.Services
{
    public class CustomerDataEFRepo : IRepo<int, Customer>
    {
        private readonly CustomerDataContext _context;

        public CustomerDataEFRepo(CustomerDataContext context)
        {
            _context = context;
        }

        public bool Add(Customer t)
        {
            _context.Add(t);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int k)
        {
            _context.Remove(GetT(k));
            _context.SaveChanges();
            return true;
        }

        public ICollection<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public Customer GetT(int k)
        {
            return _context.Customers.FirstOrDefault(p => p.Id == k);
        }

        public bool Update(int k, Customer t)
        {
            var MyCustomer = _context.Customers.FirstOrDefault(p => p.Id == k);
            if (MyCustomer != null)
            {
                MyCustomer.Username = t.Username;
                MyCustomer.Email = t.Email;
                MyCustomer.Phone = t.Phone;
                MyCustomer.DOB = t.DOB;
                MyCustomer.CustomerName = t.CustomerName;
                MyCustomer.Age = t.Age;
                MyCustomer.Gender = t.Gender;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
