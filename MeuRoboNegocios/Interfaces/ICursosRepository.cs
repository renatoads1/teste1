using MeuRoboDominio.Response;

namespace MeuRoboDominio.Interfaces
{
    public interface ICursosRepository
    {
        bool SetCursos(List<CursosResponse> cursos);
        List<CursosResponse> GetCursos();
    }
}
