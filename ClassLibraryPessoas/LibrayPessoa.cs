/*
 *  Users: Joao Ricardo / Joao Rodrigues
 * <description> 
 *                          Esta Classe serve para Gerir as Pessoas 
 *                          -> Ficheiro Binario da Classe Pessoas
 *  </description>                                  
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections;
using System.Collections.Generic;

// Biblioteca Excecoes 
using System.Runtime.Serialization;
using System.Security;

// Bibliotecas de ficheiros
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

// Biblioteca de Objetos
using Objetos_Negocio;

namespace Dados_Negocio_Pessoa
{
    /// <summary>
    /// Classe que gere Pessoas
    /// </summary>
    [Serializable]
    public static class Pessoas
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static List<Pessoa> lst_pessoa;
        #endregion

        #region METODOS

        #region CONST

        /// <summary>
        /// Construtor de classe
        /// </summary>
        static Pessoas()
        {
            lst_pessoa = new List<Pessoa>(MAX);
        }
        #endregion

        #region FICHEIROS

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
                b.Serialize(s, lst_pessoa);
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
            return false;
        }

        /// <summary>
        /// Carrega os dados guardados no Ficheiro
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
                    lst_pessoa = (List<Pessoa>)b.Deserialize(s);
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
        /// Insere pessoas.
        /// </summary>
        /// <param name="p"> Tipo Pessoa</param>
        /// <returns>
        /// "0" caso nao possa inserir mais elementos na lista ou caso ja exista essa Pessoa
        /// "1" caso consiga adicionar na lista a Pessoa
        /// </returns>
        public static int Insere_Pessoas(Pessoa p)
        {
            try
            {
                //Testar se está cheio
                if (lst_pessoa.Count >= MAX) return 0;

                // Testar se ja existe essa pessoa
                if (lst_pessoa.Contains(p))
                {
                    return 0;
                }

                lst_pessoa.Add(p);

                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return 1;
        }

        /// <summary>
        /// Mostrar ficha de uma determinada Pessoa.
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
                    foreach (Pessoa pessoa in lst_pessoa)
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
                            Console.WriteLine("\n===========================================================");
                            break;
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
        /// Pesquisa se existe essa Pessoa caso exista retorna a sua ficha
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns>
        /// "true" caso encontre a ficha do Infetado
        /// "false" caso nao encontre
        /// </returns>
        private static bool Pesquisa_na_ficha(string nif)
        {
            try
            {
                foreach (Pessoa pessoa in lst_pessoa)
                {
                    if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: "+ e.Message);
            }
            return false;
        }

        #endregion

        #endregion
    }
}