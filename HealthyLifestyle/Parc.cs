using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Parc
    {
        public String denumire { get; set; }
        public double hectare { get; set; }

        public string poza
        {
            get
            {
                return denumire.Replace(" ","").ToLower() + ".jpg";
            }
        }
    }
}
