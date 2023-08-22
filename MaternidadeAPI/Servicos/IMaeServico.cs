using MaternidadeAPI.Modelo;

namespace MaternidadeAPI.Servicos
{
    public interface IMaeServico
    {
        Task<MaeModelo> GetMaeByIdAsync(int id);






    }
}
