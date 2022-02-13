using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entities.DTO;
using ProductAPI.Entities.Entities;
using ProductAPI.Entities.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Controllers
{
    [Route("Produtos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("BuscarProdutos")]
        public List<Product> BuscarProdutos()
        {
           var produtos = _productService.BuscarProdutos();
           return produtos;         
        }

        [HttpPost("CadastrarProduto")]
        public IActionResult CadastrarProduto(Product produto)
        {
            try
            {
               var cadastrarProduto = _productService.CadastrarProduto(produto);
                return Ok("Produto Cadastrado com Sucesso");                
            }
            catch (Exception)
            {
                throw new Exception("Erro no Sistema, Favor Contactar o Adm");
            }
            
        }
    }
}
