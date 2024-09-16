using AutoMapper;
using MeuRoboDados.Models;
using MeuRoboDominio.Response;

namespace MeuRobo.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CursosModel, CursosResponse>().ReverseMap();
        }
    }
}
