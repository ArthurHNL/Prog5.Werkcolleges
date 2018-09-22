using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWPF.Data;
using EFWPF.Repository.Abstract;

namespace EFWPF.Repository
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> GetOrdersByProduct()
        {
            throw new NotImplementedException();
        }
    }
}
