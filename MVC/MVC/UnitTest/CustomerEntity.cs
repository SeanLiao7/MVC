using System.Linq;

namespace MVC.UnitTest
{
    public class CustomerEntity : IDbContext<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );

        public IQueryable<Customers> DBContext
        {
            get
            {
                return _db.Customers;
            }
        }
    }
}