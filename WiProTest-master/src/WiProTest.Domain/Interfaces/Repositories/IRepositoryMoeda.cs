using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;

namespace WiProTest.Domain.Interfaces.Repositories
{
    public interface IRepositoryMoeda : IRepositoryBase<Moeda>
    {
        List<Moeda> ObterMoedasUltimoLote();
    }
}
