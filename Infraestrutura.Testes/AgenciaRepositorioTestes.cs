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
    public class AgenciaRepositorioTestes
    {
        private readonly IAgenciaRepositorio _agenciaRepositorio;

        public AgenciaRepositorioTestes()
        {
            var servico = new ServiceCollection();
            servico.AddTransient<IAgenciaRepositorio, AgenciaRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _agenciaRepositorio = provedor.GetService<IAgenciaRepositorio>();
        }

        [Fact]
        public void TestaObterTodasAgencias()
        {
            List<Agencia> lista = _agenciaRepositorio.ObterTodos();

            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterAgenciaPorId()
        {
            var agencia = _agenciaRepositorio.ObterPorId(9);
            Assert.NotNull(agencia);
        }

        [Theory]
        [InlineData(9)]
        [InlineData(10)]
        public void TestaObterAgenciaPorVariosId(int id)
        {
            var agencia = _agenciaRepositorio.ObterPorId(id);
            Assert.NotNull(agencia);
        }
    }
}
