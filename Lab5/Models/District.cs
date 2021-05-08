using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class District
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RealEstateObject> RealEstateObjects { get; set; }
    }
}
