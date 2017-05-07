using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class SearchModel
    {
        public bool IsFuzzyComparison { get; set; }

        public string SearchTarget { get; set; }
    }
}