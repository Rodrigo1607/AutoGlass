using AutoGlass.Model;
using AutoGlass.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AutoGlass.Controllers
{
    [ApiController]
    [Route("api/controller")]

    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }


        [HttpGet("BuscaProdutoPorId/{id}")]
        public async Task<IActionResult> BuscaProdutoPorId(int id)
        {
            var produtos = await _produtoRepository.BuscaProdutoPorId(id);
            return produtos != null
                ? Ok(produtos)
                : NotFound("Produto não encontrado");

        }

        [HttpGet]
        public async Task<IActionResult> BuscaProduto()
        {
            var produtos = await _produtoRepository.BuscaProduto();
            return produtos.Any()
                ? Ok(produtos)
                : NotFound("Lista vazia");

        }

        [HttpGet("BuscaProdutoPorCodigo/{codigo}")]
        public async Task<IActionResult> BuscaProdutoPorCodigo(string codigo)
        {
            var produtos = await _produtoRepository.BuscaProdutoPorCodigo(codigo);
            return produtos != null
                ? Ok(produtos)
                : NotFound("Produto não encontrado");

        }


        [HttpPost]
        public async Task<IActionResult> Criar(Produto produto)
        {
            var mensagem = produto.Validar();
            if (string.IsNullOrEmpty(mensagem))
            {
                _produtoRepository.AdicionaProduto(produto);
                return await _produtoRepository.SaveChangesAsync()
                    ? Ok("Usuario Adicionado")
                    : BadRequest("Erro ao salvar Usuario");

            }
            return BadRequest(mensagem);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, Produto produto)
        {
            var produtos = await _produtoRepository.BuscaProdutoPorId(id);
            if (produtos == null)
            {
                return NotFound("Produto não encontrado");
            }

            //produtos.DataValidade = produto.DataValidade ?? produtos.DataValidade;
            //produtos.DataFabricacao = produto.DataFabricacao ?? produtos.DataFabricacao;
            if (produto.DataValidade != default(DateTime))
            {
                produtos.DataValidade = produto.DataValidade;
            }

            if (produto.DataFabricacao != default(DateTime))
            {
                produtos.DataFabricacao = produto.DataFabricacao;
            }

            produtos.Codigo = produto.Codigo ?? produtos.Codigo;
            produtos.DescricaoFornecedor = produto.DescricaoFornecedor ?? produtos.DescricaoFornecedor;
            produtos.Descricao = produto.Descricao ?? produtos.Descricao;
            produtos.Status = produto.Status ?? produtos.Status;
            produtos.CNPJFornecedor = produto.CNPJFornecedor ?? produtos.CNPJFornecedor;

            _produtoRepository.AtualizaProduto(produtos);

            return await _produtoRepository.SaveChangesAsync()
                ? Ok("Produto atualizado com sucesso")
                : BadRequest("Erro ao atualizar o produto");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaProduto(int id)
        {
            var produto = await _produtoRepository.BuscaProdutoPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            _produtoRepository.DeletaProduto(produto);

            return await _produtoRepository.SaveChangesAsync()
                ? Ok("Produto deletado com sucesso")
                : BadRequest("Erro ao deletar o produto");
        }
    }
}
