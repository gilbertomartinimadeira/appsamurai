using System;
using SamuraiApp.Dados;
using SamuraiApp.Dominio;

namespace SomeUI
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Inserindo Samurai, Aguarde...");

            InserirSamurai();

            Console.WriteLine("Samurai inserido com sucesso!");

            Console.ReadLine();

        }

        private static void InserirSamurai()
        {
            var samurai = new Samurai { Nome = "Jo" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);

                context.SaveChanges();
            }
           
        }
    }
}
