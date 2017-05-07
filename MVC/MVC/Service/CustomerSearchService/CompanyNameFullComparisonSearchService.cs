using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Service
{
    public class CompanyNameFullComparisonSearchService : IGenericeSearchService<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );
        private SearchModel _searchModel;

        public CompanyNameFullComparisonSearchService( SearchModel searchModel )
        {
            _searchModel = searchModel;
        }

        private CompanyNameFullComparisonSearchService( )
        {
        }

        public IQueryable<Customers> Search( )
        {
            return from customer in _db.Customers
                   where customer.CompanyName == _searchModel.SearchTarget
                   select customer;
        }
    }
}