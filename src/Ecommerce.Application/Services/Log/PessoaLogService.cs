using Ecommerce.Domain.Base;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Log;
using Ecommerce.Infra.Repositories.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Services.Log
{
    public class PessoaLogService
    {
        private readonly PessoaLogRepository _repository;
        private Pessoa? _beforePessoa = null;
        private Pessoa? _pessoa = null;

        public PessoaLogService(PessoaLogRepository repository)
        {
            _repository = repository;
        }

        public void AddObject(Pessoa pessoa) 
        {
            _pessoa = pessoa ?? throw new ArgumentNullException(nameof(pessoa), "Can't make log if parameter is null");
            _beforePessoa = new(pessoa); 
        }

        public async void MakeLog()
        {
            Type type = typeof(Pessoa);
            PropertyInfo[] properties = type.GetProperties();

            List<string> propertyNames = new();
            foreach (PropertyInfo property in properties)
            {                                
                object oldValue = property.GetValue(_beforePessoa, null)!;
                object newValue = property.GetValue(_pessoa, null)!;

                if (property.PropertyType.IsSubclassOf(typeof(EntityBase)))
                    continue;

                if(!oldValue.Equals(newValue))
                    propertyNames.Add(property.Name);
            }

            if (propertyNames.Any())
            {
                var log = PessoaLog.CreateObject(_pessoa!.Guid, _pessoa.Id, 1, "Update", string.Join(", ", propertyNames));

                await _repository.AddAsync(log);
            }            
        }
    }
}
