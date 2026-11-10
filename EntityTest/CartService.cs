using EntityFrameworkTest;
using EntityFrameworkTest.Models;
using EntityFrameworkTest.Repository;
using System;
using System.Collections.Generic;
using System.Security.Permissions;
using System.Text;

namespace EntityTest
{
    public class CartService
    {
        private readonly ProductService _productService;
        private readonly CartRepository _cartRepository;

        public CartService()
        {
            _productService = new ProductService();
            _cartRepository = new CartRepository();
        }

        public _1Cart GetById(int id)
        {
            return _cartRepository.GetCartById(id);
        }

        public _1Cart AddCart(_1Cart cart)
        {
            return _cartRepository.AddCart(cart);
        }

        public _1Cart UpdateCart(_1Cart cart)
        {
            return _cartRepository.UpdateCart(cart);
        }

        public _1Cart DeleteCart(int id)
        {
            return _cartRepository.DeleteCart(id);
        }
        
        public List<_1Cart> GetAllCarts()
        {
            return _cartRepository.GetAllCarts();
        }
    }
}
