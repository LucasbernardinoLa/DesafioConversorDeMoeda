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
                    Console.Write($"Moeda origem:  ");
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
                while (!(ValidaMoeda(value) && ChecaSeMoedaIgual(value)))
                {
                    Console.Write($"Moeda destino: ");
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
                while (!(ValidaValor(value) && ValorMaiorQueZero()))
                {
                    Console.Write($"valor: ");
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

        private bool ChecaSeMoedaIgual(string str)
        {
           if(str != MoedaOrigem)
           {
                return true;
           }
            Console.Clear();
            Console.WriteLine($"Error: a moeda origem: {MoedaOrigem} e  moeda destino " +
                              $"{str} são iguais.");
            return false;
        }

        private static bool ValidaMoeda(string moeda)
        {
            string padrao = "^[a-zA-Z]{3}$";

            if(Regex.IsMatch(moeda, padrao))
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine($"Error: a moeda {moeda} deve ter exatamente 3 caracteres alfabéticos.");
            return false;
        }

        private bool ValidaValor(string valor)
        {
           if (double.TryParse(valor, out double resultado))
           {
             ValorConvertido = resultado;
             return true;
           }
            Console.Clear();
            Console.WriteLine($"Erro de conversão: o valor {valor} não pode ser convertido.");
           return false;
        }

        private bool ValorMaiorQueZero()
        {
            if(ValorConvertido > 0)
            {
                return true;
            }
            Console.Clear();
            Console.WriteLine($"Erro de conversão: o valor {ValorConvertido} deve ser maior que zero.");
            return false;
           
        }
    }
}
