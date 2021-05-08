using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    class Realtor
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string ContactPhone { get; set; }

        public List<Sale> Sales { get; set; }

        public string getFullName()
        {
            return $"{Surname} {Name} {Patronymic}";
        }
    }
}
