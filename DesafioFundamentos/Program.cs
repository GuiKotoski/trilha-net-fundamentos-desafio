using DesafioFundamentos.Models;

// Configura o console para suportar acentuação (importante no Windows)
Console.OutputEncoding = System.Text.Encoding.UTF8;

// Saudação e explicação inicial ao usuário
Console.WriteLine("=========================================");
Console.WriteLine(" BEM-VINDO AO SISTEMA DE ESTACIONAMENTO ");
Console.WriteLine("=========================================");
Console.WriteLine();
Console.WriteLine("Como funciona:");
Console.WriteLine("- Ao cadastrar o veículo, o sistema registra automaticamente a hora de entrada.");
Console.WriteLine("- Na remoção, o sistema calcula o tempo real de permanência com base na entrada.");
Console.WriteLine("- A cobrança é feita assim:");
Console.WriteLine("    Valor Total = Valor Inicial + (Horas * Valor por Hora)");
Console.WriteLine();
Console.WriteLine("Agora vamos configurar os preços.");
Console.WriteLine();

// Declaração das variáveis de preços
decimal precoInicial;
decimal precoPorHora;

// Validação do preço inicial
while (true)
{
    Console.Write("Digite o preço inicial (maior que 0): ");
    if (decimal.TryParse(Console.ReadLine(), out precoInicial) && precoInicial > 0)
        break; // Entrada válida, sai do loop
    else
        Console.WriteLine("Valor inválido. Digite um número maior que 0.");
}

// Validação do preço por hora
while (true)
{
    Console.Write("Digite o preço por hora (maior que 0): ");
    if (decimal.TryParse(Console.ReadLine(), out precoPorHora) && precoPorHora > 0)
        break; // Entrada válida, sai do loop
    else
        Console.WriteLine("Valor inválido. Digite um número maior que 0.");
}

// Cria o objeto Estacionamento passando os preços informados
Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora);

// Variável para controle do menu
string opcao;

// Início do loop principal do menu
do
{
    // Limpa a tela a cada iteração
    Console.Clear();

    // Exibe o menu de opções
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar programa");

    // Lê a opção escolhida
    opcao = Console.ReadLine();

    // Estrutura de controle de fluxo com base na opção
    switch (opcao)
    {
        case "1":
            estacionamento.AdicionarVeiculo();  // Cadastra o veículo e registra a hora de entrada
            break;

        case "2":
            estacionamento.RemoverVeiculo();    // Calcula o tempo real e remove o veículo
            break;

        case "3":
            estacionamento.ListarVeiculos();    // Exibe todos os veículos atualmente estacionados
            break;

        case "4":
            Console.WriteLine("Encerrando o programa...");
            break;

        default:
            Console.WriteLine("Opção inválida."); // Caso o usuário digite algo fora das opções
            break;
    }

    // Pausa entre as operações, exceto ao sair
    if (opcao != "4")
    {
        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }

} while (opcao != "4"); // Enquanto a opção for diferente de 4, continua o loop
