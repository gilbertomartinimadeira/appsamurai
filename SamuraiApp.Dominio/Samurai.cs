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
        public List<BatalhaSamurai> BatalhaSamurai { get; set; }
        public IdentidadeSecreta IdentidadeSecreta { get; set; }

        public override string ToString()
        {
            var samuraiString = "Nome: " + this.Nome;

            foreach(var s in this.Frases)
            {
                samuraiString += "\""+ s.Texto + "\"\n";
            }

            return samuraiString;
        }

    }
}
