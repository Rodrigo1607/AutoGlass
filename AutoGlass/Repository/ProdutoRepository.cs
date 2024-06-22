using AutoGlass.Data;
using AutoGlass.Model;
using AutoGlass.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AutoGlass.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _dbContext;
        public ProdutoRepository(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }

        public void AdicionaProduto(Produto produto)
        {
            _dbContext.Add(produto);

        }
        public async Task<Produto> BuscaProdutoPorCodigo(string codigo)
        {
            return await _dbContext.Produtos.
               Where(x => x.Codigo == codigo).FirstOrDefaultAsync();
            
        }

        public async Task<Produto> BuscaProdutoPorId(int id)
        {
            return await _dbContext.Produtos.
                Where(x =>  x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Produto>> BuscaProduto()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public void AtualizaProduto(Produto produto)
        {
            _dbContext.Update(produto);
        }        

        public void DeletaProduto(Produto produto)
        {
            _dbContext.Remove(produto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
