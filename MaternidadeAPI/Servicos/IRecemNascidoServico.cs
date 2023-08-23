﻿using MaternidadeAPI.Modelo;

namespace MaternidadeAPI.Servicos
{
    public interface IRecemNascidoServico
    {
        Task<List<RecemNascidoModelo>> GetRecemNascidosMae(int id);
        Task<List<RecemNascidoModelo>> GetRecemNascidosMaeParto(int id, string parto);
        Task CreateRecemNascido(RecemNascidoModelo recemNascido, int id);


        Task<RecemNascidoModelo> UpdateRecemNascidoWeightAndHeight(int id, int pesoGramas, int alturaCentimetros); //hamann
        Task DeleteRecemNascido(int Id);
        Task<List<RecemNascidoModelo>> GetRecemNascidoGenero(int Id, string Genero);
        Task<RecemNascidoModelo> GetRecemNascidoId(int Id);
        Task<List<RecemNascidoModelo>> GetRecemNascidoPeso(int Peso, int Id);
    }
}
