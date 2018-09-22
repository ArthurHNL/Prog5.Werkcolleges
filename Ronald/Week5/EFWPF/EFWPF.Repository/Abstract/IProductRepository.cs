using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWPF.Data;

namespace EFWPF.Repository.Abstract
{
    public interface IProductRepository
    {
        ObservableCollection<Product> GetProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}
