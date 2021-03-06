﻿using System;
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
            ModificarObjetosRelacionadosSemRastreamento();

            Console.ReadLine();                   


        }

        private static void ModificarObjetosRelacionadosSemRastreamento()
        {
            var samurai = _context.Samurais.Include(s => s.Frases).FirstOrDefault();
            var primeiraFrase = samurai.Frases[0];

            primeiraFrase.Texto += ", Ouviu bem?";

            #region O Jeito Errado
            //using (var outroContexto = new SamuraiContext())
            //{
            //    outroContexto.Frases.Update(primeiraFrase);

            //    outroContexto.SaveChanges();
            //}
            #endregion

            #region O Jeito Certo
            using (var outroContexto = new SamuraiContext())
            {
                outroContexto.Entry(primeiraFrase).State = EntityState.Modified;
                outroContexto.SaveChanges();
            }
            #endregion

        }

        private static void FiltrarPelosFilhos()
        {
            var samuraisEgoistasQueFalamDeSi = _context.Samurais
                                                       .Where(s => s.Frases.Any(f => f.Texto.ToUpper().StartsWith("EU")))
                                                       .ToList();
            foreach(var s in samuraisEgoistasQueFalamDeSi)
            {
                Console.WriteLine(s);
            }

        }

        private static List<Samurai> ProjecaoComObjetosRelacionados()
        {
            //var novosObjetos = _context.Samurais
            //                           .Select(s => new { Id = s.Id, Nome = s.Nome , Frases  = s.Frases.Count()})
            //                           .ToList();

            //var novosObjetos = _context.Samurais
            //                           .Select(s => new { Id = s.Id, Nome = s.Nome, Frases = s.Frases
            //                                                                                  .Where(f => f.Texto
            //                                                                                               .ToUpper()
            //                                                                                               .StartsWith('E')) })
            //                           .ToList();

            //SOLUÇÃO
            var samurais = _context.Samurais.ToList();
                                   
            var frases = _context.Frases
                                 .Where(f => f.Texto
                                 .ToUpper()
                                 .StartsWith('E'))
                                 .ToList();

            return samurais;
        }

        private static List<dynamic> ProjecaoComSelect()
        {
            var novosObjetos = _context.Samurais.Select(s => new { Id = s.Id, Nome = s.Nome }).ToList();

            return novosObjetos.ToList<dynamic>();
        }

        private static void AdicionarFilhosEmEntidadeExistenteNaoRastreada(int id)
        {
            var frases = new List<Frase>
            {
                new Frase { Texto = "Esse e meu estilo samurai", SamuraiId = id},
                new Frase { Texto = "Eles tem armas de fogo, nós temos coragem", SamuraiId = id}
            };

            _context.Frases.AddRange(frases);

            _context.SaveChanges();
            

        }

        private static void InserirFilhosEmEntidadeExistente()
        {
            var samurai = _context.Samurais.First();

            var frases = new List<Frase>()
            {
                new Frase { Texto = "Não há honra na morte"},
                new Frase { Texto = "Me deram essa espada, agora posso cortar meus inimigos"},
            };

            samurai.Frases = frases;

            _context.SaveChanges();
        }

        private static void InserirEntidadeComMultiplosFilhos()
        {
            var samurai = new Samurai() {
                Nome = "Soichiro",
                Frases = new List<Frase>()
                {
                    new Frase { Texto = "Me chuta que te atiro no poço"},
                    new Frase { Texto = "Não o perdoo"},
                    new Frase { Texto = "Eu te mandarei direto pro inferno."}
                }
            };

            _context.Samurais.Add(samurai);

            _context.SaveChanges();

        }

        private static void InserirNovaRelacaoPKFK()
        {
            var samurai = new Samurai()
            {
                Nome = "Kojiro Yamamoto",
                Frases = new List<Frase>() {
                                               new Frase() { Texto = "Eu Vim pra te salvar"}
                                           }
            };

            _context.Samurais.Add(samurai);        
            _context.SaveChanges();
                
        }

        private static void RemovePorId(int id)
        {
            int linhasAfetadas = _context.Database.ExecuteSqlCommand("exec DeletarPorId {0}", id);

            Console.WriteLine($"{linhasAfetadas} linhas afetadas");
            /*
            CREATE PROCEDURE DeletarPorId
            @ID INT
            AS
            BEGIN
                BEGIN TRY
                    DELETE FROM SamuraiAppDados.dbo.Samurais where Id = @ID;
                        END TRY

                BEGIN CATCH

                END CATCH


            END;
            */

        }

        private static void RemocaoDeObjetoRastreado()
        {
            var samurai = _context.Samurais.FirstOrDefault(s => EF.Functions.Like(s.Nome, "Gil%"));

            _context.Remove(samurai);

            _context.SaveChanges();
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

        private static void ObterSamuraiPorId(int id)
        {
            var samurai = _context.Samurais
                                  .Where(s => s.Id == id)
                                  .Include(s => s.Frases)
                                  .FirstOrDefault();

            Console.WriteLine(samurai);
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
