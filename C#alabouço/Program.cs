using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alabouço
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome, classe, raca, resposta;
            int vida = 100, danoBase = 10, defesa = 0;
            bool temEspada = false;
            Random dado = new Random();
            List<string> inventario = new List<string>();
            List<string> inimigos = new List<string> { "Goblin", "Orc", "Esqueleto", "Dragão" }; // Mímico removido daqui

            Console.WriteLine("Informe seu nome Aventureiro(a). ");
            nome = Console.ReadLine();

            Console.WriteLine("Informe sua raça.");
            raca = Console.ReadLine();

            Console.WriteLine("Informe sua classe.");
            classe = Console.ReadLine();

            Console.WriteLine("____________________");
            Console.WriteLine("Ficha: ");
            Console.WriteLine($"Nome: {nome}\nRaça: {raca}\nClasse: {classe}");
            Console.WriteLine("____________________");

            while (vida > 0)
            {
                Console.WriteLine("Você deseja explorar uma nova sala? (S/N)");
                resposta = Console.ReadLine().ToUpper();

                if (resposta != "S")
                    break;

                int escolha = dado.Next(0, 4);
                if (escolha == 0) // Encontrou um baú
                {
                    Console.WriteLine("Você encontrou um baú! Deseja abrir? (S/N)");
                    resposta = Console.ReadLine().ToUpper();
                    if (resposta == "S")
                    {
                        int chanceMimico = dado.Next(1, 5);
                        if (chanceMimico == 1)
                        {
                            Console.WriteLine("O baú era um Mímico! Ele te atacou!");
                            int dado_monstro = dado.Next(1, 10);
                            int dado_jogador = dado.Next(1, 8);
                            int dano = Math.Abs(dado_monstro - dado_jogador) * danoBase;

                            Console.WriteLine($"Mímico: {dado_monstro} - Jogador: {dado_jogador}");
                            if (dado_monstro > dado_jogador)
                            {
                                Console.WriteLine("O Mímico venceu! Você recebeu " + dano + " de dano!");
                                vida = Math.Max(0, vida - dano);
                            }
                            else
                            {
                                Console.WriteLine("Você derrotou o Mímico!");
                            }
                        }
                        else
                        {
                            int item = dado.Next(1, 4);
                            if (item == 1)
                            {
                                Console.WriteLine("Você encontrou uma Poção de Vida!");
                                inventario.Add("Poção de Vida");
                            }
                            else if (item == 2)
                            {
                                if (temEspada)
                                {
                                    Console.WriteLine("Você já tem uma espada! Não precisa de outra.");
                                }
                                else
                                {
                                    Console.WriteLine("Você encontrou uma Espada! Seu dano aumentou.");
                                    temEspada = true;
                                    danoBase += 5;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Você encontrou uma Armadura! Sua defesa aumentou.");
                                defesa += 10;
                            }
                        }
                    }
                }
                else
                {
                    string inimigo = inimigos[dado.Next(inimigos.Count)];
                    int dado_monstro = dado.Next(1, 10);
                    int dado_jogador = dado.Next(1, 8);
                    int dano = Math.Max(0, (Math.Abs(dado_monstro - dado_jogador) * danoBase) - defesa);

                    Console.WriteLine($"Um {inimigo} apareceu!\nMonstro: {dado_monstro} - Jogador: {dado_jogador}");

                    if (dado_monstro > dado_jogador)
                    {
                        Console.WriteLine($"O {inimigo} venceu! Você recebeu {dano} de dano!");
                        vida -= dano;
                    }
                    else
                    {
                        Console.WriteLine($"Você derrotou o {inimigo}!");
                    }
                }

                Console.WriteLine("Vida: " + vida);

                if (inventario.Contains("Poção de Vida"))
                {
                    Console.WriteLine("Deseja usar uma Poção de Vida? (S/N)");
                    resposta = Console.ReadLine().ToUpper();
                    if (resposta == "S")
                    {
                        vida += 30;
                        inventario.Remove("Poção de Vida");
                        Console.WriteLine("Você usou a Poção e recuperou 30 de vida!");
                    }
                }
            }

            Console.WriteLine("Vida final: " + Math.Max(0, vida));

            if (vida <= 0)
            {
                Console.WriteLine("Vacilou, você morreu!");
            }
            else
            {
                Console.WriteLine("Você saiu da masmorra com vida! Parabéns!");
            }

            Console.ReadKey();
        }
    }
}
