using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVC.Extensions;

namespace MVC.UnitTest
{
    public class MockCustomerEntity : IDbContext<Customers>
    {
        public IQueryable<Customers> DBContext
        {
            get
            {
                return MockDBContext.AsQueryable( );
            }
        }

        public List<Customers> MockDBContext { get; } = new List<Customers>( );

        public MockCustomerEntity( )
        {
            MockDBContext.Add(
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
                    } );
        }
    }
}