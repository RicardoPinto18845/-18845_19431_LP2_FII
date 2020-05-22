using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryObjetos_Negocio
{
    interface IInfetado
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
        DateTime Data_Em_Que_Foi_Infetado
        {
            get;
            set;
        }


    }
}
