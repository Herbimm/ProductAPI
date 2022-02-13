using Microsoft.EntityFrameworkCore;
using ProductAPI.Entities.Entities;
using ProductAPI.Entities.Interfaces.Repository;
using ProductAPI.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        

        private readonly MyContext _myContext;

        public ProductRepository(MyContext myContext)
        {            
            _myContext = myContext;
        }
        public async Task<List<Product>> BuscarProduto()
        {            
            var buscarProdutos =  _myContext.Produtos.ToList();
            return buscarProdutos;   
        }

        public async Task CadastrarProduto(Product produto)
        {
            var cadastrarproduto = await _myContext.Produtos.AddAsync(produto);
            await _myContext.SaveChangesAsync();
        }
    }
}
