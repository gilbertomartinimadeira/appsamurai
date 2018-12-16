namespace SamuraiApp.Dominio
{
    public class Frase
    {
        public int Id{ get; set; }
        public string Texto { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
    }
}