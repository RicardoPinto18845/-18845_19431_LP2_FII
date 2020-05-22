/*
 *  Users: Joao Ricardo / Joao Rodrigues
 * <description>
 *                          Esta Classe serve para Gerir os Tratadores
 *                          -> Possui herança da biblioteca Pessoas
 *                          -> Ficheiro Binario da Classe Tratadores
 * </description>                                   
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Collections;

// Biblioteca Excecoes 
using System.Runtime.Serialization;
using System.Security;

// Biblioteca dos Ficheiros
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Biblioteca de Objetos
using Objetos_Negocio;

// Biblioteca de Pessoas
using Dados_Negocio_Pessoa;

namespace Dados_Negocio_Tratador
{
    /// <summary>
    /// Classe que gere Tratadores
    /// </summary>
    /// <seealso cref="Objetos_Negocio.Pessoa" />
    [Serializable]
    public class Tratadores : Pessoa
    {
        #region ATRIBUTOS
        const int Max_Tratadores = 100;
        static List<Tratador> lst_tratador;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor de Classe
        /// </summary>
        static Tratadores()
        {
            lst_tratador = new List<Tratador>(Max_Tratadores);
        }

        #endregion

        #region Ficheiros

        /// <summary>
        /// Guarda os dados num Ficherio Binario
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// "true" se conseguir guardar o ficheiro
        /// "false" caso nao consiga
        /// </returns>
        public static bool Save(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lst_tratador);
                s.Flush();
                s.Close();
                s.Dispose();
                return true;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro" + e.Message);
            }
            return true;
        }

        /// <summary>
        /// Carrega os dados guardados do Ficheiro
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>
        /// "true" caso consiga carregar o ficheiro
        /// "false" caso nao consiga
        /// </returns>
        public static bool Load(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                    BinaryFormatter b = new BinaryFormatter();
                    lst_tratador = (List<Tratador>)b.Deserialize(s);
                    s.Flush();
                    s.Close();
                    s.Dispose();
                    return true;
                }
            }
            catch (SecurityException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro" + e.Message);
            }
            return false;
        }

        #endregion

        #region List<Type> Generic Collection

        /// <summary>
        /// Insere Tratadores.
        /// </summary>
        /// <param name="p"> Tipo Tratador</param>
        /// <returns>
        /// "0" caso nao possa inserir mais elementos na lista ou caso ja exista essa Pessoa
        /// "1" caso consiga adicionar na lista a Pessoa
        /// </returns>
        public static int Insere_Tratador(Tratador p)
        {
            try
            {
                //Testar se está cheio
                if (lst_tratador.Count >= Max_Tratadores) return 0;

                // Testar se ja existe esse Tratador
                if (lst_tratador.Contains(p))
                {
                    return 0;
                }

                // Insere o Tratador na lista de Pessoas
                // NOME / IDADE / NIF / GENERO / MORADA / MUNICIPIO / DATA.NASC
                Pessoa aux = new Pessoa(p.Nome, p.Idade, p.Cartao_Cidadao, p.Sexo, p.Morada, p.Municipio, p.DataNasc);
                Pessoas.Insere_Pessoas(aux);

                lst_tratador.Add(p);

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return 1;
        }

        /// <summary>
        /// Mostrar ficha de um determinado Tratador.
        /// </summary>
        /// <param name="nif">Cartao de Cidadao.</param>
        public static void Mostrar_ficha(string nif)
        {
            try
            {
                if (Pesquisa_na_ficha(nif) == false)
                {
                    Console.Clear();
                    Console.WriteLine("Erro... nao encontrado !\n");
                }
                else
                {
                    foreach (Tratador pessoa in lst_tratador)
                    {
                        if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0)
                        {
                            Console.WriteLine("\n===========================================================");
                            Console.WriteLine("\nNome: " + pessoa.Nome);
                            Console.WriteLine("\n-> Genero: " + pessoa.Sexo);
                            Console.WriteLine("\n-> Idade: " + pessoa.Idade);
                            Console.WriteLine("\n-> Nº Cartao Cidadao: " + pessoa.Cartao_Cidadao);
                            Console.WriteLine("\n-> Morada: " + pessoa.Morada);
                            Console.WriteLine("\n-> Data de Nascimento: " + pessoa.DataNasc);
                            Console.WriteLine("\n-> Municipio: " + pessoa.Municipio);
                            Console.WriteLine("\n-> Municipio: " + pessoa.Distrito);
                            Console.WriteLine("\n===========================================================");
                        }
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Pesquisa se existe esse Tratador
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns>
        /// "true" caso encontre a ficha do Tratador
        /// "false" caso nao encontre
        /// </returns>
        public static bool Pesquisa_na_ficha(string nif)
        {
            try
            {
                foreach (Tratador pessoa in lst_tratador)
                {
                    if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0 && pessoa.Ativo == true)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Pesquisa se existe o Tratador e retorna a sua ficha 
        /// </summary>
        /// <param name="nif"></param>
        /// <returns>
        /// "pessoa" caso encontre a ficha do Tratador
        /// "null" caso nao encontre
        /// </returns>
        private static Tratador Pesquisa(string nif)
        {
            try
            {
                foreach (Tratador pessoa in lst_tratador)
                {
                    if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0 && pessoa.Ativo == true)
                    {
                        return pessoa;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return null;
        }

        /// <summary>
        /// Remove um Tratador.
        /// </summary>
        /// <param name="cartao">Cartao de Cidadao</param>
        /// <returns>
        /// "0" caso nao consiga remover um Tratador
        /// "1" caso consiga
        /// </returns>
        public static int Remove_Tratador(string cartao)
        {
            try
            {
                if (Pesquisa_na_ficha(cartao) == false)
                {
                    return 0;
                }
                else
                {
                    foreach (Tratador pessoa in lst_tratador)
                    {
                        if (string.Compare(pessoa.Cartao_Cidadao, cartao) == 0)
                        {
                            pessoa.Ativo = false;
                        }
                    }
                }
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return 0;
        }
        #endregion

        #endregion
    }
}
