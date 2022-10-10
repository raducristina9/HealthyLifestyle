﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyLifestyle
{
    public class Parc
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String denumire { get; set; }
        public double hectare { get; set; }
    }
}
