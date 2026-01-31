using System;
using System.Globalization;
using System.Linq;

namespace CrudPaises.Utils
{
    public static class InputHelp
    {
        public static int LerInt(string label)
        {
            while (true)
            {
                Console.Write(label);
                var txt = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(txt, out var valor))
                    return valor;

                Console.WriteLine("Somente número inteiro.");
            }
        }

        public static long LerLong(string label)
        {
            while (true)
            {
                Console.Write(label);
                var txt = (Console.ReadLine() ?? "").Trim();

                if (long.TryParse(txt, out var valor))
                    return valor;

                Console.WriteLine("Somente número inteiro.");
            }
        }

        public static double LerDouble(string label)
        {
            while (true)
            {
                Console.Write(label);
                var txt = (Console.ReadLine() ?? "").Trim().Replace(',', '.');

                if (double.TryParse(txt, NumberStyles.Any, CultureInfo.InvariantCulture, out var valor))
                    return valor;

                Console.WriteLine("Somente números inteiros e decimais");
            }
        }

        // somente caracteres válidos em nomes de países
        public static string LerNomePais(string label)
        {
            while (true)
            {
                Console.Write(label);
                var nome = (Console.ReadLine() ?? "").Trim();

                if (string.IsNullOrWhiteSpace(nome))
                {
                    Console.WriteLine("Nome vazio.");
                    continue;
                }

                bool ok = nome.All(c =>
                    char.IsLetter(c) || c == ' ' || c == '-' || c == '\'');

                if (!ok)
                {
                    Console.WriteLine("Nome inválido, somente caracteres.");
                    continue;
                }

                // nome muito curto
                if (nome.Length < 2)
                {
                    Console.WriteLine("Nome inválido por ser curto.");
                    continue;
                }

                return nome;
            }
        }

        public static string LerOpcionalNumero(string label)
        {
            Console.Write(label);
            return (Console.ReadLine() ?? "").Trim().Replace(',', '.');
        }

        public static void Pausa()
        {
            Console.WriteLine();
            //Console.Write("Pressione [ENTER]");
            Console.ReadKey();
        }
    }
}
