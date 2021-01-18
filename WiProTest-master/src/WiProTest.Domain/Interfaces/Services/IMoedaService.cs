using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;

namespace WiProTest.Domain.Interfaces.Services
{
    public interface IMoedaService
    {
        bool InserirMoedas(List<Moeda> moedas);
        List<Moeda> ObterUltimoLote();
    }
}
