using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infraestrutura.Testes
{
    public class ClienteRepositorioTestes
    {
        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();

            // vai estanciar um objeto que implementa a interface
            var provedor = servico.BuildServiceProvider();
            _clienteRepositorio = provedor.GetService<IClienteRepositorio>();
        }

        [Fact]
        public void TestaObterTodosClientes()
        {
            //arrange
            //act
            List<Cliente> lista = _clienteRepositorio.ObterTodos();

            //assert
            Assert.NotNull(lista);
            Assert.Equal(2, lista.Count);
        }

        [Fact]
        public void TestaObterClientePorId()
        {
            //arrange
            //act
            var cliente = _clienteRepositorio.ObterPorId(5);

            //assert
            Assert.NotNull(cliente);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(6)]
        public void TestaObterClientesPorVariosId(int id)
        {
            //arrange
            //act
            var cliente = _clienteRepositorio.ObterPorId(id);

            //assert
            Assert.NotNull(cliente);
        }


    }
}
