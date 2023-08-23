using MaternidadeAPI.Data;
using MaternidadeAPI.DTO;
using MaternidadeAPI.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeAPI.Servicos
{
    public class MaeServico : IMaeServico
    {
        private readonly DataContext _context;

        public MaeServico(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<MaeModelo> GetMaeByIdAsync(int id)
        {
            var mae = await _context.Maes.FirstOrDefaultAsync(m => m.Id == id);
            if (mae == null)
            {
                return mae;
            }
            return mae;
        }

        public async Task<int> CreateMaeAsync(MaeModelo model)
        {
            _context.Maes.Add(model);
            await _context.SaveChangesAsync();
            return model.Id;
        }

        public async Task UpdateMaeAsync(MaeModelo model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<List<MaeModelo>> GetAllMaesAsync()
        {
            return await _context.Maes.ToListAsync();
        }

        public async Task<MaeModelo> UpdateHistoricoAsync(int id,HistoricoUpdateDto historicoDto)
        {
            var mae = await _context.Maes.FirstOrDefaultAsync(m => m.Id == id);
            if (mae == null)
            {
                return null;
            }
            mae.Historico = historicoDto.Historico;
            await _context.SaveChangesAsync();
            return mae;
        }

        public async Task<bool> DeleteMaeAsync(int id)
        {
            var maeDb = await _context.Maes.FindAsync(id);
            if (maeDb == null)
            {
                return false;
            }
            _context.Maes.Remove(maeDb);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<MaeModelo>> GetMaesPorEstadoCivilAsync(string estadoCivil)
        {
            return await _context.Maes
                .Where(m => m.EstadoCivil == estadoCivil)
                .ToListAsync();
        }

        public async Task<List<MaeModelo>> GetMaesByEtniaAsync(string nomeEtnia)
        {
            return await _context.Maes
                .Where(m => m.Etnia == nomeEtnia)
                .ToListAsync();
        }

        public async Task<int> GetMaeIdadeAsync(int id)
        {
            var mae = await _context.Maes.SingleOrDefaultAsync(m => m.Id == id);
            if (mae == null)
            {
                return -1; // Indicar que a mãe não foi encontrada
            }
            var birthDate = mae.DataNascimento;
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate > today.AddYears(-age))
                age--;
            return age;
        }

        public async Task<MaeModelo> GetMaesByRg(string rg)
        {
            return await _context.Maes.FirstOrDefaultAsync(mae => mae.Rg == rg);
        }

    }
}

