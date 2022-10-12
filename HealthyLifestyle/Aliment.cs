using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Aliment: IComparable
    {
       [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public double carbohydrates { get; set; }
        public double protein { get; set; }
        public double fat { get; set; }
        public double calories { get; set; }
        public double sugar { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Aliment aliment = obj as Aliment;
            if (aliment != null)
                return this.sugar.CompareTo(aliment.sugar);
            else
                throw new ArgumentException("Nu se poate sorta");
        }
    }
}
