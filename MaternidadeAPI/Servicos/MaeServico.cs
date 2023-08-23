using MaternidadeAPI.Data;
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
            var mae = await _context.Maes.SingleOrDefaultAsync(m => m.Id == id);
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

        public Task UpdateMaeAsync(MaeModelo model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGeneroAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MaeModelo>> GetAllMaesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<MaeModelo>> GetMaeByEtniaAsync(string nomeEtnia)
        {
            return await _context.Maes
                .Where(m => m.Etnia == nomeEtnia)
                .ToListAsync();
        }

        public async Task<int> GetIdadeMaeByIdAsync(int id)
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

    }
}

