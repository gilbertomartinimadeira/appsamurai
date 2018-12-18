using System;
using System.Collections.Generic;

namespace SamuraiApp.Dominio
{
    public class Samurai
    {
        public Samurai()
        {
            Frases = new List<Frase>();

        }
        
        public int Id { get; set; }
        public String Nome { get; set; }
        public List<Frase> Frases { get; set; }
        public List<BatalhaSamurai> BatalhaSamurai{ get; set; }

    }
}
