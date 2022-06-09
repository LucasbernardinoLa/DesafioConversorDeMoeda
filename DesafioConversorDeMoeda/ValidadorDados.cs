

using System.Text.RegularExpressions;

namespace DesafioConversorDeMoeda
{
    public class ValidadorDados
    {
        public string MoedaOrigem { get; private set; }
        public string MoedaDestino { get; private set; }
        public string Valor { get; private set; }
        public double ValorConvertido { get; private set; }

        public ValidadorDados(string moedaOrigem, string moedaDestino, string valor)
        {
            MoedaOrigem = moedaOrigem;
            MoedaDestino = moedaDestino;
            Valor = valor;
            ChecaDados();
        }

        private void ChecaDados()
        {
            if (!ValidaString(MoedaOrigem))
            {
                Console.WriteLine("Moeda de origem deve ter exatamente 3 caracteres.");
            }
            if (!ValidaString(MoedaDestino))
            {
                Console.WriteLine("Moeda de destino deve ter exatamente 3 caracteres.");
            }
            if (!ValidaValor(Valor) && ValorConvertido <= 0)
            {
                Console.WriteLine("Valor inválido!");
            }

        }

        private bool ValidaString(string str)
        {
            string padrao = "^[a-zA-Z]{3}$";

            return Regex.IsMatch(str, padrao);
        }

        private bool ValidaValor(string valor)
        {
          if(double.TryParse(valor, out double resultado))
            {
                ValorConvertido = resultado;
                return true;
            }
            return false;
        }


    }
}
