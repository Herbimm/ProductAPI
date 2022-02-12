using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Controllers
{
    [Route("Clientes")]
    [ApiController]
    public class ProductController : ControllerBase
    {    

        [HttpGet("BuscarCliente")]
        public Cliente BuscarCliente(int numeroDeIndentificacao)
        {
            List<Cliente> listaCliente = new List<Cliente>();
            // PROCURA O CLIENTE E O RETORNA NA TELA
            Cliente primeiroCliente = new Cliente();
            Cliente segundoCliente = new Cliente();
            
            primeiroCliente.Nome = "Herbert";
            primeiroCliente.Id = 1;
            primeiroCliente.CPF = "117.641.252-84";
            primeiroCliente.EnderecoCompleto = "Morro do papagaio";

            segundoCliente.Nome = "Adriano";
            segundoCliente.Id = 2;

            listaCliente.Add(primeiroCliente);
            listaCliente.Add(segundoCliente);

            var buscarClientePorId = listaCliente.FirstOrDefault(c => c.Id == numeroDeIndentificacao);           

            return buscarClientePorId;            
        }

        [HttpPost("CadastrarCliente")]
        public IActionResult CadastrarCliente(Cliente cliente)
        {
            
            // CADASTRO DO CLIENTE NO BANCO E RETORNO DA MENSAGEM DE SUCESSO
            return Ok($"Cliente CPF {cliente.CPF} Cadastrado com Sucesso");
        }
    }
}
