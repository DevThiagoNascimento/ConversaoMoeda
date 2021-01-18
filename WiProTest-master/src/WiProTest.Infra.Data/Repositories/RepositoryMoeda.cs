using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiProTest.Domain.Entities;
using WiProTest.Domain.Interfaces.Repositories;
using WiProTest.Infra.Data.Context;

namespace WiProTest.Infra.Data.Repositories
{
    public class RepositoryMoeda : RepositoryBase<Moeda>, IRepositoryMoeda
    {
        private readonly WiProTestContext wiProTestContext;
        public RepositoryMoeda(WiProTestContext _wiProTestContext)
            : base(_wiProTestContext)
        {
            wiProTestContext = _wiProTestContext;
        }

        public List<Moeda> ObterMoedasUltimoLote()
        {
            var ultimoLote = wiProTestContext.Moedas.Max(m => m.IdLote);
            return wiProTestContext.Moedas.Where(moeda => moeda.IdLote == ultimoLote).ToList();
        }
    }
}
