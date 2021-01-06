using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductsApi.Models;

namespace Repositories
{
    public class ProducRepository
    {
        private readonly List<Product> _products;
        public ProducRepository()
        {
            //_products = new[] { new Product { Id = 1, Name = "Pants" }, new Product { Id = 2, Name = "Socks" } };
            _products = new List<Product>(new[] { new Product { Id = 1, Name = "Pants" }, new Product { Id = 2, Name = "Socks" } });
        }
        public Product[] Get()
        {
            return _products.ToArray();
        }
        public Product Add(Product value)
        {
            _products.Add(value);
            value.Id = _products.Count;
            return value;
        }

        public void Delete(int id)
        {
            var match = _products.FirstOrDefault(m => m.Id == id);

            if (match != null)
            {
                _products.Remove(match);
            }
        }

        public object Get(int id)
        {
            var match = _products.FirstOrDefault(m => m.Id == id);
            return match;
        }
    }
}
