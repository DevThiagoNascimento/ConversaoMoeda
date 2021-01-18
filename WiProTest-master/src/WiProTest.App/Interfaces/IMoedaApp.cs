using System.Collections.Generic;
using WiProTest.App.Dtos;
using WiProTest.Domain.Entities;

namespace WiProTest.App.Interfaces
{
    public interface IMoedaApp
    {
        bool AdicionarMoeda(List<Moeda> moedas);
        List<MoedaDto> RetornarUltimasMoedas();
    }
}
