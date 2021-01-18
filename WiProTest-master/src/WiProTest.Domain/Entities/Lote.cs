using System;
using System.Collections.Generic;
using System.Text;

namespace WiProTest.Domain.Entities
{
    public class Lote : BaseEntity
    {
        public DateTime DataCadastro { get; set; }
        public ICollection<Moeda> Moedas { get; set; }
    }
}
