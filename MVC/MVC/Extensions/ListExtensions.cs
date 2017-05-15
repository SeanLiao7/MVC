using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Extensions
{
    public static class ListExtensions
    {
        public static void Add<T>( this List<T> list, params T[ ] elements )
        {
            if ( list == null )
                throw new ArgumentNullException( "List is null !" );

            if ( elements == null )
                return;

            foreach ( var element in elements )
                list.Add( element );
        }
    }
}