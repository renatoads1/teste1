using MeuRoboDominio.Response;

namespace MeuRoboDominio.Interfaces
{
    public interface ICursosRepository
    {
        bool SetCursos(List<string> cursos);
        List<CursosResponse> GetCursos();
    }
}
