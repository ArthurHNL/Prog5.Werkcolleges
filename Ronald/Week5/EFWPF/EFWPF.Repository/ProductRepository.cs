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
    public class ProductRepository : IProductRepository
    {
        private readonly EfWpfDbContext context;

        public ProductRepository()
        {
            this.context = new EfWpfDbContext();
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Product> GetProducts()
        {
            var products = new ObservableCollection<Product>(context.Product);
            return products;
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
