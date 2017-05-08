using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
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