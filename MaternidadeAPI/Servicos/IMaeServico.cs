﻿using MaternidadeAPI.Modelo;

namespace MaternidadeAPI.Servicos
{
    public interface IMaeServico
    {
        Task<MaeModelo> GetMaeByIdAsync(int id);
        Task<int> CreateMaeAsync(MaeModelo model);
        Task UpdateMaeAsync(MaeModelo model);
        Task<List<MaeModelo>> GetAllMaesAsync();
        Task DeleteGeneroAsync(int id);
    }
}
