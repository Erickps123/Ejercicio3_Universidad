using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ej3Universidad.Models
{
    public class Maestria
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
        public string DURACION { get; set; }
        public int ID_DOCENTE { get; set; }
    }
    public class DatosMaestria
    {
        public int[] SelectedItem { get; set; }
        public int IDSelected { get; set; }
        private static List<Maestria> Maestria;
        public List<Maestria> Maestrias
        {
            get
            {
                if (Maestria == null)
                {
                    Maestria = new List<Maestria>();
                }
                return Maestria;
            }
        }
    }
}
