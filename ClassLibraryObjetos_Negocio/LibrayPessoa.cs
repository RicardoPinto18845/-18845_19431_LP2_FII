/*
 *  Users: Joao Ricardo / Joao Rodrigues
 *  <description>
 *                          Esta Classe serve para Gerir uma Pessoa 
 *                          -> Interface de IPessoa
 *                          -> Ficheiro Binario da Classe Pessoas
 * </description>                                   
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections;
using System.Collections.Generic;   

namespace Objetos_Negocio
{
    /// <summary>
    /// Classe que gere uma Pessoa
    /// </summary>
    /// <seealso cref="Objetos_Negocio.IPessoa" />
    [Serializable]
    public class Pessoa : IPessoa
    {
        #region ESTADO
        string sexo;
        int idade;
        string cartao_Cidadao;
        string nome;
        string morada;
        DateTime dataNasc;
        string municipio;
        #endregion

        #region PROPRIEDADES

        // Métodos usados para manipular atributos do Estado

        /// <summary>
        /// Manipula o atributo "municipio" string municipio
        /// </summary>
        public string Municipio
        {
            get => municipio;
            set { municipio = value; }
        }

        /// <summary>
        /// Manipula o atributo "morada" string morada
        /// </summary>
        public string Morada
        {
            get { return morada; }
            set { morada = value; }
        }

        /// <summary>
        /// Manipula o atributo "cartao_Cidadao" string cartao_Cidadao;
        /// </summary>
        /// <value>
        /// The cartao cidadao.
        /// </value>
        public string Cartao_Cidadao
        {
            set
            {
                // Contabilizar os caracteres
                int lengt = value.Length;

                if (lengt == 8)
                {
                    cartao_Cidadao = value;
                }
                else
                {
                    cartao_Cidadao = "00000000";
                }
            }
            get { return cartao_Cidadao; }
        }

        /// <summary>
        /// Manipula o atributo "sexo" string sexo;
        /// </summary>
        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        /// <summary>
        /// Manipula o atributo "idade"
        /// int idade;
        /// </summary>
        public int Idade
        {
            get => idade;
            set
            {
                if (value <= 0 || value >= 122)
                {
                    idade = 0;
                }
                else
                {
                    idade = value;
                }
            }
        }

        /// <summary>
        /// Manipula o atributo "nome"
        /// string nome;
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Manipula o atributo "dataNasc" DateTime dataNasc;
        /// </summary>
        public DateTime DataNasc
        {
            get { return dataNasc; }
            set
            {
                try
                {
                    DateTime aux;
                    if (DateTime.TryParse(value.ToString(), out aux) == true)
                    {
                        dataNasc = value;
                    }
                    else
                    {
                        dataNasc = DateTime.Today;
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro: " + e.Message);
                }
            }
        }
        #endregion

        #region METODOS

        #region CONSTRUTORES

        // Métodos usados na criação de novos objectos

        /// <summary>
        /// Construtor por omissao
        /// </summary>
        public Pessoa()
        {
            this.Nome = "";
            this.Cartao_Cidadao = "00000000";
            this.idade = -1;
            this.morada = "";
            this.Municipio = "";
            this.sexo = "";
            this.dataNasc = DateTime.Today;
        }


        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        /// <param name="i">Idade da Pessoa</param>
        /// <param name="n">Nome da Pessoa</param>
        public Pessoa(int i, string n, string cartao_Cida, string sex, string mora, string municipi, DateTime date)
        {
            cartao_Cidadao = cartao_Cida;
            idade = i;
            nome = n;
            sexo = sex;
            morada = mora;
            municipio = municipi;
            dataNasc = date;
        }

        /// <summary>
        /// Construtor com dados vindos do exterior
        /// </summary>
        /// <param name="nome">Nome da Pessoa</param>
        /// <param name="idade">Idade da Pessoa</param>
        public Pessoa(string nome, int idade, string cartao_Cida, string sexo, string mora, string municipi, DateTime date)
        {
            this.idade = idade;
            this.nome = nome;
            this.cartao_Cidadao = cartao_Cida;
            this.sexo = sexo;
            this.morada = mora;
            this.municipio = municipi;
            this.DataNasc = date;
        }

        #endregion

        #endregion
    }
}