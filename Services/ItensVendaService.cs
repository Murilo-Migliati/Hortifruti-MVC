using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class ItensVendaService(IGenericRepository<ItensVenda> repository) : GenericService<ItensVenda, ItensVendaDTO>(repository)
    {
        protected override ItensVendaDTO MapToDto(ItensVenda entity)
        {
            return new ItensVendaDTO
            {
                Id = entity.Id,
                VendaId = entity.VendaId,
                ProdutoId = entity.ProdutoId,
                Quantidade = entity.Quantidade,
                Preco = entity.Preco
            };
        }

        protected override ItensVenda MapToEntity(ItensVendaDTO dto)
        {
            return new ItensVenda
            {
                Id = dto.Id,
                VendaId = dto.VendaId,
                ProdutoId = dto.ProdutoId,
                Quantidade = dto.Quantidade,
                Preco = dto.Preco
            };
        }

        protected override int GetEntityId(ItensVendaDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(ItensVenda entity, ItensVendaDTO dto)
        {
            entity.VendaId = dto.VendaId;
            entity.ProdutoId = dto.ProdutoId;
            entity.Quantidade = dto.Quantidade;
            entity.Preco = dto.Preco;
        }
    }
}
