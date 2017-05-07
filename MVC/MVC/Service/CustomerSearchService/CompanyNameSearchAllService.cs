using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Service
{
    public class CompanyNameSearchAllService : IGenericeSearchService<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );
        private SearchModel _searchModel;

        public CompanyNameSearchAllService( SearchModel searchModel )
        {
            _searchModel = searchModel;
        }

        private CompanyNameSearchAllService( )
        {
        }

        public IQueryable<Customers> Search( )
        {
            return _db.Customers;
        }
    }
}