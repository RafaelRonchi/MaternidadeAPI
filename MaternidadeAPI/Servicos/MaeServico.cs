using MaternidadeAPI.Data;

namespace MaternidadeAPI.Servicos
{
    public class MaeServico : IMaeServico
    {
        private readonly DataContext _dataContext;

        public MaeServico(DataContext dataContext)
        {
            _dataContext = dataContext;
        }




    }
}
