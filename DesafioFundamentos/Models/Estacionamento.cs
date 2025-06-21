using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do carro no formato (XXX-1234): ");
            string placa = Console.ReadLine();
            placa = placa.ToUpper();

            // Regras para a placa
            string padrao = @"^[A-Z]{3}-\d{4}$";

            // Regex (impede simbolos, letras minusculas e formatos errados)
            if (Regex.IsMatch(placa, padrao))
            {
                Console.WriteLine("Carro registrado.");
            }
            else
            {
                Console.WriteLine("Placa inválida. Deve estar no formato XXX-1234 com letras maiúsculas.");
            }
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();
            
            // Verifica se a placa informada existe na lista, ignorando diferenças entre maiúsculas e minúsculas
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas;
                while (!int.TryParse(Console.ReadLine(), out horas) || horas < 0)
                {
                    Console.WriteLine("Valor inválido. Digite um número inteiro positivo para as horas: ");
                }

                decimal valorTotal = precoInicial + (precoPorHora * horas);

                veiculos.RemoveAll(x => x.ToUpper() == placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
