using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class DadosPessoaisService(IGenericRepository<DadosPessoais> dadosPessoaisRepository) : GenericService<DadosPessoais, DadosPessoaisDTO>(dadosPessoaisRepository)
    {
        protected override DadosPessoaisDTO MapToDto(DadosPessoais entity)
        {
            return new DadosPessoaisDTO
            {
                Id = entity.Id,
                Email = entity.Email,
                Telefone = entity.Telefone,
                Endereco = entity.Endereco
            };
        }

        protected override DadosPessoais MapToEntity(DadosPessoaisDTO dto)
        {
            return new DadosPessoais
            {
                Id = dto.Id,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco
            };
        }

        protected override int GetEntityId(DadosPessoaisDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(DadosPessoais entity, DadosPessoaisDTO dto)
        {
            entity.Email = dto.Email;
            entity.Telefone = dto.Telefone;
            entity.Endereco = dto.Endereco;
        }
    }
}
