using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using AutoMapper;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult About( )
        {
            ViewBag.Message = "Your application description page.";

            return View( );
        }

        public ActionResult Contact( )
        {
            ViewBag.Message = "Your contact page.";

            return View( );
        }

        public ActionResult Index( )
        {
            using ( var sw = new StreamWriter( @"D:\Test.csv", true, Encoding.UTF8 ) )
            using ( var writer = new CsvHelper.CsvWriter( sw ) )
            {
                var customers = new NORTHWNDEntities( ).Customers.OrderBy( c => c.CustomerID ).ToList( );

                Mapper.Initialize( x => x.CreateMap<Customers, Customers>( ) );

                var result = Mapper.Map<List<Customers>>( customers );

                writer.WriteRecords( result );
            }

            return View( );
        }
    }
}