using EntityFrameworkTest;
using Microsoft.EntityFrameworkCore;

namespace EntityTest
{
    public class Program
    {

        static void Main(string[] args)
        {
            var dbWorker = new ProductService();
            dbWorker.DisplayAllProducts();
        }
    }
}
