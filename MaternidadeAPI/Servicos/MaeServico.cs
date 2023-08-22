using MaternidadeAPI.Data;
using MaternidadeAPI.Modelo;

namespace MaternidadeAPI.Servicos
{
    public class MaeServico : IMaeServico
    {
        private readonly DataContext _dataContext;

        public MaeServico(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Task<MaeModelo> GetMaeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
