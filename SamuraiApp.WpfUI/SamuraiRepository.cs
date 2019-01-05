using SamuraiApp.Dados;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Dominio;
using System.Linq;
using System.Collections.Generic;

namespace SamuraiApp.WpfUI
{
    public class SamuraiRepository : ISamuraiRepository
    {
        private SamuraiContext _context;

        public SamuraiRepository()
        {
            _context = new SamuraiContext();
            _context.Database.Migrate();
        }

        public Samurai ObterPorId(int id) => _context.Samurais.FirstOrDefault(s => s.Id == id);

        public List<Samurai> ObterTodos() => _context.Samurais.ToList();
        
        public void InserirSamurai(Samurai samurai) => _context.Samurais.Add(samurai);        

        public void AtualizarSamurai(int id, Samurai samurai)
        {
            var samuraiRepository = _context.Samurais.Find(id);

            samuraiRepository.Nome = samurai.Nome;                              
        }

        public void RemoverSamurai(int id)
        {
            int linhasAfetadas = _context.Database.ExecuteSqlCommand("exec DeletarPorId {0}", id);
        }
    
        public bool ExisteSamurai(int id) => _context.Samurais.Any(s => s.Id == id);       
    
        public int Salvar() => _context.SaveChanges();       

    }
}
