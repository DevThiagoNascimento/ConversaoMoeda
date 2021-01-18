using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;
using WiProTest.Domain.Interfaces.Repositories;

namespace WiProTest.Domain.Interfaces.Services
{
    public class MoedaService : IMoedaService
    {
        private IRepositoryLote repositoryLote;
        private readonly IRepositoryMoeda repositoryMoeda;

        public MoedaService(IRepositoryMoeda _repositoryMoeda, IRepositoryLote _repositoryLote)
        {
            repositoryMoeda = _repositoryMoeda;
            repositoryLote = _repositoryLote;
        }

        public bool InserirMoedas(List<Moeda> moedas)
        {
            try
            {
                var lote = new Lote
                {
                    DataCadastro = DateTime.Now
                };

                repositoryLote.Add(lote);

                foreach (var moeda in moedas)
                {
                    if (moeda.Validar())
                    {
                        moeda.IdLote = lote.Id;
                        repositoryMoeda.Add(moeda);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Moeda> ObterUltimoLote()
        {
            return repositoryMoeda.ObterMoedasUltimoLote();
        }
    }
}
