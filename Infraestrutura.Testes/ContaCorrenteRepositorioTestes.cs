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

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //arrange
            var conta = _contaCorrenteRepositorio.ObterPorId(4);
            double novoSaldo = 15;
            conta.Saldo = novoSaldo;

            //act 
            var atualizado = _contaCorrenteRepositorio.Atualizar(4, conta);

            //assert
            Assert.True(atualizado);
        }

        [Fact]
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
        {
            //arrange
            var conta = new ContaCorrente
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente
                {
                    Nome = "Kent Nelso",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 5
                },
                Agencia = new Agencia
                {
                    Nome = "Agencia Central",
                    Identificador = Guid.NewGuid(),
                    Id = 9,
                    Endereco = "Rua das flores, 25",
                    Numero = 147
                }
            };

            //act
            var retorno = _contaCorrenteRepositorio.Adicionar(conta);

            //assert
            Assert.True(retorno);
        }
    }
}
