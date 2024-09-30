using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class ClienteService(IGenericRepository<Cliente> clienteRepository) : GenericService<Cliente, ClienteDTO>(clienteRepository)
    {
        protected override ClienteDTO MapToDto(Cliente entity)
        {
            return new ClienteDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Cpf = entity.Cpf,
                DadosPessoaisId = entity.DadosPessoaisId
            };
        }

        protected override Cliente MapToEntity(ClienteDTO dto)
        {
            return new Cliente
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Cpf = dto.Cpf,
                DadosPessoaisId = dto.DadosPessoaisId
            };
        }

        protected override int GetEntityId(ClienteDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(Cliente entity, ClienteDTO dto)
        {
            entity.Nome = dto.Nome;
            entity.Cpf = dto.Cpf;
            entity.DadosPessoaisId = dto.DadosPessoaisId;
        }
    }
}
