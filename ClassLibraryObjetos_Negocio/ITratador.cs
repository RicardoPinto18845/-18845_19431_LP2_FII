using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryObjetos_Negocio
{
    interface ITratador
    {
        bool Ativo
        {
            get;
            set;
        }
        string Distrito
        {
            get;
            set;
        }
    }
}
