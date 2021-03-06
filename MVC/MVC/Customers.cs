//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors" )]
        public Customers( )
        {
            this.Orders = new HashSet<Orders>( );
            this.CustomerDemographics = new HashSet<CustomerDemographics>( );
        }
        [Required]
        [StringLength( 5, ErrorMessage = "CustomerID length must be 5", MinimumLength = 5 )]
        public string CustomerID { get; set; }
        [Required]
        [StringLength( 40, ErrorMessage = "CompanyName length must not be greater than 40" )]
        public string CompanyName { get; set; }
        [StringLength( 30, ErrorMessage = "ContactName length must not be greater than 30" )]
        public string ContactName { get; set; }
        [StringLength( 30, ErrorMessage = "ContactTitle length must not be greater than 30" )]
        public string ContactTitle { get; set; }
        [StringLength( 60, ErrorMessage = "Address length must not be greater than 60" )]
        public string Address { get; set; }
        [StringLength( 15, ErrorMessage = "City length must not be greater than 15" )]
        public string City { get; set; }
        public string Region { get; set; }
        [StringLength( 10, ErrorMessage = "PostalCode length must not be greater than 10" )]
        public string PostalCode { get; set; }
        [StringLength( 15, ErrorMessage = "Country length must not be greater than 15" )]
        public string Country { get; set; }
        [StringLength( 24, ErrorMessage = "Phone length must not be greater than 24" )]
        public string Phone { get; set; }
        [StringLength( 24, ErrorMessage = "Fax length must not be greater than 24" )]
        public string Fax { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly" )]
        public virtual ICollection<CustomerDemographics> CustomerDemographics { get; set; }
    }
}
