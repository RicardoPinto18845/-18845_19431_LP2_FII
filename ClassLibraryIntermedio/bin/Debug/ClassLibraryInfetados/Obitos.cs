/*
 *Users: Joao Ricardo / Joao Rodrigues
 * 
 * <description>
 *                          Esta Classe serve para Gerir os Obitos
 *                          -> Serve de auxiliar a Classe Infetados 
 *                          -> A sua utilizacao advem do uso da funcao remocao de infetados
 *                          -> A pessoa deixa de ser infetada para o "Estado" de obito 
 * </description>
 *                                    
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Biblioteca de Ficheiros
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

// Biblioteca de Objetos
using Objetos_Negocio;

// Biblioteca Excecoes 
using System.Runtime.Serialization;
using System.Security;

namespace Dados_Negocio_Infetados
{
    /// <summary>
    /// Classe que gere Obitos
    /// </summary>
    [Serializable]
    public static class Obitos
    {
        #region ATRIBUTOS
        const int Max = 100;
        static List<Infetado> lst_obito;
        #endregion

        #region CONSTRUTOR
        /// <summary>
        /// Construtor de Classe
        /// </summary>
        static Obitos()
        {
            lst_obito = new List<Infetado>(Max);
        }

        #endregion

        #region METODOS

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
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s, lst_obito);
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
                    lst_obito = (List<Infetado>)b.Deserialize(s);
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
        /// Insere Obitos.
        /// </summary>
        /// <param name="p"> Tipo Infetado </param>
        /// <returns>
        /// "0" caso nao possa inserir mais elementos na lista ou caso ja exista essa Pessoa
        /// "1" caso consiga adicionar na lista a Pessoa
        /// </returns>
        public static int Insere_Obito(Infetado p)
        {
            try
            {
                //Testar se está cheio
                if (lst_obito.Count >= Max) return 0;

                // Testar se ja existe essa pessoa
                if (lst_obito.Contains(p))
                {
                    return 0;
                }

                lst_obito.Add(p);
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return 0;
        }

        /// <summary>
        /// Mostrar ficha de um determinado Obito.
        /// </summary>
        /// <param name="nif">Cartao de Cidadao.</param>
        public static void Mostrar_ficha(string nif)
        {
            try
            {
                Infetado aux = Pesquisa_na_ficha(nif);
                if (aux == null)
                {
                    Console.Clear();
                    Console.WriteLine("Erro... nao encontrado !\n");
                }
                else
                {
                    Console.WriteLine("\n===========================================================");
                    Console.WriteLine("\nNome: " + aux.Nome);
                    Console.WriteLine("\n-> Genero: " + aux.Sexo);
                    Console.WriteLine("\n-> Idade: " + aux.Idade);
                    Console.WriteLine("\n-> Nº Cartao Cidadao: " + aux.Cartao_Cidadao);
                    Console.WriteLine("\n-> Morada: " + aux.Morada);
                    Console.WriteLine("\n-> Data de Nascimento: " + aux.DataNasc);
                    Console.WriteLine("\n-> Data da 1º Infecao: " + aux.Data_Em_Que_Foi_Infetado);
                    Console.WriteLine("\n-> Municipio: " + aux.Municipio);
                    Console.WriteLine("\n-> Municipio: " + aux.Distrito);
                    Console.WriteLine("\n===========================================================");
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

        /// <summary>
        /// Pesquisa se existe esse Obito caso exista retorna a sua ficha
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns>
        /// "Null" caso nao tenha encontrado o Infetado
        /// "pessoa"caso encontre
        /// </returns>
        private static Infetado Pesquisa_na_ficha(string nif)
        {
            try
            {
                foreach (Infetado pessoa in lst_obito)
                {
                    if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0)
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

        #endregion

        #endregion
    }
}
