using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class RealEstateObject
    {
        public int Id { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

        public string Address { get; set; }

        public int Floor { get; set; }

        public int RoomsNumber { get; set; }

        public int RealEstateTypeId { get; set; }
        public RealEstateType RealEstateType { get; set; }

        public bool Status { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }

        public int BuldingMaterialId { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }

        public double Area { get; set; }

        public DateTime AdDate { get; set; }

        public List<Evaluation> Evaluations { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
