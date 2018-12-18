using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Dominio
{
    public class BatalhaSamurai
    {
        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
    }
}
