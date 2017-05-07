using System;
using System.Linq;

namespace MVC.Service
{
    internal interface IGenericService<T> : IDisposable
    {
        void Create( T instance );

        void Delete( string customerID );

        T GetByID( string customerID );

        IQueryable<T> GetCustomers( IGenericeSearchService<T> searchService );

        void Update( T instance );
    }
}