using EntityFrameworkTest.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTest.Repository
{
    public class ProductRepository
    {
        private readonly DbContext _db;

        public ProductRepository()
        {
            _db = new DbContext();
        }   

        public List<_1Product> GetAllProducts()
        {
            return _db._1Products.ToList();
        }

        public _1Product GetProductById(int id)
        {
            return _db._1Products.Find(id);
        }

        public _1Product AddProduct(_1Product product)
        {
            _db._1Products.Add(product);
            _db.SaveChanges();
            return product;
        }

        public _1Product UpdateProduct(_1Product product)
        {
            _db._1Products.Update(product);
            _db.SaveChanges();
            return product;
        }

        public _1Product DeleteProduct(int id)
        {
            var product = _db._1Products.Find(id);
            if (product != null)
            {
                _db._1Products.Remove(product);
                _db.SaveChanges();
            }
            return product;
        }

    }
}
