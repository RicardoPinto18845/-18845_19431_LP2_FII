/*
 *  Users: Joao Ricardo / Joao Rodrigues
 * <description>
 *                          Esta Classe serve para Gerir os Pacientes dos Tratadores
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

// Biblioteca Excecoes 
using System.Runtime.Serialization;
using System.Security;

// Biblioteca dos Ficheiros
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.CompilerServices;
using System.Net.Http;
using Objetos_Negocio;

namespace Dados_Negocio_Tratador
{
    /// <summary>
    /// Classe que gere a Lista de Pacientes
    /// </summary>
    [Serializable]
    public class Lista_Pacientes
    {
        #region ATRIBUTOS
        static List<ListaPaciente> listaPaciente;
        #endregion

        #region METODOS

        #region CONSTRUTORES

        /// <summary>
        /// Construtor de Classe
        /// </summary>
        static Lista_Pacientes()
        {
            listaPaciente = new List<ListaPaciente>(100);
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
        public static bool Save_Hash(string fileName)
        {
            try
            {
                Stream s = File.Open(fileName, FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(s,listaPaciente);
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
        public static bool Load_Hash(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Stream s = File.Open(fileName, FileMode.Open, FileAccess.Read);
                    BinaryFormatter b = new BinaryFormatter();
                    listaPaciente = (List<ListaPaciente>)b.Deserialize(s);
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

        #region HashTable

        /// <summary>
        /// Insere um Paciente
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <param name="nif_Paciente">The nif paciente.</param>
        /// <returns>
        /// "0" caso ja contenha esse Paciente ou ja nao possa conter mais Pacientes
        /// "1" caso tenha adicionado
        /// </returns>
        public static int Inserir_Paciente(ListaPaciente tratador,string nif_Paciente)
        {
            try
            {
                if (Tratadores.Pesquisa_na_ficha(tratador.Tratador.Cartao_Cidadao) == true)
                {
                    listaPaciente.Add(tratador);

                    if (tratador.Lst_Paciente.Contains(nif_Paciente) == true) return 0;

                    tratador.Lst_Paciente.Add(nif_Paciente);
                }
                else
                {
                    return 0;
                }
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return 0;
        }

        /// <summary>
        /// Mostra os Pacientes de um Tratador
        /// </summary>
        /// <param name="nif"> Tipo string </param>
        /// <returns>
        /// "0" caso nao consiga mostrar os Pacientes
        /// "1" caso consiga
        /// </returns>
        public static int Mostrar_Pacientes_DTratador(string nif)
        {
            try
            {
                int contador = 0;
                if (Tratadores.Pesquisa_na_ficha(nif) == false)
                {
                    Console.Clear();
                    Console.WriteLine("Erro... nao encontrado !\n");
                    return 0;
                }
                else
                {
                    foreach (ListaPaciente tratador in listaPaciente)
                    {
                        if (string.Compare(tratador.Tratador.Cartao_Cidadao,nif) == 0)
                        {
                            Console.WriteLine("\nTratador: {0}\n", tratador.Tratador.Nome);
                            foreach (string cartao in tratador.Lst_Paciente)
                            {
                                Console.WriteLine("-->{0}º Paciente: {1}\n",contador + 1,cartao);
                                contador++;
                            }
                            return 1;
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
            return 0;
        }
        #endregion

        #endregion
    }
}

