using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Entities.Entities
{
    public class Cliente : DadosCliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Product> Produtos { get; set; }
    }
}
