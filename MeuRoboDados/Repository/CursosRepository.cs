using MeuRoboDados.Contexto;
using MeuRoboDados.Models;
using MeuRoboDominio.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace MeuRoboDados.Repository
{
    public class CursosRepository : ICursosRepository
    {
        private readonly CursosDBContext _context;

        public CursosRepository()
        {
        }

        public CursosRepository(CursosDBContext context)
        {
            _context = context;
        }

        public bool SetCursos(List<string> cursos)
        {
            try {
                foreach (var cur in cursos) {
                    CursosModel cursosnew = new CursosModel();
                    cursosnew.Professor = "Teste";
                    cursosnew.Descricao = "Teste";
                    cursosnew.CargaHoraria = "Teste";
                    cursosnew.Titulo = cur;
                    _context.curso.Add(cursosnew);
                   
                }
                _context.SaveChanges(true);
                return true;
            } catch (Exception ex) {
                Console.WriteLine($"Erro ao salvar os dados: {ex.Message}");
                return false;
            }
              
        }
    }
}
