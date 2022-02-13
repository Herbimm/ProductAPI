using ProductAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Entities.Interfaces.Service
{
    public interface IProductService
    {        
        List<Product> BuscarProdutos();

        Task CadastrarProduto(Product produto);
        
    }
}
