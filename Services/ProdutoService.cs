using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class ProdutoService(IGenericRepository<Produto> produtoRepository, IGenericRepository<Fornecedor> fornecedorRepository) : GenericService<Produto, ProdutoDTO>(produtoRepository)
    {
        private readonly IGenericRepository<Fornecedor> _fornecedorRepository = fornecedorRepository;

        protected override ProdutoDTO MapToDto(Produto entity)
        {
            return new ProdutoDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Preco = entity.Preco,
                FornecedorId = entity.FornecedorId
            };
        }

        protected override Produto MapToEntity(ProdutoDTO dto)
        {
            return new Produto
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Preco = dto.Preco,
                FornecedorId = dto.FornecedorId
            };
        }

        protected override int GetEntityId(ProdutoDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(Produto entity, ProdutoDTO dto)
        {
            entity.Nome = dto.Nome;
            entity.Preco = dto.Preco;
            entity.FornecedorId = dto.FornecedorId;
        }

        public async Task<List<Fornecedor>> GetFornecedoresAsync()
        {
            return await _fornecedorRepository.GetAllAsync();
        }
    }
}
