using MaternidadeAPI.Data;
using MaternidadeAPI.Modelo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;

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

        public async Task DeleteRecemNascido(int Id)
        {
            var recemNascido = await _contexto.RecemNascidos.FindAsync(Id);
            if (recemNascido != null)
            {
                _contexto.RecemNascidos.Remove(recemNascido);
                await _contexto.SaveChangesAsync();
            }
        }

        public async Task<List<RecemNascidoModelo>> GetRecemNascidoGenero(int Id, string Genero)
        {
            var recemNascidos = await _contexto.RecemNascidos.Where(r => r.Genero == Genero && r.MaeId == Id).ToListAsync();

            foreach (var recemNascido in recemNascidos)
            {
                if (recemNascido.MaeId != 0) // Verifica se o ID da mãe está definido
                {
                    var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);

                    if (mae != null)
                    {
                        recemNascido.Mae = mae; // Atualiza o objeto Mae no recemNascido
                    }
                }
            }

            return recemNascidos;
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

                }
            }

            return recemNascido;
        }



        public async Task<List<RecemNascidoModelo>> GetRecemNascidoPeso(int peso, int id)
        {
            var recemNascidos = await _contexto.RecemNascidos
        .Where(r => r.PesoGramas > peso && r.MaeId == id)
        .ToListAsync();

            foreach (var recemNascido in recemNascidos)
            {
                if (recemNascido.MaeId != 0) // Verifica se o ID da mãe está definido
                {
                    var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);

                    if (mae != null)
                    {
                        recemNascido.Mae = mae; // Atualiza o objeto Mae no recemNascido
                    }
                }
            }

            return recemNascidos;
        }

        public async Task<List<RecemNascidoModelo>> GetRecemNascidosMae(int id)
        {
            var recemNascidos = await _contexto.RecemNascidos.Where(r => r.MaeId == id).ToListAsync();

            foreach (var recemNascido in recemNascidos)
            {
                if (recemNascido.MaeId != 0) // Verifica se o ID da mãe está definido
                {
                    var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);

                    if (mae != null)
                    {
                        recemNascido.Mae = mae; // Atualiza o objeto Mae no recemNascido
                    }
                }
            }

            return recemNascidos;
        }

        public async Task<List<RecemNascidoModelo>> GetRecemNascidosMaeParto(int id, string parto)
        {
            var recemNascidos = await _contexto.RecemNascidos.Where(r => r.MaeId == id && r.TipoParto == parto).ToListAsync();

            foreach (var recemNascido in recemNascidos)
            {
                if (recemNascido.MaeId != 0) // Verifica se o ID da mãe está definido
                {
                    var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);

                    if (mae != null)
                    {
                        recemNascido.Mae = mae; // Atualiza o objeto Mae no recemNascido
                    }
                }
            }

            return recemNascidos;
        }

        public async Task<RecemNascidoModelo> UpdateRecemNascido(RecemNascidoModelo recemNascido, int id   )
        {
            var mae = await _contexto.Maes.FindAsync(recemNascido.MaeId);
            var recemExist = await _contexto.RecemNascidos.FindAsync(recemNascido.Id);
            if (recemExist is null) return null;

            recemExist = recemNascido;
            recemExist.Mae = mae;

            await _contexto.SaveChangesAsync();
            return recemExist;
        }
    }
}
