using MeuRoboDados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRoboDominio.Interfaces
{
    public interface ICursosRepository
    {
        bool SetCursos(List<String> cursos);
        List<CursosModel> GetCursos();
    }
}
