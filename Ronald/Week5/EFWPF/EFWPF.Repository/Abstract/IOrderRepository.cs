using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWPF.Data;

namespace EFWPF.Repository.Abstract
{
    public interface IOrderRepository
    {
        ObservableCollection<Order> GetOrders();
        ObservableCollection<Order> GetOrdersByProduct();

        void AddOrder(Order order);
    }
}
