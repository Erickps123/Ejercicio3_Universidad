using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ej3Universidad.Models
{
    public class Universidades
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class DatosUniversidad
    {
        public int IDSelected { get; set; }
        private static List<Universidades> Universidad;
        public List<Universidades> Universidades
        {
            get
            {
                if (Universidad == null)
                {
                    Universidad = new List<Universidades>();
                }
                return Universidad;
            }
        }
    }
}
