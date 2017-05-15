using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MVC.UnitTest;

namespace MVC.Service
{
    public class CustomerService : IGenericService<Customers>
    {
        private NORTHWNDEntities _db = new NORTHWNDEntities( );

        public void Create( Customers instance )
        {
            _db.Customers.Add( instance );
            _db.Entry( instance ).State = EntityState.Added;
            SaveDB( );
        }

        public void Delete( string customerID )
        {
            var customers = GetByID( customerID );
            customers.Orders.ToList( ).ForEach( c => customers.Orders.Remove( c ) );
            _db.Customers.Remove( customers );
            _db.Entry( customers ).State = EntityState.Deleted;
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

        public IEnumerable<Customers> GetCustomers( IGenericeSearchService<Customers> customerSearchService )
        {
            return customerSearchService.Search( new CustomerEntity( ) );
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