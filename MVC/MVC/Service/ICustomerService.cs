using System;
using System.Linq;

namespace MVC.Service
{
    internal interface ICustomerService : IDisposable
    {
        void Create( Customers instance );

        void Delete( string customerID );

        Customers GetByID( string customerID );

        IQueryable<Customers> GetCustomers( );

        void Update( Customers instance );
    }
}