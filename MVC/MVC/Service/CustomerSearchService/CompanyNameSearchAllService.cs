using System.Linq;
using MVC.UnitTest;

namespace MVC.Service
{
    public class CompanyNameSearchAllService : IGenericeSearchService<Customers>
    {
        public IQueryable<Customers> Search( IDbContext<Customers> db )
        {
            return db.DBContext;
        }
    }
}