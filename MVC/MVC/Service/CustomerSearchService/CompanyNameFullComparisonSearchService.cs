using System;
using System.Linq;
using MVC.Models;
using MVC.UnitTest;

namespace MVC.Service
{
    public class CompanyNameFullComparisonSearchService : IGenericeSearchService<Customers>
    {
        private SearchModel _searchModel;

        public CompanyNameFullComparisonSearchService( SearchModel searchModel )
        {
            if ( searchModel == null )
                throw new ArgumentNullException( $"{nameof( searchModel )} is null !" );

            _searchModel = searchModel;
        }

        private CompanyNameFullComparisonSearchService( )
        {
        }

        public IQueryable<Customers> Search( IDbContext<Customers> db )
        {
            return from customer in db.DBContext
                   where customer.CompanyName == _searchModel.SearchTarget
                   select customer;
        }
    }
}