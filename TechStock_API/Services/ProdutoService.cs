using Microsoft.EntityFrameworkCore;
using TechStock_API.Context;
using TechStock_API.Domain;

namespace TechStock_API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        //Construtor para ter acesso ao db
        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<Produto> GetProduto(int id) // retornar apenas um produto
        {
            var produto = await _context.Produtos.FindAsync(id);
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetProdutoByNome(string nome)
        {
            IEnumerable<Produto> produtos;

            if(!string.IsNullOrEmpty(nome))
            {
                produtos = await _context.Produtos.Where(n => n.Nome.Contains(nome)).ToListAsync();
            }
            else
            {
                produtos = await GetProdutos();
            }
            return produtos;
        }

        public async Task<IEnumerable<Produto>> GetProdutos() // retorna a lista completa
        {
            try
            {
                return await _context.Produtos.ToListAsync();
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task UpdateEstoque(Produto produto) //Altera estoque
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        //CRUD
        public async Task CreateProduto(Produto produto) //cadastro
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduto(Produto produto) // deletar
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProduto(Produto produto) // alteração do produto
        {
           _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
