using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.UnitTest
{
    public interface IDbContext<T>
    {
        IQueryable<T> DBContext { get; }
    }
}