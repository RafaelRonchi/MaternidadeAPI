using MaternidadeAPI.DTO;
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
        Task<MaeModelo> UpdateHistoricoAsync(int id,HistoricoUpdateDto historicoDto);
        Task<bool> DeleteMaeAsync(int id);
        Task<List<MaeModelo>> GetMaesPorEstadoCivilAsync(string estadoCivil);
        Task<List<MaeModelo>> GetMaesByEtniaAsync(string nomeEtnia);
        Task<MaeModelo> GetMaesByRg(string rg);
        Task<int> GetMaeIdadeAsync(int id);
    }
}
