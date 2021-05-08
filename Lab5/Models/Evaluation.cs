using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class Evaluation
    {
        public int Id { get; set; }
        
        public int RealEstateObjectId { get; set; }
        public RealEstateObject RealEstateObject { get; set; }

        public DateTime EvaluationDate { get; set; }
        
        public int EvaluationCriteriaId { get; set; }
        public EvaluationCriteria EvaluationCriteria { get; set; }

        public int EvaluationResult { get; set; }
    }
}
