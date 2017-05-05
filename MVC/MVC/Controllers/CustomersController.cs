﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC.Service;

namespace MVC.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerService _service = new CustomerService( );

        public CustomersController( )
        {
        }

        // GET: Customers/Create
        public ActionResult Create( )
        {
            return View( );
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( [Bind( Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax" )] Customers customers )
        {
            if ( customers != null && ModelState.IsValid )
            {
                _service.Create( customers );
                return RedirectToAction( "Index" );
            }

            return View( customers );
        }

        // GET: Customers/Delete/5
        public ActionResult Delete( string id )
        {
            if ( id == null )
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );

            var customers = _service.GetByID( id );

            if ( customers == null )
                return HttpNotFound( );

            return View( customers );
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName( "Delete" )]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed( string id )
        {
            _service.Delete( id );
            return RedirectToAction( "Index" );
        }

        // GET: Customers/Details/5
        public ActionResult Details( string id )
        {
            if ( id == null )
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );

            var customers = _service.GetByID( id );

            if ( customers == null )
                return HttpNotFound( );

            return View( customers );
        }

        // GET: Customers/Edit/5
        public ActionResult Edit( string id )
        {
            if ( id == null )
                return new HttpStatusCodeResult( HttpStatusCode.BadRequest );

            var customers = _service.GetByID( id );

            if ( customers == null )
                return HttpNotFound( );

            return View( customers );
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( [Bind( Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax" )] Customers customers )
        {
            if ( customers != null && ModelState.IsValid )
            {
                _service.Update( customers );
                return RedirectToAction( "Index" );
            }
            return View( customers );
        }

        // GET: Customers
        public ActionResult Index( )
        {
            return View( _service.GetCustomers( ) );
        }

        protected override void Dispose( bool disposing )
        {
            if ( disposing )
                _service.Dispose( );

            base.Dispose( disposing );
        }
    }
}