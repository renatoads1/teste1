using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuRoboNegocios.Interfaces
{
    public interface IExecutorRepository
    {
        List<string> Execute( string queryValue);
    }
}
