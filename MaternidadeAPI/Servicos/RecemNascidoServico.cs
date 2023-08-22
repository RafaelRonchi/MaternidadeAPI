using MaternidadeAPI.Data;
using MaternidadeAPI.Modelo;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeAPI.Servicos
{
    public class RecemNascidoServico : IRecemNascidoServico
    {
        private readonly DataContext _contexto;
        public RecemNascidoServico(DataContext context) { _contexto = context; }
        public async Task CreateRecemNascido(RecemNascidoModelo recemNascido)
        {
            _contexto.RecemNascidos.Add(recemNascido);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeleterRecemNascido(int Id)
        {
            var recemNascido = await _contexto.RecemNascidos.FindAsync(Id);
            if (recemNascido != null)
            {
                _contexto.RecemNascidos.Remove(recemNascido);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<RecemNascidoModelo> GetRecemNascidoGenero(string Genero)
        {
            return await _contexto.RecemNascidos.FirstOrDefaultAsync(r => r.Genero == Genero);
        }

        public async Task<RecemNascidoModelo> GetRecemNascidoId(int Id)
        {
            return await _contexto.RecemNascidos.FindAsync(Id);
        }

        public async Task<List<RecemNascidoModelo>> GetRecemNascidoPeso(int peso, int id)
        {
            return await _contexto.RecemNascidos
                .Where(r => r.PesoGramas > peso && r.MaeId == id)
                .ToListAsync();
        }


        public async Task<List<RecemNascidoModelo>> GetRecemNascidosMae(int id)
        {
            return await _contexto.RecemNascidos.Where(r => r.MaeId == id).ToListAsync();
        }

        public async Task<List<RecemNascidoModelo>> GetRecemNascidosMaeParto(int id, string parto)
        {
            return await _contexto.RecemNascidos.Where(r => r.MaeId == id && r.TipoParto == parto).ToListAsync();
        }

        public async Task<RecemNascidoModelo> UpdateRecemNascido(RecemNascidoModelo recemNascido)
        {
            _contexto.Entry(recemNascido).State = EntityState.Modified;
            await _contexto.SaveChangesAsync();
            return recemNascido;
        }

        
    }

}
