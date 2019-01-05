using System.Collections.Generic;
using SamuraiApp.Dominio;

namespace SamuraiApp.WpfUI
{
    public interface ISamuraiRepository
    {
        void AtualizarSamurai(int id, Samurai samurai);
        bool ExisteSamurai(int id);
        void InserirSamurai(Samurai samurai);
        Samurai ObterPorId(int id);
        List<Samurai> ObterTodos();
        void RemoverSamurai(int id);
        int Salvar();
    }
}