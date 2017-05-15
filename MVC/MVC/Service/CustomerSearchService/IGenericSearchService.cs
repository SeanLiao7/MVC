using System.Linq;
using MVC.UnitTest;

namespace MVC.Service
{
    public interface IGenericeSearchService<T>
    {
        IQueryable<T> Search( IDbContext<T> db );
    }
}