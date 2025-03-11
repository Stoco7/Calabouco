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
            string nome = "", classe = "", raca = "";
            string resposta = "";
            int vida = 100, dado_monstro, dado_jogador;
            Random dado = new Random();

            Console.WriteLine("Informe seu nome Aventureiro(a).");
            nome = Console.ReadLine();

            Console.WriteLine("Informe sua raça.");
            raca = Console.ReadLine();

            Console.WriteLine("Informe sua classe.");
            classe = Console.ReadLine();

            Console.WriteLine("____________________");
            Console.WriteLine("Ficha: ");
            Console.WriteLine(nome);
            Console.WriteLine(classe);
            Console.WriteLine(raca);
            Console.WriteLine("____________________");

            Console.WriteLine("Deseja entrar na porta a sua esquerda? (S/N)");
            resposta = Console.ReadLine();

            if (resposta == "S")
            {
                Console.WriteLine("Aqui tem um monstro. Voce vai enfrentá-lo!");

                dado_monstro = dado.Next(1, 6);
                dado_jogador = dado.Next(1, 6);

                Console.WriteLine("Monstro: " + dado_monstro + " - Jogador: " + dado_jogador);

                if(dado_monstro >  dado_jogador)
                {
                    Console.WriteLine("Monstro Venceu!");
                    vida = vida - 50;
                }
                else
                {
                    Console.WriteLine("Jogador Venceu!");
                }
            }
            Console.WriteLine("Sua vida é: " + vida);

            Console.WriteLine("Deseja entrar na sala a sua esquerda? (S/N)");
            resposta = Console.ReadLine();

            if (resposta == "S")
            {
                Console.WriteLine("Voce ganhou vida extra!");
                vida = vida + 30;
            }

            Console.WriteLine("Sua vida é: " + vida);
            Console.WriteLine("Mais uma sala, voce deseja entrar na sala? (S/N)");
            resposta = Console.ReadLine();

            if (resposta == "S")
            {
                Console.WriteLine("Eita, monstro grande, logo ele é monstrão!(Birl)");
                dado_monstro = dado.Next(1, 8);
                dado_jogador = dado.Next(1, 6);

                if(dado_monstro > dado_jogador)
                {
                    Console.WriteLine("Ele te acertou!");
                    vida = vida - 60;
                }
                else
                {
                    Console.WriteLine("Voce é o bixão mesmo, matou o monstrão");
                }
            }

            Console.WriteLine("Vida " + vida);
            if (vida <= 0)
            {
                Console.WriteLine("Vacilou, voce morreu...guenta nada...");
            }
            else
            {
                Console.WriteLine("Continua vivo, merece um abraço...mas não!");
            }

            Console.ReadKey();
        }
    }
}
