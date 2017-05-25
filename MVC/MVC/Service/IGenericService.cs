using System;
using System.Collections.Generic;

namespace MVC.Service
{
    public interface IGenericService<T> : IDisposable
    {
        void Create( T instance );

        void Delete( string id );

        T GetByID( string id );

        IEnumerable<T> GetItems( IGenericeSearchService<T> searchService );

        void Update( T instance );
    }
}