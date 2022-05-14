using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Infraestrutura.Testes.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Moq;
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

        [Fact]
        public void TestaInsereUmaNovaAgenciaNoBD()
        {
            //arrange
            string nome = "Agencia Guarapari";
            int numero = 125982;
            Guid identificador = Guid.NewGuid();
            string endereco = "Rua: 7 de setembro - centro";

            var agencia = new Agencia
            {
                Nome = nome,
                Identificador = identificador,
                Endereco = endereco,
                Numero = numero
            };

            //act 
            var retorno = _agenciaRepositorio.Adicionar(agencia);

            //assert
            Assert.True(retorno);
        }

        [Fact]
        public void TestaAtualizacaoInformacaoDeterminadaAgencia()
        {
            //arrange
            var agencia = _agenciaRepositorio.ObterPorId(9);
            var novoNome = "Agencia Nova";
            agencia.Nome = novoNome;

            //act
            var atualizado = _agenciaRepositorio.Atualizar(9, agencia);

            //assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaRemoverInformacaoDeterminadaAgencia()
        {
            //arrange
            //act
            var atualizado = _agenciaRepositorio.Excluir(11);

            //assert
            Assert.True(atualizado);
        }

        ////exceções
        //[Fact]
        //public void TestaExcecaoConsultaAgenciaPorId()
        //{
        //    Assert.Throws<FormatException>(
        //        () => _agenciaRepositorio.ObterPorId(30)
        //    );
        //}

        [Fact]
        public void TestaObterAgenciasMock()
        {
            //arrange
            var bytebankRepositorioMock = new Mock<IByteBankRepositorio>();
            var mock = bytebankRepositorioMock.Object;

            //act
            var lista = mock.BuscarAgencias();

            //assert
            //verifica se o comporta foi invocado no objeto
            bytebankRepositorioMock.Verify(b => b.BuscarAgencias());
        }
    }
}
