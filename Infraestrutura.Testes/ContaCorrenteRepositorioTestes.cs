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
    public class ContaCorrenteRepositorioTestes
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public ContaCorrenteRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _contaCorrenteRepositorio = provedor.GetService<IContaCorrenteRepositorio>();
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            List<ContaCorrente> lista = _contaCorrenteRepositorio.ObterTodos();

            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            var agencia = _contaCorrenteRepositorio.ObterPorId(4);
            Assert.NotNull(agencia);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        public void TestaObterAgenciaPorVariosId(int id)
        {
            var agencia = _contaCorrenteRepositorio.ObterPorId(id);
            Assert.NotNull(agencia);
        }


    }
}
