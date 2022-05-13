using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
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
        [Fact]
        public void TestaObterTodosClientes()
        {
            //var a2 = Guid.NewGuid();
            //var a3 = Guid.NewGuid();
            //var a4 = Guid.NewGuid();
            //var a5 = Guid.NewGuid();
            //var a6 = Guid.NewGuid();
            //var a7 = Guid.NewGuid();

            //arrange
            var _respositorio = new ClienteRepositorio();

            //act
            List<Cliente> lista = _respositorio.ObterTodos();

            //assert
            Assert.NotNull(lista);
            Assert.Equal(2, lista.Count);
        }
    }
}
