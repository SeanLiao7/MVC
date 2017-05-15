using System.Collections.Generic;
using System.Linq;
using Autofac;
using MVC.Models;
using MVC.UnitTest;
using NUnit.Framework;

namespace MVC.Service.Tests
{
    [TestFixture( )]
    public class CompanyNameFullComparisonSearchServiceTests
    {
        private List<string> _expectedResult;
        private IContainer _iContainer;

        [Test( )]
        public void CompanyNameFullComparisonSearchTest( )
        {
            var searchService = CustomerSearchServiceFactory.CreateSearchService( _iContainer.Resolve<SearchModel>( ) );
            var searchResult = searchService.Search( _iContainer.Resolve<IDbContext<Customers>>( ) );
            var expectedCount = 1;
            var results = searchResult.ToList( );

            Assert.AreEqual(
                expectedCount,
                results.Count,
                $"{nameof( expectedCount )} is not equals to {nameof( results )}." );
            Assert.That(
                results.TrueForAll( c =>
                _expectedResult.Contains( c.CompanyName ) ),
                $"{nameof( results )} doesn't contain all of {nameof( _expectedResult )}." );
        }

        [SetUp]
        public void SetUp( )
        {
            var builder = new ContainerBuilder( );
            builder.Register( c => new MockCustomerEntity( ) ).AsImplementedInterfaces( );
            builder.RegisterInstance( new SearchModel
            {
                SearchTarget = "cebo",
                IsFuzzyComparison = false
            } );

            _iContainer = builder.Build( );

            _expectedResult = new List<string>
            {
                "cebo"
            };
        }

        [TearDown( )]
        public void TearDown( )
        {
            _iContainer.Dispose( );
        }
    }
}