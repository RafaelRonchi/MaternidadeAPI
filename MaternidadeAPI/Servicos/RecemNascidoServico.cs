using MaternidadeAPI.Data;
using MaternidadeAPI.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MaternidadeAPI.Servicos
{
    public class RecemNascidoServico : IRecemNascidoServico
    {
        private readonly DataContext _contexto;
        public RecemNascidoServico(DataContext context) { _contexto = context; }
        public async Task CreateRecemNascido(RecemNascidoModelo recemNascido, int Id)
        {
            var mae = await _contexto.Maes.FindAsync(Id);
            if (mae != null)
            {
                _contexto.RecemNascidos.Add(recemNascido);
                await _contexto.SaveChangesAsync();
            }
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

        public async Task<List<RecemNascidoModelo>> GetRecemNascidoGenero(int Id,string Genero)
        {
            return await _contexto.RecemNascidos.Where(r => r.Genero == Genero && r.MaeId == Id).ToListAsync();
        }

        public async Task<RecemNascidoModelo> GetRecemNascidoId(int Id)
        {
            var recemNascido = await _contexto.RecemNascidos.FindAsync(Id);

            if (recemNascido.MaeId != 0) // Verifica se o ID da mãe está definido
            {
                var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);

                if (mae != null)
                {
                    recemNascido.Mae = mae; // Atualiza o objeto Mae no recemNascido
                    recemNascido.Mae.Profissao = mae.Profissao;
                    recemNascido.Mae.Etnia = mae.Etnia;
                    recemNascido.Mae.Cpf = mae.Cpf;
                    recemNascido.Mae.Historico = mae.Historico;
                    recemNascido.Mae.DataNascimento = mae.DataNascimento;
                    recemNascido.Mae.Rg = mae.Rg;
                    recemNascido.Mae.Endereco = mae.Endereco;
                    recemNascido.Mae.EstadoCivil = mae.EstadoCivil;
                    recemNascido.Mae.Telefone = mae.Telefone;
                    recemNascido.Mae.Nome = mae.Nome;
                    recemNascido.Mae.Sobrenome = mae.Sobrenome;
                }
            }

            return recemNascido;
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
