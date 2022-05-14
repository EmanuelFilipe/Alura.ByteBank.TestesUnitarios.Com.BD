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

        [Fact]
        public void TestaInserirNovoClienteNoBD()
        {
            //arrange
            var identificador = Guid.NewGuid();

            var cliente = new Cliente
            {
                Nome = "Filipe Silva",
                CPF = "075.534.746-30",
                Profissao = "Developer",
                Identificador = identificador,
            };

            //act
            var retorno = _clienteRepositorio.Adicionar(cliente);

            //assert
            Assert.True(retorno);
        }

        [Fact]
        public void TesteAtualizarDeterminadaInformacaoDoCliente()
        {
            //arrange
            var cliente = _clienteRepositorio.ObterPorId(7);
            string novaProfissao = "Analista De Sistemas Sênior";
            cliente.Profissao = novaProfissao;

            //act
            var atualizado = _clienteRepositorio.Atualizar(7, cliente);

            //assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //arrange
            //act
            var atualizado = _clienteRepositorio.Excluir(7);

            //assert
            Assert.True(atualizado);
        }
    }
}
