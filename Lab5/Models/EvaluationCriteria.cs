﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class EvaluationCriteria
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}