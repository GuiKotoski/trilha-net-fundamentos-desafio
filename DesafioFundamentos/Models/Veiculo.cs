using System;

namespace DesafioFundamentos.Models
{
    // Classe que representa um veículo estacionado
    public class Veiculo
    {
        // Propriedade para armazenar a placa do veículo
        public string Placa { get; set; }

        // Propriedade para armazenar a data e hora de entrada no estacionamento
        public DateTime HoraEntrada { get; set; }
    }
}
