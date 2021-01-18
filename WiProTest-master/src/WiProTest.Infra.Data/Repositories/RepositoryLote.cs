using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;
using WiProTest.Domain.Interfaces.Repositories;
using WiProTest.Infra.Data.Context;

namespace WiProTest.Infra.Data.Repositories
{
    public class RepositoryLote : RepositoryBase<Lote>, IRepositoryLote
    {
        private readonly WiProTestContext wiProTestContext;
        public RepositoryLote(WiProTestContext _wiProTestContext)
            : base(_wiProTestContext)
        {
            wiProTestContext = _wiProTestContext;
        }
    }
}
