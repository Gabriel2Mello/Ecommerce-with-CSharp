using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Log;
using Ecommerce.Domain.Shared.Enums;
using Ecommerce.Domain.Utility;
using Ecommerce.Infra.Repositories.Log;

namespace Ecommerce.Application.Services.Log
{
    public class PessoaLogService
    {
        private readonly PessoaLogRepository _repository;
        private Pessoa? _entityBefore = null;
        private Pessoa? _entityUpdated = null;

        public PessoaLogService(PessoaLogRepository repository)
        {
            _repository = repository;
        }

        public void AddObject(Pessoa pessoa) 
        {
            LogUtility.EntityIsNull(pessoa);

            _entityUpdated = pessoa;
            _entityBefore = new(pessoa);
        }

        public async void MakeCreateLog(Pessoa pessoa)
        {
            LogUtility.EntityIsNull(pessoa);

            await _repository.AddAsync(
                PessoaLog.CreateObject(
                    guidPessoa: pessoa.Guid,
                    idPessoa: pessoa.Id,
                    idUsuario: 1,
                    acao: ELog.Create.ToString())
                ); 
        }

        public async void MakeUpdateLog()
        {
            LogUtility.EntityIsNull(_entityBefore, _entityUpdated);

            (List<string> propertyNames, bool hasAny) = LogUtility.GetUpdateChanges(_entityBefore!, _entityUpdated!);
            if (!hasAny) return;

            await _repository.AddAsync(
                PessoaLog.CreateObject(
                    guidPessoa: _entityUpdated!.Guid,
                    idPessoa: _entityUpdated.Id,
                    idUsuario: 1,
                    acao: ELog.Update.ToString(),
                    campo: string.Join(", ", propertyNames))
                );
        }
    }
}
