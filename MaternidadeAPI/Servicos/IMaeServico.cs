using MaternidadeAPI.Modelo;
using System.Threading.Tasks;

namespace MaternidadeAPI.Servicos
{
    public interface IMaeServico
    {
        Task<MaeModelo> GetMaeByIdAsync(int id);
        Task<int> CreateMaeAsync(MaeModelo model);
        Task UpdateMaeAsync(MaeModelo model);
        Task<List<MaeModelo>> GetAllMaesAsync();
        Task<MaeModelo> UpdateHistoricoAsync(int id,string historico);



        Task DeleteGeneroAsync(int id);


        Task<List<MaeModelo>> GetMaeSolteiraAsync();
        Task<List<MaeModelo>> GetMaeByEtniaAsync(string nomeEtnia);
        Task<int> GetIdadeMaeByIdAsync(int id);
    }
}
