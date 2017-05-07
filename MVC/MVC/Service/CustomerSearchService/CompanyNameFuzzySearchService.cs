using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;

namespace MVC.Service
{
    public class CompanyNameFuzzySearchService : IGenericeSearchService<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );
        private SearchModel _searchModel;

        public CompanyNameFuzzySearchService( SearchModel searchModel )
        {
            _searchModel = searchModel;
        }

        private CompanyNameFuzzySearchService( )
        {
        }

        public IQueryable<Customers> Search( )
        {
            return from customer in _db.Customers
                   where customer.CompanyName.Contains( _searchModel.SearchTarget )
                   select customer;
        }
    }
}