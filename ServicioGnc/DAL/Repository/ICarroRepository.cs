using ServicioGnc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioGnc.DAL.Repository
{
    public interface ICarroRepository:IGenericRepository<Carro>
    {
        List<Carro> GetByTipoOperacion(int TipoOperacionId);

        List<Carro> GetByTipoOperacionUsuario(int TipoOperacionId, int UsuarioId);
    }
}
