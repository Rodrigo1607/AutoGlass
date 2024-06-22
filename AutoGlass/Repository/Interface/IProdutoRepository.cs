using AutoGlass.Model;

namespace AutoGlass.Repository.Interface
{
    public interface IProdutoRepository
    {

        Task<IEnumerable<Produto>> BuscaProduto();
        Task<Produto> BuscaProdutoPorId(int id);
       Task<Produto> BuscaProdutoPorCodigo(string codigo);
        
        void AdicionaProduto(Produto produto);
        void AtualizaProduto(Produto produto);
        void DeletaProduto(Produto produto);

        Task<bool> SaveChangesAsync();
    }
}
