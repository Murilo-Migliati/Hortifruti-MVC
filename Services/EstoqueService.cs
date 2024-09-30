using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class EstoqueService(IGenericRepository<Estoque> estoqueRepository, IGenericRepository<Produto> produtoRepository) : GenericService<Estoque, EstoqueDTO>(estoqueRepository)
    {
        private readonly IGenericRepository<Produto> _produtoRepository = produtoRepository;

        protected override EstoqueDTO MapToDto(Estoque entity)
        {
            return new EstoqueDTO
            {
                Id = entity.Id,
                ProdutoId = entity.ProdutoId,
                Quantidade = entity.Quantidade,
                DataAtualizacao = entity.DataAtualizacao
            };
        }

        protected override Estoque MapToEntity(EstoqueDTO dto)
        {
            return new Estoque
            {
                Id = dto.Id,
                ProdutoId = dto.ProdutoId,
                Quantidade = dto.Quantidade,
                DataAtualizacao = dto.DataAtualizacao
            };
        }

        protected override int GetEntityId(EstoqueDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(Estoque entity, EstoqueDTO dto)
        {
            entity.ProdutoId = dto.ProdutoId;
            entity.Quantidade = dto.Quantidade;
            entity.DataAtualizacao = dto.DataAtualizacao;
        }

        public async Task<List<Produto>> GetProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }
    }
}
