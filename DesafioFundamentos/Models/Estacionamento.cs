using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        // Preços definidos no momento da criação do objeto
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;

        // Lista de veículos estacionados, contendo a placa e a hora de entrada
        private List<Veiculo> veiculos = new List<Veiculo>();

        // Construtor recebe os preços informados no Program
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        // Método para adicionar um veículo
        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do carro no formato (XXX-1234): ");
            string placa = Console.ReadLine().ToUpper();

            // Expressão regular para validar o formato da placa
            string padrao = @"^[A-Z]{3}-\d{4}$";

            if (Regex.IsMatch(placa, padrao))
            {
                // Verifica se já existe essa placa cadastrada (evita duplicatas)
                if (veiculos.Any(v => v.Placa == placa))
                {
                    Console.WriteLine("Este veículo já está registrado.");
                    return;
                }

                // Adiciona o veículo com a hora de entrada atual
                veiculos.Add(new Veiculo { Placa = placa, HoraEntrada = DateTime.Now });
                Console.WriteLine($"Veículo registrado com sucesso. Entrada às {DateTime.Now:HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Placa inválida. Deve estar no formato XXX-1234 com letras maiúsculas.");
            }
        }

        // Método para remover um veículo
        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            // Procura o veículo na lista pelo número da placa
            var veiculo = veiculos.FirstOrDefault(v => v.Placa == placa);

            if (veiculo != null)
            {
                // Calcula o tempo de permanência com base na hora atual e na hora de entrada
                DateTime saida = DateTime.Now;
                TimeSpan tempo = saida - veiculo.HoraEntrada;

                // Arredonda para cima as horas (cobra hora cheia mesmo que seja fração)
                decimal horas = (decimal)Math.Ceiling(tempo.TotalHours);

                // Calcula o valor total a pagar
                decimal valorTotal = precoInicial + (precoPorHora * horas);

                // Remove o veículo da lista
                veiculos.Remove(veiculo);

                Console.WriteLine($"Veículo {placa} removido.");
                Console.WriteLine($"Tempo estacionado: {horas} hora(s).");
                Console.WriteLine($"Valor total a pagar: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine("Veículo não encontrado. Verifique se a placa foi digitada corretamente.");
            }
        }

        // Método para listar todos os veículos atualmente estacionados
        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Veículos atualmente estacionados:");
                foreach (var v in veiculos)
                {
                    Console.WriteLine($"Placa: {v.Placa} | Entrada: {v.HoraEntrada:HH:mm:ss}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados no momento.");
            }
        }
    }
}
