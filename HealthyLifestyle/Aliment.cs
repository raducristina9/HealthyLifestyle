using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Aliment
    {
       [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public double carbohydrates { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double calories { get; set; }
        public double sugar { get; set; }

    }
}
