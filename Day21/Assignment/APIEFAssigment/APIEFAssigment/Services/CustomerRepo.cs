﻿using APIEFAssigment.Services;

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

        public Customer Get(int id)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer;
        }

        public ICollection<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public bool Remove(int id)
        {
            Customer customer = Get(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return true;
        }

        public bool Update(Customer item)
        {
            Customer customer = _context.Customers.FirstOrDefault(x => x.Id == item.Id);
            if (customer != null)
            {
                customer.Name = item.Name;
                customer.Age = item.Age;
               
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
