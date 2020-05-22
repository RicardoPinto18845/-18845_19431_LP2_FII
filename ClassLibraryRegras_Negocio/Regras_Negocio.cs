using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Biblioteca que gere Objetos
using Objetos_Negocio;
// Biblioteca que gere Dados
using Dados_Negocio;

namespace Regras_Negocio
{
    public class Regras_Negocio
    {
        #region Classe Pessoas

        /// <summary>
        /// Carrega os dados guardados relativos a Pessoas
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Load_Pessoas(string filename)
        {
            try
            {
                Pessoas.Load(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;

        }

        /// <summary>
        /// Insere uma Pessoa
        /// </summary>
        /// <param name="pessoa">The pessoa.</param>
        /// <returns></returns>
        public static bool Insere_Pessoa(Pessoa pessoa)
        {
            try
            {
                Pessoas.Insere_Pessoas(pessoa);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Mostrar a ficha de uma Pessoa
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns></returns>
        public static bool Mostrar_ficha_Pessoa(string nif)
        {
            try
            {
                Pessoas.Mostrar_ficha(nif);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Guardar em Ficheiros os dados
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Save_Pessoas(string filename)
        {
            try
            {
                Pessoas.Save(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;
        }
        #endregion

        #region Classe Infetados

        /// <summary>
        /// Carrega os dados de um Infetado
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Load_Infetados(string filename)
        {
            try
            {
                Infetados.Load(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;

        }

        /// <summary>
        /// Insere um Infetado.
        /// </summary>
        /// <param name="infetado">The infetado.</param>
        /// <returns></returns>
        public static bool Insere_Infetado(Infetado infetado)
        {
            try
            {
                Infetados.Insere_Infetados(infetado);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Mostra a ficha de um Infetado
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool Mostrar_ficha_Infetado(string nif)
        {
            try
            {
                Infetados.Mostrar_ficha(nif);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Remove um Infetado
        /// </summary>
        /// <param name="nif"></param>
        /// <returns></returns>
        public static bool Remove_Infetado(string nif, int numero)
        {
            try
            {
                Infetados.Remove_Infetado(nif, numero);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Guarda os dados de Infetados
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Save_Infetados(string filename)
        {
            try
            {
                Infetados.Save(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;
        }
        #endregion

        #region Classe Tratadores

        /// <summary>
        /// Carrega os dados de um Tratador
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Load_Tratadores(string filename)
        {
            try
            {
                Tratadores.Load(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;

        }

        /// <summary>
        /// Insere Tratador
        /// </summary>
        /// <param name="tratador">The infetado.</param>
        /// <returns></returns>
        public static bool Insere_Tratador(Tratador tratador)
        {
            try
            {
                Tratadores.Insere_Tratador(tratador);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Insere Pacientes num determinado Tratador.
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <param name="cartao_Paciente">The cartao paciente.</param>
        /// <returns></returns>
        public static bool Insere_Pacientes_Num_Tratador(string nif, string cartao_Paciente)
        {
            try
            {
                Tratadores.Criar_Pacientes_num_Tratador(nif, cartao_Paciente);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Mostra a ficha de um Tratador.
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns></returns>
        public static bool Mostrar_ficha_Tratador(string nif)
        {
            try
            {
                Tratadores.Mostrar_ficha(nif);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Mostrar Pacientes de um Tratador
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns></returns>
        public static bool Mostrar_Pacientes_Num_Tratador(string nif)
        {
            try
            {
                Tratadores.Mostrar_Pacientes_DTratador(nif);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Remove um Tratador
        /// </summary>
        /// <param name="nif">The nif.</param>
        /// <returns></returns>
        public static bool Remove_Tratador(string nif)
        {
            try
            {
                Tratadores.Remove_Tratador(nif);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return false;
        }

        /// <summary>
        /// Guarda os dados de um Tratador
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns></returns>
        public static bool Save_Tratadores(string filename)
        {
            try
            {
                Tratadores.Save(filename);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro:" + e.Message);
            }

            return false;
        }
        #endregion
    }
}

