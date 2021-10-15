using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM02Examan6925.Models
{
    public class Ubicacion
    {
        public int id { get; set; }
        public Decimal latitud { get; set; }

        [MaxLength(100)]
        public Decimal longitud { get; set; }

        [MaxLength(70)]
        public string descripcionubicacion { get; set; }

        [MaxLength(100)]
        public string descripcioncorta { get; set; }
    }
}
