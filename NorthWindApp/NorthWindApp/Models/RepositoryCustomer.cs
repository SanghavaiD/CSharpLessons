using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace NorthWindApp.Models
{
    public class RepositoryCustomer
    {
        private readonly NorthwindContext _context;
        public int SelectedId { get; set; }
        public List<SelectListItem> CustomerSelectView { get; set; }
        public RepositoryCustomer() { }
        public RepositoryCustomer(NorthwindContext context)
        {
            _context = context;
        }
        public Customer FindCustomerById(string id)
        {
            var customer = _context.Customers.Find(id);
            return customer;
        }
        public List<string> GetAllCustomerId()
        {
            List<string> customerIds = new List<string>();
            foreach (var customer in _context.Customers)
            {
                customerIds.Add(customer.CustomerId);
            }
            return customerIds;
        }
        public List<Order> FindCustomerdetailbyOrders(string id)
        {
            List<Customer> customers = _context.Customers.Include(o => o.Orders).ToList();
            Customer customer = customers.FirstOrDefault(x => x.CustomerId == id);
            return customer.Orders.ToList();
        }
    }
}
