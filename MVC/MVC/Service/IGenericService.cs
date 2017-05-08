using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Service
{
    internal interface IGenericService<T> : IDisposable
    {
        void Create( T instance );

        void Delete( string customerID );

        T GetByID( string customerID );

        IEnumerable<T> GetCustomers( IGenericeSearchService<T> searchService );

        void Update( T instance );
    }
}