using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class VendaService(IGenericRepository<Venda> vendaRepository, IGenericRepository<Cliente> clienteRepository) : GenericService<Venda, VendaDTO>(vendaRepository)
    {
        private readonly IGenericRepository<Cliente> _clienteRepository = clienteRepository;

        protected override VendaDTO MapToDto(Venda entity)
        {
            return new VendaDTO
            {
                Id = entity.Id,
                ClienteId = entity.ClienteId,
                Data = entity.Data,
                Total = entity.Total
            };
        }

        protected override Venda MapToEntity(VendaDTO dto)
        {
            return new Venda
            {
                Id = dto.Id,
                ClienteId = dto.ClienteId,
                Data = dto.Data,
                Total = dto.Total
            };
        }

        protected override int GetEntityId(VendaDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(Venda entity, VendaDTO dto)
        {
            entity.ClienteId = dto.ClienteId;
            entity.Data = dto.Data;
            entity.Total = dto.Total;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
