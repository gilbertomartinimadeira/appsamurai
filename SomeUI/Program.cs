using System;
using System.Collections.Generic;
using System.Linq;
using SamuraiApp.Dados;
using SamuraiApp.Dominio;

namespace SomeUI
{
    public class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        public static void Main(string[] args)
        {



            MaisConsultas();
            Console.ReadLine();


        }

        private static void MaisConsultas()
        {
            var inicial = "G";

            var doisPrimeirosSamurais = _context.Samurais
                                                .Take(2)
                                                .Where(s => s.Nome.ToUpper().StartsWith(inicial))
                                                .ToList();

            doisPrimeirosSamurais.ForEach(s => {
                Console.WriteLine(s.Nome);
            });

            var primeiroSamuraiEncontrado = _context.Samurais
                                                    .OrderByDescending(s => s.Id)
                                                    .Where(s => s.Nome.ToUpper().StartsWith("X"))
                                                    .FirstOrDefault();

            Console.WriteLine(primeiroSamuraiEncontrado?.Nome);
        
        }

        private static void ExibirSamurais()
        {
            var samurais = _context.Samurais
                                   .OrderByDescending(s => s.Nome)
                                   .ToList();

            samurais.ForEach(s =>
            {
                Console.WriteLine($"Samurai: {s.Nome}");
            });

        }

        private static void InserirVariosSamurais()
        {
            var primeiroSamurai = new Samurai { Nome = "Alan" };
            var segundoSamurai = new Samurai { Nome = "Gilberto" };

            _context.Samurais.AddRange(primeiroSamurai, segundoSamurai);

            _context.SaveChanges();


        }

        private static void InserirSamurai()
        {
            var samurai = new Samurai { Nome = "Gil" };


            _context.Samurais.Add(samurai);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

    }

}
