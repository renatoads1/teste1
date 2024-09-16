using AutoMapper;
using MeuRoboDados.Contexto;
using MeuRoboDados.Models;
using MeuRoboDominio.Interfaces;
using MeuRoboDominio.Response;



namespace MeuRoboDados.Repository
{
    public class CursosRepository : ICursosRepository
    {
        private readonly CursosDBContext _context;
        private readonly IMapper _mapper;

        public CursosRepository()
        {
        }

        public CursosRepository(CursosDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<CursosResponse> GetCursos() { 
        
            var cursos = _context.curso.ToList();
            //mapper aqui
            var cursosresp = _mapper.Map<List<CursosResponse>>(cursos);
            return cursosresp;
        }

        public bool SetCursos(List<CursosResponse> cursos)
        {
            try {
                foreach (var cur in cursos) {
                    CursosModel cursosnew = new CursosModel();
                    cursosnew.Professor = cur.Professor;
                    cursosnew.Descricao = cur.Descricao;
                    cursosnew.CargaHoraria = cur.CargaHoraria;
                    cursosnew.Titulo = cur.Titulo;
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
