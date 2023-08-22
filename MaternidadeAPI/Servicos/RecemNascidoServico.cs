using MaternidadeAPI.Data;

namespace MaternidadeAPI.Servicos
{
    public class RecemNascidoServico : IRecemNascidoServico
    {
        private readonly DataContext _dataContext;

        public RecemNascidoServico(DataContext dataContext)
        {
            _dataContext = dataContext;
        }




    }
}
