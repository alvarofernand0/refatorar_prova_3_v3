using System;
using ConversorDeMoedas;

List<Moeda> moedas = new List<Moeda>()
{ // TODO fazer a mesma coisa com o conjunto vazio... portanto, deve verificar as suas implicações...
    new Moeda() {Nome = "Dolar($)", Cotacao = 4.50m},
    new Moeda() {Nome = "Euro(€)", Cotacao = 5.50m},
    new Moeda() {Nome = "Iene(¥)", Cotacao = 0.567m},
    new Moeda() {Nome = "Real Brasileiro(R$)", Cotacao = 1.00m},
    new Moeda() {Nome = "Peseta(Pts)", Cotacao = 2.35m}
};

IniciarAplicacao();

void IniciarAplicacao()
{
    bool sair = false;
    /*
    ! while(true, false)
    ! if(true, false)
    */
    while (sair != true) // ! nao precisa verificar essa igualdade... !sair == negacao(false) == true
    {
        Console.Clear();
        Console.WriteLine("=== MENU DE MOEDAS ===\n");
        Console.WriteLine("1 - Listar Moedas");
        Console.WriteLine("2 - Adicionar Moedas");
        Console.WriteLine("3 - Converter Moedas");
        Console.WriteLine("4 - SAIR\n");
        Console.WriteLine("Digite uma das opções...");

        int.TryParse(Console.ReadLine(), out int opcao); // ! nao está errado!!!!!! MASSSSS, rever o uso disso!
        switch (opcao)
        {
            case 1:
                ListarMoedas();
                break;
            case 2:
                AdicionarMoedas();
                break;
            case 3:
                ConverterMoedas();
                break;
            case 4:
                sair = true;
                Console.Clear();
                Console.WriteLine("Saindo da Aplicação...");
                break;
            default:
                Console.WriteLine("Opção inválida!\n");
                Console.WriteLine("Digite qualquer tecla para voltar ao menu...");
                break;
        }
        Console.ReadKey();
    }
}

void ListarMoedas()
{
    Console.Clear();
    Console.WriteLine("=== MENU DE LISTAGEM ===\n");

    for (int i = 0; i < moedas.Count; i++)
    {
        Console.WriteLine("------------------\n");

        Console.WriteLine($"{i + 1}- {moedas[i].Nome} {moedas[i].Cotacao}\n");
    }
    Console.WriteLine("------------------\n");
    Console.WriteLine("Digite qualquer tecla para retornar ao menu...");
}

void AdicionarMoedas()
{
    bool moedaOk = false;
    while (moedaOk != true) // ! nao precisa fazer verificacao se ta usando bool...
    {
        Console.Clear();
        Console.WriteLine("=== MENU DE ADIÇÃO DE MOEDAS ===\n");

        Console.Write("Digite o nome da nova Moeda: ");
        string novoNome = Console.ReadLine();

        Console.Write("\nDigite uma Cotação para a Moeda: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal novaCotacao) || novaCotacao <= 0) // * string a = ""; string.Empty OUTRA FORMA DE FAZER A MESMA COISA
        {
            Console.WriteLine("\nValor inválido!");
            Console.ReadKey();
        }
        else
        {
            moedas.Add(new Moeda() { Nome = novoNome, Cotacao = novaCotacao });
            Console.Clear();
            moedaOk = true;
            Console.WriteLine("Moeda adicionada com sucesso!\n");
            Console.WriteLine("Digite qualquer tecla para retornar ao Menu...");
            break;
        }
    }
}

void ConverterMoedas()
{
    bool moedaOk = false;
    while (moedaOk != true)// ? entender o que se passa aqui, para melhorar a capacidade de codificarkkkkkkkkkk
    {
        Console.Clear();

        // ? se tem uma função que faz exatamente isso nao tem sentido fazer um novo trecho de codigo que faz exatemente a mesma coisa
        for (int i = 0; i < moedas.Count; i++)
        {
            Console.WriteLine($"{i}- {moedas[i].Nome} {moedas[i].Cotacao}\n");
        }

        Console.Write("Digite o Nº da opção da moeda Inicial: ");

        // ! essa verificacao está toda errada nao verifica nada...
        // if (int.TryParse(Console.ReadLine(), out int inicial) && inicial < moedas.Count && inicial >= 0)
        // {
        //     Console.WriteLine("");
        // }
        // else
        // {
        //     Console.WriteLine("Opção inválida!\nDigite qualquer tecla para tentar novamente...");
        // }
        // ! errado tambem...
        // Console.Write("Digite o Nº da opção da moeda Final: ");
        // if (int.TryParse(Console.ReadLine(), out int final) && final < moedas.Count && final >= 0)
        // {
        //     Console.WriteLine("");
        // }
        // else
        // {
        //     Console.WriteLine("Opção inválida!\nDigite qualquer tecla para tentar novamente...");
        // }

        Console.Write("Digite o valor que deseja converter: ");
        if (valor == 0) // ! nao pode ser <= 0 // Corrigir essa verificação!
        {
            Console.WriteLine("Valor inválido!");
        }
        else
        {
            decimal valorConvertido = valor * moedas[inicial].Cotacao / moedas[final].Cotacao;
            Console.WriteLine($"O valor convertido é {valorConvertido:f3} {moedas[final].Nome}");
            moedaOk = true;
            break;
        }
    }
}

//
// bool certo_errado;
// int valor_retorno;
// certo_errado = int.TryParse(Console.ReadLine(), out valor_retorno);

// Console.WriteLine($"retorno do TRYPARSE {certo_errado} - valor do TRYPARSE {valor_retorno}");

// if (valor_retorno == 0)// eu nao quero
// {
//     Console.WriteLine("valor invalido");
//     return;
// }
