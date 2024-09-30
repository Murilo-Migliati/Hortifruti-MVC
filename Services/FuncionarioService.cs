using HortifrutiMvc.DTOs;
using HortifrutiMvc.Models;
using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class FuncionarioService(IGenericRepository<Funcionario> funcionarioRepository, IGenericRepository<DadosPessoais> dadosPessoaisRepository) : GenericService<Funcionario, FuncionarioDTO>(funcionarioRepository)
    {
        private readonly IGenericRepository<DadosPessoais> _dadosPessoaisRepository = dadosPessoaisRepository;

        protected override FuncionarioDTO MapToDto(Funcionario entity)
        {
            return new FuncionarioDTO
            {
                Id = entity.Id,
                Nome = entity.Nome,
                Cargo = entity.Cargo,
                DadosPessoaisId = entity.DadosPessoaisId
            };
        }

        protected override Funcionario MapToEntity(FuncionarioDTO dto)
        {
            return new Funcionario
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Cargo = dto.Cargo,
                DadosPessoaisId = dto.DadosPessoaisId
            };
        }

        public async Task<IEnumerable<DadosPessoaisDTO>> GetAllDadosPessoaisAsync()
        {
            var dadosPessoais = await _dadosPessoaisRepository.GetAllAsync();
            return dadosPessoais.Select(dp => new DadosPessoaisDTO
            {
                Id = dp.Id,
                Email = dp.Email,
                Telefone = dp.Telefone,
                Endereco = dp.Endereco
            }).ToList();
        }
    }
}
