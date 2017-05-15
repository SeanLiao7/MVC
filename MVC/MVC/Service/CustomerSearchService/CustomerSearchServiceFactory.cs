using MVC.Models;

namespace MVC.Service
{
    public static class CustomerSearchServiceFactory
    {
        public static IGenericeSearchService<Customers> CreateSearchService( SearchModel searchModel = null )
        {
            if ( searchModel == null )
                return new CompanyNameSearchAllService( );

            var isFuzzyComparison = searchModel.IsFuzzyComparison;
            var searchTarget = searchModel.SearchTarget;

            if ( string.IsNullOrWhiteSpace( searchTarget ) )
                return new CompanyNameSearchAllService( );
            else if ( isFuzzyComparison )
                return new CompanyNameFuzzySearchService( searchModel );
            else
                return new CompanyNameFullComparisonSearchService( searchModel );
        }
    }
}