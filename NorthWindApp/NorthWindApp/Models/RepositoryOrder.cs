using Microsoft.EntityFrameworkCore;
using NorthWindApp.Models;


namespace NorthWindApp.Models
{
    public class RepositoyOrder
    {
        public NorthwindContext _context;
        public RepositoyOrder(NorthwindContext context)
        {
            _context = context;
        }
        public List<Order> GetOrders()
        {
            return _context.Orders.ToList();
        }
        public List<int> GetAllOrder()
        {
            return (from o in  _context.OrderDetails select o.OrderId).ToList();
        }
        public Order PutOrder(int id)
        {
            
            Order order = _context.Orders.Find(id);
            return order;
        }
        public List<OrderDetail> FindOrderDetailByOrderiD(int id)
        {
            //Order order=_context.Orders.Find(id);
            //return order.OrderDetails.ToList();
            List<Order> orderswithOrderDetails = _context.Orders.Include(d => d.OrderDetails).ToList();
            Order order = orderswithOrderDetails.FirstOrDefault(x => x.OrderId == id);
            return order.OrderDetails.ToList();
        }
        public Order FindOrderById(int id)
        {
            Order order = _context.Orders.Find(id);
            return order;
        }
    }
}