using Infraestrutura.Testes.Servicos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestrutura.Testes.Servicos
{
    public interface IPixRepositorio
    {
        public PixDTO consultaPix(Guid pix);
    }
}
