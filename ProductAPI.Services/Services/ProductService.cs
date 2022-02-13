using ProductAPI.Entities.Entities;
using ProductAPI.Entities.Interfaces;
using ProductAPI.Entities.Interfaces.Repository;
using ProductAPI.Entities.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<Product> BuscarProdutos()
        {
            List<Product> listaTratada = new List<Product>();
            var produto = _productRepository.BuscarProduto();
            foreach (var item in produto.Result)
            {
                listaTratada.Add(item);
            }
            return listaTratada;
        }

        public Task CadastrarProduto(Product produto)
        {
            var produtoCadastrado = _productRepository.CadastrarProduto(produto);
            return produtoCadastrado;            
        }

        
    }
}
