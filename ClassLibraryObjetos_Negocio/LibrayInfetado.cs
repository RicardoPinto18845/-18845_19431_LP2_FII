/*
 *  Users: Joao Ricardo / Joao Rodrigues
 *  <description>
 *                          Esta Classe serve para Gerir um Infetado
 *                          -> Herança da biblioteca Pessoas
 *                          -> Ficheiro Binario da Classe Infetados
 * </description>                                   
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Biblioteca que gere os Objetos de Negocio
using ClassLibraryObjetos_Negocio;

namespace Objetos_Negocio
{
    /// <summary>
    /// Classe que gere um Infetado
    /// </summary>
    /// <seealso cref="Objetos_Negocio.Pessoa" />
    /// <seealso cref="ClassLibraryObjetos_Negocio.IInfetado" />
    [Serializable]
    public class Infetado : Pessoa,IInfetado
    {
        #region ATRIBUTOS
        string distrito;
        DateTime data_Em_Que_Foi_Infetado;
        bool ativo;
        #endregion

        #region PROPRIEDADES

        // Métodos usados para manipular atributos do Estado

        /// <summary>
        /// Manipula o atributo "ativo" bool ativo
        /// </summary>
        public bool Ativo 
        {
            get { return ativo; }
            set { ativo = value; }
        }

        /// <summary>
        /// Manipula o atributo "distrito" string distrito;
        /// </summary>
        public string Distrito
        {
            get { return distrito; }
            set { distrito = value; }
        }

        /// <summary>
        /// Manipula o atributo "dataNasc" data_Em_Que_Foi_Infetado;
        /// </summary>
        public DateTime Data_Em_Que_Foi_Infetado
        {
            get { return data_Em_Que_Foi_Infetado; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    data_Em_Que_Foi_Infetado = value;
                }
            }
        }

        #endregion

        #region METODOS

        #region CONSTRUTOR

        // Métodos usados na criação de novos objectos

        /// <summary>
        /// Construtor por omissao
        /// </summary>
        public Infetado() : base()
        {
            this.distrito = "";
            this.data_Em_Que_Foi_Infetado = DateTime.Today;
            this.Ativo = true;
        }

        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        public Infetado(string nome, int idade, string cartao, string sexo, DateTime data, DateTime date, string dist, string mora, string municipi) : base(nome, idade, cartao, sexo, mora, municipi,data)
        {
            base.Nome = nome;
            base.Idade = idade;
            base.Cartao_Cidadao = cartao;
            base.Sexo = sexo;
            base.Morada = mora;
            base.Municipio = municipi;
            base.DataNasc = data;
            this.distrito = dist;
            this.data_Em_Que_Foi_Infetado = date;
            this.Ativo = true;
        }

        #endregion

        #endregion
    }
}
