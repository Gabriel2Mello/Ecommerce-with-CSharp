﻿using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces;
using System.Linq.Expressions;

namespace Ecommerce.Infra.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly IRepositoryBase<Pessoa> _repositoryBase;

        public PessoaRepository(IRepositoryBase<Pessoa> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task AddAsync(Pessoa entity)
        {
            await _repositoryBase.AddAsync(entity);
        }

        public async Task UpdateAsync(Pessoa entity) 
        {
            await _repositoryBase.UpdateAsync(entity);
        }

        public async Task<IEnumerable<Pessoa>> GetAsync(Expression<Func<Pessoa, bool>> filter = null)
        {
            return await _repositoryBase.GetAsync(filter);
        }

        public async Task<Pessoa> GetByIdAsync(Guid guid)
        {
            return await _repositoryBase.GetByIdAsync(guid);
        }

        public async Task<Pessoa> GetByIdAsync(int id)
        {
            return await _repositoryBase.GetByIdAsync(id);
        }
    }
}