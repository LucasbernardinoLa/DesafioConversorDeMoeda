using System.Text.RegularExpressions;

namespace DesafioConversorDeMoeda
{
    public class ValidadorDados
    {
        private string _moedaOrigem;
        public string MoedaOrigem
        {
            get
            {
                return _moedaOrigem;
            }
            set
            {
                while (!ValidaMoeda(value))
                {
                    Console.Write($"o valor digitado {value} é inválido, digite um novo valor de moeda Origem:  ");
                    Console.WriteLine();
                    value = Console.ReadLine();
                }
                _moedaOrigem = value;
            }
        }

        private string _moedaDestino;
        public string MoedaDestino
        {
            get
            {
                return _moedaDestino;
            }
            set
            {
                while (!ValidaMoeda(value))
                {
                    Console.Write($"o valor digitado {value} é inválido, digite um novo valor de moeda Destino:  ");
                    Console.WriteLine();
                    value = Console.ReadLine();
                }
                _moedaDestino = value;
            }
        }
        private string _valor;
        public string Valor
        {
            get
            {
                return _valor;
            }
            set
            {
                while (!ValidaValor(value) || ValorConvertido <= 0)
                {
                    Console.Write($"o valor digitado {value} é inválido, digite um novo valor:  ");
                    Console.WriteLine();
                    value = Console.ReadLine();
                }
                _valor = value;
            }
        }
        public double ValorConvertido { get; private set; }

        public ValidadorDados(string moedaOrigem, string moedaDestino, string valor)
        {
            MoedaOrigem = moedaOrigem;
            MoedaDestino = moedaDestino;
            Valor = valor;
        }

        private bool ValidaMoeda(string moeda)
        {
            string padrao = "^[a-zA-Z]{3}$";

            return Regex.IsMatch(moeda, padrao);
        }

        private bool ValidaValor(string valor)
        {
           if (double.TryParse(valor, out double resultado))
           {
             ValorConvertido = resultado;
             return true;
           }
           return false;
        }


    }
}
