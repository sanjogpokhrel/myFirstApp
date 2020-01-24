using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace myFirstApp.Core
{
    public class Restaurant 
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public String Name { get; set; }

        [Required, StringLength(250)]
        public String Location { get; set; }
 
        public CuisineType Cuisine { get; set; }

    }
}
