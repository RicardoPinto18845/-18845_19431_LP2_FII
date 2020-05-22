/*
 *  Users: Joao Ricardo / Joao Rodrigues
 *  <description>
 *                          Esta Classe serve para Gerir um Tratador
 *                          -> Herança da biblioteca Pessoas
 *                          -> Ficheiro Binario da Classe Tratadores
 * </description>                                 
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Collections;

// Biblioteca que gere os Objetos de Negocio
using ClassLibraryObjetos_Negocio;

namespace Objetos_Negocio
{
    /// <summary>
    /// Classe que gere um Tratador
    /// </summary>
    /// <seealso cref="Objetos_Negocio.Pessoa" />
    [Serializable]
    public class Tratador : Pessoa, ITratador
    {
        #region ATRIBUTOS
        string distrito;
        bool ativo;
        static List<string> lst_pacientes;
        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Manipula o atributo "lst_pacientes" List<string> lst_paciente
        /// </summary>
        public List<string> Lst_Paciente
        {
            get { return lst_pacientes; }
            set { lst_pacientes = value; }
        }

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

        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor com valores por defeito/omissão
        /// </summary>
        public Tratador() : base()
        {
            this.Distrito = "";
            this.Ativo = true;
        }

        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        public Tratador(int idad, string name, string cartao_Cida_Tratador, string genero, string mora, string municipi, DateTime date
             , string distrit) : base(idad, name, cartao_Cida_Tratador, genero, mora, municipi, date)
        {
            base.Cartao_Cidadao = cartao_Cida_Tratador;
            base.Idade = idad;
            base.Nome = name;
            base.Sexo = genero;
            base.Morada = mora;
            base.Municipio = municipi;
            base.DataNasc = date;
            this.Distrito = distrit;
            this.Ativo = true;
        }
        #endregion

        #endregion
    }
}
