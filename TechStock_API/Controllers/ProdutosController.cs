using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStock_API.Domain;
using TechStock_API.DTO;
using TechStock_API.Services;

namespace TechStock_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.GetProdutos();
                //return Ok(produtos);
                var produtosFormatados = produtos.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Quantidade,
                    ValorUnitario = p.ValorUnitario.ToString("F3")  // Formata para 3 casas decimais
                }).ToList();

                return Ok(produtosFormatados);
            }
            catch
            {
                return StatusCode(500, "Erro ao obter a lista de produtos");
            }
        }

        [HttpGet("ProdutoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutosByName([FromQuery] string nome)
        {
            try
            {
                var produtos = await _produtoService.GetProdutoByNome(nome);
                if (produtos.Count() == 0)
                {
                    return NotFound($"Não existe nenhum produto com o nome {nome}");
                }
                //return Ok(produtos);
                var produtosFormatados = produtos.Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Quantidade,
                    ValorUnitario = p.ValorUnitario.ToString("F3")  // Formata para 3 casas decimais
                }).ToList();

                return Ok(produtosFormatados);

            }
            catch
            {
                return StatusCode(500, "Erro ao obter produtos por nome");
            }
        }

        [HttpGet("{id:int}", Name = "GetProduto")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);
                if (produto == null)
                {
                    return NotFound($"Não existe nenhum produto com o id {id}");
                }
                //return Ok(produto);
                return Ok(new
                {
                    produto.Id,
                    produto.Nome,
                    ValorUnitario = produto.ValorUnitario.ToString("F3") // Formata para 3 casas decimais
                });
            }
            catch
            {
                return StatusCode(500, "Erro ao obter produto por id");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Produto produto) // ENDPOINT CADASTRO
        {
            try
            {
                await _produtoService.CreateProduto(produto);
                return CreatedAtRoute(nameof(GetProduto), new { id = produto.Id }, produto); //retorna 201(criado) e os dados do produto   
            }
            catch
            {
                return StatusCode(500, "Erro ao obter produto por id");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> UpdateEstoque(int id, [FromBody] EstoqueUpdateDTO estoqueUpdate) // Alterar apenas o estoque
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);
                if (produto == null)
                {
                    return NotFound("Produto não encontrado.");
                }

                produto.Quantidade = estoqueUpdate.Quantidade;

                await _produtoService.UpdateEstoque(produto); // Atualiza o estoque no banco de dados
                return Ok($"O estoque do produto id = {id} foi atualizado com sucesso!");
            }
            catch
            {
                return BadRequest("Erro ao atualizar o estoque.");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromQuery] Produto produto) // ENDPOINT ALTERAR
        {
            try
            {
                if (produto.Id == id)
                {
                    await _produtoService.UpdateProduto(produto);
                    return Ok($"O produto com id {id} foi atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("O produto não pôde ser atualizado, verifique.");
                }

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) // ENDPOINT DELETAR
        {
            try
            {
                var produto = await _produtoService.GetProduto(id);
                if (produto != null)
                {
                    await _produtoService.DeleteProduto(produto);
                    return Ok($"Produto com id {id} foi deletado com sucesso.");
                }

                else
                {
                    return NotFound($"Aluno com id {id} não foi encontrado.");
                }

            }
            catch
            {
                return StatusCode(500, "Erro ao deletar produto.");
            }
        }
    }
}
