using Alura.ByteBank.Dados.Contexto;
using System;
using Xunit;

namespace Infraestrutura.Testes
{ 
    public class ByteBankContextoTestes
    {
        [Fact]
        public void TestaConexaoComDBSql()
        {
            var contexto = new ByteBankContexto();
            bool conectado;

            try
            {
                conectado = contexto.Database.CanConnect();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar a base de dados.");
            }

            Assert.True(conectado);
        }
    }
}
