using System.Runtime.ConstrainedExecution;
using ConversorDeMoedas;

List<Moeda> moedas = new List<Moeda>();

IniciarPrograma();

void IniciarPrograma()
{
    bool sair = false;
    while (!sair)
    {
        Console.Clear();
        Console.WriteLine("### MENU DE MOEDAS ###\n");
        Console.WriteLine("1- Listar Moedas");
        Console.WriteLine("2 - Adicionar Moedas");
        Console.WriteLine("3 - Converter Moedas");
        Console.WriteLine("4 - SAIR\n");
        Console.WriteLine("Digite uma das opções...");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                ListarMoedas();
                break;
            case "2":
                AdicionarMoedas();
                break;
            case "3":
                ConverterMoedas();
                break;
            case "4":
                sair = true;
                Console.Clear();
                Console.WriteLine("Saindo da aplicação...");
                break;
            default:
                Console.WriteLine("Opção inválida!\nDigite qualquer tecla para retornar ao menu...");
                break;
        }
        Console.ReadLine();
    }
}

void ListarMoedas()
{
    Console.Clear();
    Console.WriteLine("### LISTAGEM DE MOEDAS ###\n");

    if (moedas.Count == 0)
    {
        Console.WriteLine("Não há moedas Cadastradas!\n");
        Console.WriteLine("Digite qualquer tecla para retornar ao Menu...");
    }
    else
    {
        Console.WriteLine("---------------------");

        for (int i = 0; i < moedas.Count; i++)
        {
            Console.WriteLine($"{i}- {moedas[i].Nome} {moedas[i].Cotacao}\n");
            Console.WriteLine("---------------------\n");
        }
    }
}

void AdicionarMoedas()
{
    Console.Clear();
    bool adicao = false;
    while (!adicao)
    {
        Console.WriteLine("### ADIÇÃO DE MOEDAS ###\n");

        Console.Write("Digite o nome da moeda com o símbolo [Nome($)]: ");
        string novoNome = Console.ReadLine();

        Console.Write("\nDigite a cotação da moeda: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal novaCotacao) || novaCotacao <= 0)
        {
            Console.Clear();
            Console.WriteLine("Valor inválido!\n");
            Console.ReadKey();
        }
        else
        {
            moedas.Add(new Moeda() { Nome = novoNome, Cotacao = novaCotacao });
            adicao = true;
            Console.Clear();
            Console.WriteLine("Moeda Adicionada com Sucesso!\n\nTecle algo para retornar ao Menu...");
        }
    }
}

void ConverterMoedas()
{
    Console.Clear();

    if (moedas.Count == 0)
    {
        ListarMoedas();
    }
    else if (moedas.Count == 1)
    {
        ListarMoedas();
        Console.WriteLine("É necessário ao menos 2 moedas cadastradas para uma Conversão!");
    }
    else
    {
        ListarMoedas();

        bool conversao = false;
        while (!conversao)
        {
            Console.Write("Digite o Número da Moeda inicial: ");
            if (!int.TryParse(Console.ReadLine(), out int inicial) || inicial > moedas.Count || inicial < 0)
            {
                Console.Clear();
                Console.WriteLine("Valor Inválido!\n");
                continue;
            }

            Console.Write("\nDigite o Número da Moeda Final: ");
            if (!int.TryParse(Console.ReadLine(), out int final) || final > moedas.Count || final < 0)
            {
                Console.Clear();
                Console.WriteLine("Valor inválido!\n");
                continue;
            }

            Console.Write("\nDigite o Valor para Converter: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valor) || valor <= 0)
            {
                Console.Clear();
                Console.WriteLine("Valor inválido!\n");
                continue;
            }
            else
            {
                decimal valorConvertido = valor * moedas[inicial].Cotacao / moedas[final].Cotacao;
                Console.WriteLine($"\nO valor convertido é {valorConvertido:f2} {moedas[final].Nome}");
                conversao = true;
                Console.WriteLine("\nTecle qualquer tecla para retornar ao Menu...");
            }
        }
    }
}

