using MaternidadeAPI.Modelo;

namespace MaternidadeAPI.Servicos
{
    public interface IRecemNascidoServico
    {
        Task<List<RecemNascidoModelo>> GetRecemNascidosMae(int id);

        Task<List<RecemNascidoModelo>> GetRecemNascidosMaeParto(int id, string parto);

        Task CreateRecemNascido(RecemNascidoModelo recemNascido);
        Task<RecemNascidoModelo> UpdateRecemNascido(RecemNascidoModelo recemNascido);
        Task DeleterRecemNascido(int Id);
        Task<RecemNascidoModelo> GetRecemNascidoGenero(string Genero);
        Task<RecemNascidoModelo> GetRecemNascidoId(int Id);
        Task<RecemNascidoModelo> GetRecemNascidoPeso(int Peso);
    }
}
