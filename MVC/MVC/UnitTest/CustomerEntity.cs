using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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