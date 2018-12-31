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


            UpdateDesconectado();           
      
            Console.ReadLine();


        }

        private static void UpdateDesconectado()
        {
            var batalha = _context.Batalhas.FirstOrDefault();

            batalha.DataFinal = new DateTime(1561, 10, 1);

            using (var ctx = new SamuraiContext())
            {
                ctx.Batalhas.Update(batalha);

                ctx.SaveChanges();
            }
        }

        private static void InserirBatalha()
        {
            _context.Batalhas.Add(
                new Batalha() {
                    Nome = "Batalha de Okehazama",
                    DataInicial = new DateTime(1560, 5, 1),
                    DataFinal= new DateTime(1560, 6, 15)
                });

            _context.SaveChanges();
        }

        private static void ExecutarVariasOperacoes()
        {
            var primeiroSamurai = _context.Samurais.FirstOrDefault();
            primeiroSamurai.Nome += "Hiro";
            var samurai = new Samurai { Nome = "Byakuya" };

            _context.Samurais.Add(samurai);

            _context.SaveChanges();

        }

        private static void AtualizarVariosSamurais()
        {
            var samurais = _context.Samurais.ToList();

            samurais.ForEach(s => s.Nome += "San");

            _context.SaveChanges();
        }

        private static void AtualizarSamurai()
        {
            var samurai = _context.Samurais.FirstOrDefault();

            samurai.Nome += "San";

            _context.SaveChanges();
        }

        private static void ConsultasUsandoLike()
        {
            var primeiroSamuraiComInicialG = _context.Samurais
                                  .Where(s => EF.Functions.Like(s.Nome, "G%"))
                                  .FirstOrDefault();

            var todosOsSamuraisCom_A_noNome = _context.Samurais
                                                      .Where(s => EF.Functions.Like(s.Nome.ToUpper(), "%A%"))
                                                      .ToList();



            Console.WriteLine(primeiroSamuraiComInicialG.Nome);

            Console.WriteLine("Exibindo Todos Os Samurais Com A no nome");



            todosOsSamuraisCom_A_noNome.ForEach(s => {
                Console.WriteLine(s.Nome);
            });
        
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
