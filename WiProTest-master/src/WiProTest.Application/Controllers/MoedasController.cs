using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WiProTest.App.Interfaces;
using WiProTest.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WiProTest.Api.Controllers
{
    [ApiController]
    public class MoedasController : ControllerBase
    {
        private readonly IMoedaApp moedaApp;
        public MoedasController(IMoedaApp _moedaApp)
        {
            moedaApp = _moedaApp;
        }

        [HttpPost]
        [Route("add-item-fila")]
        public IActionResult AddItemFila([FromBody] List<Moeda> moedas)
        {
            if (moedaApp.AdicionarMoeda(moedas))
            {
                return StatusCode(200);
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet]
        [Route("get-item-fila")]
        public IActionResult GetItemFila()
        {
            var moedas = moedaApp.RetornarUltimasMoedas();

            return Ok(moedas);
        }
    }
}
