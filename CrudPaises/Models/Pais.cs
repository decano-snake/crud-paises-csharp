using System;
using System.Collections.Generic;
using System.Text;

namespace CrudPaises.Models
{
    public class Pais
    {
        public int Codigo_pais { get; set; }
        public string Nome_pais { get; set; } = "";
        public long Populacao { get; set; }
        public double Area_total { get; set; }
    }
}
