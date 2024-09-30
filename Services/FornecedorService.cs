using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class FornecedorService(IGenericRepository<Fornecedor> fornecedorRepository, IGenericRepository<DadosPessoais> dadosPessoaisRepository) : GenericService<Fornecedor, FornecedorDTO>(fornecedorRepository)
    {
        private readonly IGenericRepository<DadosPessoais> _dadosPessoaisRepository = dadosPessoaisRepository;

        protected override FornecedorDTO MapToDto(Fornecedor entity)
        {
            return new FornecedorDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Cnpj = entity.Cnpj,
                DadosPessoaisId = entity.DadosPessoaisId
            };
        }

        protected override Fornecedor MapToEntity(FornecedorDTO dto)
        {
            return new Fornecedor
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Cnpj = dto.Cnpj,
                DadosPessoaisId = dto.DadosPessoaisId
            };
        }

        protected override int GetEntityId(FornecedorDTO dto)
        {
            return dto.Id;
        }

        protected override void UpdateEntity(Fornecedor entity, FornecedorDTO dto)
        {
            entity.Nome = dto.Nome;
            entity.Cnpj = dto.Cnpj;
            entity.DadosPessoaisId = dto.DadosPessoaisId;
        }

        public async Task<List<DadosPessoais>> GetDadosPessoaisAsync()
        {
            return await _dadosPessoaisRepository.GetAllAsync();
        }
    }
}
