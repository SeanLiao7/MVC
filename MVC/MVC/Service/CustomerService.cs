using System;
using System.Data.Entity;
using System.Linq;

namespace MVC.Service
{
    public class CustomerService : IGenericService<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );

        public void Create( Customers instance )
        {
            _db.Customers.Add( instance );
            SaveDB( );
        }

        public void Delete( string customerID )
        {
            var customers = GetByID( customerID );
            _db.Customers.Remove( customers );
            SaveDB( );
        }

        public void Dispose( )
        {
            _db.Dispose( );
        }

        public Customers GetByID( string customerID )
        {
            return _db.Customers.Find( customerID );
        }

        public IQueryable<Customers> GetCustomers( IGenericeSearchService<Customers> customerSearchService )
        {
            return customerSearchService.Search( );
        }

        public void Update( Customers instance )
        {
            _db.Entry( instance ).State = EntityState.Modified;
            SaveDB( );
        }

        private void SaveDB( )
        {
            _db.SaveChanges( );
        }
    }
}