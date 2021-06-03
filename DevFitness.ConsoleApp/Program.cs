using System;
using System.Collections.Generic;
using System.Globalization;

namespace DevFitness.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Digite seu nome: ");
                var nome = Console.ReadLine();

                Console.Write("Digite sua altura: ");
                var altura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Digite seu peso: ");
                var peso = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine();

                Console.WriteLine("Bem vindo(a) ao DevFitness");
                var refeicoes = new List<Refeicao>();

                while (true)
                {
                    ExibirOpcoes();
                    var opcao = int.Parse(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.WriteLine($"\n\nDados do usuário:\n" +
                                              $"Nome: {nome};\n" +
                                              $"Altura: {altura.ToString("F2",CultureInfo.InvariantCulture)};\n" +
                                              $"Peso: {peso.ToString("F2", CultureInfo.InvariantCulture)};\n\n");
                            break;
                        case 2:
                            Cadastrar(ref refeicoes);
                            Console.WriteLine();
                            break;
                        case 3:
                            Listar(ref refeicoes);
                            Console.WriteLine();
                            break;
                        case 0:
                            Console.WriteLine("Saindo da aplicação...");
                            Sair();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void ExibirOpcoes()
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Exibir detalhes de usuário");
            Console.WriteLine("2 - Cadastrar uma nova refeição");
            Console.WriteLine("3 - Listar toda as refeições");
            Console.WriteLine("0 - Finalizar o aplicativo");
            Console.Write("> ");
        }

        public static void Cadastrar(ref List<Refeicao> refeicoes)
        {
            var continuar = true;
            var i = 1;

            while (continuar)
            {
                Console.WriteLine($"\nAlimento #{i}\n");
                Console.Write("Tipo do alimento (Bebida ou Comida): ");
                var tipo = (EnumTipoRefeicao)Enum.Parse(typeof(EnumTipoRefeicao), Console.ReadLine());
                Console.Write("Descrição do alimento: ");
                var descricao = Console.ReadLine();
                Console.Write("Quantidade de calorias: ");
                var calorias = Console.ReadLine();

                if (int.TryParse(calorias, out int caloriasRefeicao))
                {
                    if (tipo != EnumTipoRefeicao.Comida && tipo != EnumTipoRefeicao.Bebida)
                    {
                        Console.WriteLine("Tipo de refeição inválido, por favor, tente novamente!");
                        continue;
                    }
                    switch (tipo)
                    {
                        case EnumTipoRefeicao.Bebida:
                            refeicoes.Add(new Bebida(descricao, caloriasRefeicao));
                            break;
                        case EnumTipoRefeicao.Comida:
                            refeicoes.Add(new Comida(descricao, caloriasRefeicao));
                            break;
                        default:
                            break;
                    }
                } 
                else
                {
                    Console.WriteLine("Caloria inválida, por favor, tente novamente!");
                    continue;
                }

                Console.WriteLine("Deseja inserir mais refeições? (S/N)");
                Console.Write("> ");
                char resposta = char.Parse(Console.ReadLine());
                continuar = (resposta == 'S' || resposta == 's');

                i++;
            }
        }

        public static void Listar(ref List<Refeicao> refeicoes)
        {
            Console.WriteLine("\nRefeições: \n");
            var i = 1;
            foreach (var refeicao in refeicoes)
            {
                Console.WriteLine($"#{i} - {refeicao}");
                i++;
            }
        }

        public static void Sair()
        {
            Environment.Exit(0);
        }
    }
}
