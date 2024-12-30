using TechStock_API.Domain;

namespace TechStock_API.Services
{
    public interface IProdutoService
    {
        //Definir contrato
        Task<IEnumerable<Produto>> GetProdutos(); // Retorna lista de produtos
        Task<Produto> GetProduto(int id); // Retorna o produto por ID
        Task<IEnumerable<Produto>> GetProdutoByNome(string nome); // Retorna pelo nome
        Task CreateProduto(Produto produto);
        Task DeleteProduto(Produto produto);
        Task UpdateProduto(Produto produto);

        Task UpdateEstoque(Produto produto);
    }
}
