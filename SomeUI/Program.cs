using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Dados;
using SamuraiApp.Dominio;

namespace SomeUI
{
    public class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        public static void Main(string[] args)
        {



            ConsultaUsandoLike();

            Console.ReadLine();


        }

        private static void ConsultaUsandoLike()
        {
            var primeiroSamuraiComInicialG = _context.Samurais
                                  .Where(s => EF.Functions.Like(s.Nome, "G%")).FirstOrDefault();

            Console.WriteLine(primeiroSamuraiComInicialG.Nome);
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

            Console.WriteLine("Gerando uma query last com o 'OrderBy'");
            var ultimoSamuraiEncontrado = _context.Samurais.OrderBy(s => s.Nome).LastOrDefault(); 

            Console.WriteLine(ultimoSamuraiEncontrado?.Nome);

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
