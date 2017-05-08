using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Models;
using MVC.UnitTest;

namespace MVC.Service
{
    public class CompanyNameFuzzySearchService : IGenericeSearchService<Customers>
    {
        private SearchModel _searchModel;

        public CompanyNameFuzzySearchService( SearchModel searchModel )
        {
            if ( searchModel == null )
                throw new ArgumentNullException( $"{nameof( searchModel )} is null !" );

            _searchModel = searchModel;
        }

        private CompanyNameFuzzySearchService( )
        {
        }

        public IQueryable<Customers> Search( IDbContext<Customers> db )
        {
            return from customer in db.DBContext
                   where customer.CompanyName.Contains( _searchModel.SearchTarget )
                   select customer;
        }
    }
}