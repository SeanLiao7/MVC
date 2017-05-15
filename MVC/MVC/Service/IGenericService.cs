﻿using System;
using System.Collections.Generic;

namespace MVC.Service
{
    internal interface IGenericService<T> : IDisposable
    {
        void Create( T instance );

        void Delete( string id );

        T GetByID( string id );

        IEnumerable<T> GetCustomers( IGenericeSearchService<T> searchService );

        void Update( T instance );
    }
}