using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using ProductAPI.Entities.DTO;
using ProductAPI.Entities.Interfaces.Service;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Controllers
{
    [Route("Produtos")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IProductService _productService;

        public ProductController(IProductService productService,
            IConfiguration configuration )
        {
            _configuration = configuration;
            _productService = productService;
        }

        [HttpGet("BuscarProdutos")]
        public JsonResult BuscarProdutos()
        {
            MongoClient mongoDb = new MongoClient(_configuration.GetConnectionString("StoreDb"));
            var gettudo = mongoDb.GetDatabase("StoreDb").GetCollection<Product>("Product").AsQueryable();            
           
            return new JsonResult( gettudo);         
        }

        [HttpPost("CadastrarProduto")]
        public IActionResult CadastrarProduto(Product produto)
        {
            try
            {                
                MongoClient mongoDb = new MongoClient(_configuration.GetConnectionString("StoreDb"));
                int lastId = mongoDb.GetDatabase("StoreDb").GetCollection<Product>("Product").AsQueryable().Count();
                produto.ProductId = lastId + 1;                   
                mongoDb.GetDatabase("StoreDb").GetCollection<Product>("Product").InsertOne(produto);
                return Ok("Produto Cadastrado com Sucesso");                
            }
            catch (Exception)
            {
                throw new Exception("Erro no Sistema, Favor Contactar o Adm");
            }
            
        }
        [HttpPut("AtualizarProduto")]
        public JsonResult AtualizarProduto(Product produto)
        {
            try
            {
                MongoClient mongoDb = new MongoClient(_configuration.GetConnectionString("StoreDb"));
                var filter = Builders<Product>.Filter.Eq("ProductId", produto.ProductId);
                var update = Builders<Product>.Update.Set("ProductName", produto.ProductName);
                
                mongoDb.GetDatabase("StoreDb").GetCollection<Product>("Product").UpdateOne(filter, update);

                return new JsonResult("Atualizado com Sucesso");
            }
            catch (Exception)
            {
                throw new Exception("Erro no Sistema, Favor Contactar o Adm");
            }

        }

        [HttpDelete("DeletarProduto")]
        public JsonResult DeletarProduto(int id)
        {
            try
            {
                MongoClient mongoClient = new MongoClient(_configuration.GetConnectionString("StoreDb"));
                var deletaUmRegistro = mongoClient.GetDatabase("StoreDb").GetCollection<Product>("Product").DeleteOne(c => c.ProductId == id);
                return new JsonResult("Excluido com Sucesso");

            }
            catch (Exception)
            {
                throw new Exception("Erro no Sistema, Favor Contactar o Adm");
            }

        }
    }
}
