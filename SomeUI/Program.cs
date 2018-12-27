using System;
using System.Collections.Generic;
using SamuraiApp.Dados;
using SamuraiApp.Dominio;

namespace SomeUI
{
    class Program
    {
        public static void Main(string[] args)
        {
                       

            InserirVariosSamurais();

            Console.WriteLine("Vários Samurais inseridos com sucesso!");

            Console.ReadLine();

        }

        private static void InserirVariosSamurais()
        {
            var primeiroSamurai = new Samurai { Nome = "Alan" };
            var segundoSamurai = new Samurai { Nome = "Gilberto" };

            using(var context = new SamuraiContext())
            {
                context.Samurais.AddRange(primeiroSamurai, segundoSamurai);

                context.SaveChanges();

            }
        }



        private static void InserirSamurai()
        {
            var samurai = new Samurai { Nome = "Gil" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);


                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
           
        }
    }
}
