using ProductAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Entities.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> BuscarProduto();
        Task CadastrarProduto(Product produto);
    }
}
