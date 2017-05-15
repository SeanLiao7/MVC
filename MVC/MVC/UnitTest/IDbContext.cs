using System.Linq;

namespace MVC.UnitTest
{
    public interface IDbContext<T>
    {
        IQueryable<T> DBContext { get; }
    }
}