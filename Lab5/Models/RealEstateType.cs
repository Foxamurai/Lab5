﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class RealEstateType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<RealEstateObject> RealEstateObjects {get;set;}
    }
}
