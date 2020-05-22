/*
 *  Users: Joao Ricardo / Joao Rodrigues
 *  
 *                          Esta Interface serve de referencia para construcoes de outras Classes
 *                                    
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objetos_Negocio
{
    public interface IPessoa
    {
        string Municipio
        {
            get;
            set;
        }
 
        string Morada
        {
            get;
            set;
        }

        string Cartao_Cidadao
        {
            set;
            get;
        }

        string Sexo
        {
            get;
            set; 
        }

        int Idade
        {
            get;
            set;
        }

        string Nome
        {
            get;
            set;
        }

        DateTime DataNasc
        {
            get;
            set;
        }
    }
}
