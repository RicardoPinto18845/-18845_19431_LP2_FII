
/*
 *  Users: Joao Ricardo / Joao Rodrigues
 *  <description>
 *                          Esta Classe serve para Gerir os Infetados 
 *                          -> Possui uma herança da biblioteca Pessoas
 *                          -> Ficheiro Binario da Classe Infetados
 * </description>
 *                                    
 * <number> 18845 / 19431 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19431@alunos.ipca.pt <email>
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Biblioteca Excecoes 
using System.Runtime.Serialization;
using System.Security;

// Biblioteca de Objetos
using Objetos_Negocio;

// Biblioteca de Pessoas
using Dados_Negocio_Pessoa;

// Bibliotecas de ficheiros
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Dados_Negocio_Infetados
{
    /// <summary>
    /// Classe que gere Infetados
    /// </summary>
    [Serializable]
    public class Infetados 
    {
        #region ATRIBUTOS
        const int MAX = 100;
        static List<Infetado> lst_infetado;
        #endregion

        #region METODOS

        #region CONSTRUTOR

        /// <summary>
        /// Construtor de Classe
        /// </summary>
        static Infetados()
        {
            lst_infetado = new List<Infetado>(MAX);
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
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s,lst_infetado);
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
                    lst_infetado = (List<Infetado>)b.Deserialize(s);
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

        #region List<Type> Generic 

        /// <summary>
        /// Insere Infetados.
        /// </summary>
        /// <param name="p"> Tipo Pessoa</param>
        /// <returns>
        /// "0" caso nao possa inserir mais elementos na lista ou caso ja exista essa Pessoa
        /// "1" caso consiga adicionar na lista a Pessoa
        /// </returns>
        public static int Insere_Infetados(Infetado p)
        {
            try
            {
                //Testar se está cheio
                if (lst_infetado.Count >= MAX) return 0;

                // Testar se ja existe essa pessoa
                if (lst_infetado.Contains(p))
                {
                    return 0;
                }

                // Insere o Infetado na lista de Pessoas
                // NOME / IDADE / NIF / GENERO / MORADA / MUNICIPIO / DATA.NASC
                Pessoa aux = new Pessoa(p.Nome, p.Idade, p.Cartao_Cidadao, p.Sexo, p.Morada, p.Municipio, p.DataNasc);
                Pessoas.Insere_Pessoas(aux);

                // Insere um Infetado
                lst_infetado.Add(p);

                return 1;
            }catch(Exception e)
            {
                Console.WriteLine("Erro: "+ e.Message);
            }
            return 0;
        }

        /// <summary>
        /// Mostrar ficha de um determinado Infetado.
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
                    foreach (Infetado pessoa in lst_infetado)
                    {
                        if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0 && pessoa.Ativo == true)
                        {
                            Console.WriteLine("\n===========================================================");
                            Console.WriteLine("\nNome: " + pessoa.Nome);
                            Console.WriteLine("\n-> Genero: " + pessoa.Sexo);
                            Console.WriteLine("\n-> Idade: " + pessoa.Idade);
                            Console.WriteLine("\n-> Nº Cartao Cidadao: " + pessoa.Cartao_Cidadao);
                            Console.WriteLine("\n-> Morada: " + pessoa.Morada);
                            Console.WriteLine("\n-> Data de Nascimento: " + pessoa.DataNasc);
                            Console.WriteLine("\n-> Data em que foi Infetado: " + pessoa.Data_Em_Que_Foi_Infetado);
                            Console.WriteLine("\n-> Municipio: " + pessoa.Municipio);
                            Console.WriteLine("\n-> Distrito: " + pessoa.Distrito);
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
        /// Pesquisa se existe esse Infetado caso exista retorna a sua ficha
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
                foreach (Infetado pessoa in lst_infetado)
                {
                    if (string.Compare(pessoa.Cartao_Cidadao, nif) == 0 && pessoa.Ativo == true)
                    {
                        return true;
                    }
                }
                return false;
            }catch(Exception e) 
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        /// <summary>
        /// Remove um Infetado.
        /// </summary>
        /// <param name="cartao">Cartao de Cidadao</param>
        /// <returns>
        /// "true" caso consiga remover
        /// "false" caso nao consiga remover o Infetado
        /// </returns>
        public static bool Remove_Infetado(string cartao,int numero)
        {
            try
            {
                if (Pesquisa_na_ficha(cartao) == false)
                {
                    return false;
                }
                else
                {
                    foreach (Infetado pessoa in lst_infetado)
                    {
                        if (string.Compare(pessoa.Cartao_Cidadao, cartao) == 0)
                        {
                            pessoa.Ativo = false;
                            if (numero == 1)
                            {
                                Curados.Insere_Curado(pessoa);
                            }

                            if (numero == 2)
                            {
                                Obitos.Insere_Obito(pessoa);
                            }
                        }
                    }
                }
                return true;
            }catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return false;
        }

        #endregion

        #endregion
    }
}
