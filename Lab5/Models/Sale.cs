using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class Sale
    {
        public int Id { get; set; }

        public int RealEstateObjectId { get; set; }
        public RealEstateObject RealEstateObject { get; set; }

        public DateTime SaleDate { get; set; }   
        
        public int RealtorId { get; set; }
        public Realtor Realtor { get; set; }

        public double Price { get; set; }
    }
}
