using NUnit.Framework;
using MVC.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC.Models;
using MVC.UnitTest;

namespace MVC.Service.Tests
{
    [TestFixture( )]
    public class CompanyNameFuzzySearchServiceTests
    {
        private List<string> _expectedResult;
        private SearchModel _searchModel = default( SearchModel );
        private IDbContext<Customers> _target;

        [Test( )]
        public void CompanyNameFuzzySearchTest( )
        {
            var searchService = CustomerSearchServiceFactory.CreateSearchService( _searchModel );
            var searchResult = searchService.Search( _target );
            var expectedCount = 2;
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
            _target = new MockCustomerEntity
                (
                    new Customers
                    {
                        CustomerID = "12345",
                        CompanyName = "Google",
                        Country = "USA",
                    },
                    new Customers
                    {
                        CustomerID = "54321",
                        CompanyName = "Facebook",
                        Country = "Canada",
                    },
                    new Customers
                    {
                        CustomerID = "99867",
                        CompanyName = "Microsoft",
                        Country = "China",
                    },
                    new Customers
                    {
                        CustomerID = "98765",
                        CompanyName = "cebo",
                        Country = "India",
                    }
                );

            _expectedResult = new List<string>
            {
                "Facebook",
                "cebo"
            };

            _searchModel = new SearchModel
            {
                SearchTarget = "eb",
                IsFuzzyComparison = true
            };
        }
    }
}