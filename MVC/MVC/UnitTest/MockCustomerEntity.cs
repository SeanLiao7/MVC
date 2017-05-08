using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public List<Customers> MockDBContext { get; set; } = new List<Customers>( );

        public MockCustomerEntity( params Customers[ ] customers )
        {
            foreach ( var customer in customers )
                MockDBContext.Add( customer );
        }

        private MockCustomerEntity( )
        {
        }
    }
}