using System;
using System.Collections.Generic;
using WiProTest.App.Dtos;
using WiProTest.App.Interfaces;
using WiProTest.Domain.Entities;
using WiProTest.Domain.Interfaces.Services;

namespace WiProTest.App
{
    public class MoedaApp : IMoedaApp
    {
        private readonly IMoedaService moedaService;
        public MoedaApp(IMoedaService _moedaService)
        {
            moedaService = _moedaService;
        }

        public bool AdicionarMoeda(List<Moeda> moedas)
        {
            return moedaService.InserirMoedas(moedas);
        }

        public List<MoedaDto> RetornarUltimasMoedas()
        {
            var ultimoLote = moedaService.ObterUltimoLote();

            List<MoedaDto> moedas = new List<MoedaDto>();

            foreach (var lote in ultimoLote)
            {
                moedas.Add(new MoedaDto
                {
                    moeda = lote.NomeMoeda,
                    data_inicio = lote.DataInicio,
                    data_fim = lote.DataFim
                });
            }
            return moedas;
        }
    }
}
