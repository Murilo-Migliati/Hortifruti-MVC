using HortifrutiMvc.Repositories;

namespace HortifrutiMvc.Services
{
    public class GenericService<TEntity, TDto>(IGenericRepository<TEntity> repository) : IGenericService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {
        private readonly IGenericRepository<TEntity> _repository = repository;

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return entities.Select(e => MapToDto(e)).ToList();
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : MapToDto(entity);
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = MapToEntity(dto);
            await _repository.AddAsync(entity);
        }

        public async Task UpdateAsync(TDto dto)
        {
            var entity = await _repository.GetByIdAsync(GetEntityId(dto));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{typeof(TEntity).Name} não encontrado");
            }

            UpdateEntity(entity, dto);
            await _repository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _repository.ExistsAsync(id);
        }

        protected virtual TDto MapToDto(TEntity entity)
        {
            // Implement mapping logic here
            throw new NotImplementedException();
        }

        protected virtual TEntity MapToEntity(TDto dto)
        {
            // Implement mapping logic here
            throw new NotImplementedException();
        }

        protected virtual int GetEntityId(TDto dto)
        {
            // Implement logic to get the entity ID from the DTO
            throw new NotImplementedException();
        }

        protected virtual void UpdateEntity(TEntity entity, TDto dto)
        {
            // Implement logic to update the entity with values from the DTO
            throw new NotImplementedException();
        }
    }
}
