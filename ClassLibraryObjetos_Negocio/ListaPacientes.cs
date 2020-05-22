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
    [Serializable]
    public class ListaPaciente
    {
        #region ATRIBUTOS
        Tratador tratador;
        static List<string> lst_pacientes;
        #endregion

        #region PROPRIEDADES

        public Tratador Tratador
        {
            set => tratador =value ; get => tratador;
        }

        /// <summary>
        /// Manipula o atributo "lst_pacientes" List<string> lst_paciente
        /// </summary>
        public List<string> Lst_Paciente
        {
            get { return lst_pacientes; }
            set { lst_pacientes = value; }
        }
        
        #region CONSTRUTORES


        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        public ListaPaciente(Tratador tratador,string nif)
        {
            this.Tratador = tratador;
            this.Lst_Paciente = new List<string>();
            lst_pacientes.Add(nif);
        }
        #endregion

        #endregion
    }
}
