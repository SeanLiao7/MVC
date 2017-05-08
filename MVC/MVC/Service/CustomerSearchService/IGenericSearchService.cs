using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.UnitTest;

namespace MVC.Service
{
    public interface IGenericeSearchService<T>
    {
        IQueryable<T> Search( IDbContext<T> db );
    }
}