using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DbContext = EntityFrameworkTest.Models.DbContext;

namespace EntityFrameworkTest.Repository
{
    public class CartRepository
    {
        private readonly DbContext _db;

        public CartRepository()
        {
            _db = new DbContext();
        }


        //NOTE!! 
        //When fetching data (read methods), EF Core does not load related tables by default!!!     
        //To load related data, you need to use the Include method to specify which related entities to load.

        public List<_1Cart> GetAllCarts()
        {           
            return _db._1Carts.Include(c => c._1CartProducts).ToList();
        }

        public _1Cart GetCartById(int id)
        {
            return _db._1Carts.Include(c => c._1CartProducts).FirstOrDefault(c => c.Id == id);
        }


        //When adding a new cart, EF Core automatically tracks everything attached to that cart object.
        public _1Cart AddCart(_1Cart cart)
        {
            _db._1Carts.Add(cart);
            _db.SaveChanges();
            return cart;
        }

        public _1Cart UpdateCart(_1Cart updatedCart)
        {
            _1Cart existingCart=GetAllCarts().FirstOrDefault(c=>c.Id == updatedCart.Id);  

            if (existingCart != null)
            {
                // Automatically copy ALL scalar properties (UserId, AnonymousId, etc.) 
                // from your passed object to the tracked database object in one line!
                _db.Entry(existingCart).CurrentValues.SetValues(updatedCart);

                // Clear and replace the product list (so removed items get deleted from the database)
                existingCart._1CartProducts.Clear();

                foreach (var product in updatedCart._1CartProducts)
                {
                    existingCart._1CartProducts.Add(product);
                }

                // Save everything to the database
                _db.SaveChanges();
            }
            return updatedCart;
        }

        public _1Cart DeleteCart(int id)
        {
            var cart = _db._1Carts.Find(id);
            if (cart != null)
            {
                _db._1Carts.Remove(cart);
                _db.SaveChanges();
            }
            return cart;
        }
    }
}