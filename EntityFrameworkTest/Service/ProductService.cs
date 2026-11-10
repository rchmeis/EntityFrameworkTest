using EntityFrameworkTest.Models;
using EntityFrameworkTest.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkTest
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;
        public ProductService()
        {
            _productRepository = new ProductRepository();
        }

        public _1Product AddProduct(_1Product product)
        {
            return _productRepository.AddProduct(product);
        }

        public _1Product UpdateProduct(_1Product product)
        {
            _productRepository.UpdateProduct(product);
            return product;
        }

        public _1Product DeleteProduct(int id)
        {
            return _productRepository.DeleteProduct(id);
        }

        public _1Product getProductById(int id)
        {
            var product = _productRepository.GetProductById(id);
            if (product != null)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            }
            else
            {
                Console.WriteLine($"Product with ID {id} not found.");
            }
            return product;
        }

        public List<_1Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public void DisplayAllProducts()
        {
            var products = GetAllProducts();
            foreach(var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Price: {product.Price}");
            };


        }
    }
}
