using System;

namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe as dimensões do plano de coordenadas (X, Y): ");
            int planoX = LerValorEntrada("Valor de X: ");
            int planoY = LerValorEntrada("Valor de Y: ");

            int numeroRobos = LerValorEntrada("Informe o numero de robos: ");

            for (int i = 0; i < numeroRobos; i++)
            {
                Console.WriteLine($"Robô {i + 1}: ");

                int posicaoInicialRoboX = LerValorEntrada("Posição inicial X do robô: ");
                int posicaoInicialRoboY = LerValorEntrada("Posição inicial Y do robô: ");

                char direcao = DirecaoRobo();

                string comandos = ComandosRobos();

                ExecutarComandos(ref posicaoInicialRoboX, ref posicaoInicialRoboY, ref direcao, comandos, planoX, planoY);

                Console.WriteLine($"Posição final: ({posicaoInicialRoboX}, {posicaoInicialRoboY}, {direcao})");
            }
        }

        private static void ExecutarComandos(ref int posicaoInicialRoboX, ref int posicaoInicialRoboY, ref char direcao, string comandos, int planoX, int planoY)
        {
            foreach (char comando in comandos)
            {
                switch (comando)
                {
                    case 'E':
                        direcao = VirarEsquerda(direcao);
                        break;
                    case 'D':
                        direcao = VirarDireita(direcao);
                        break;
                    case 'M':
                        MoverRobo(ref posicaoInicialRoboX, ref posicaoInicialRoboY, direcao, planoX, planoY);
                        break;
                }
            }
        }

        private static void MoverRobo(ref int posicaoInicialRoboX, ref int posicaoInicialRoboY, char direcao, int planoX, int planoY)
        {
            if (direcao == 'N' && posicaoInicialRoboY < planoY)
            {
                posicaoInicialRoboY++;
            }
            else if (direcao == 'L' && posicaoInicialRoboX < planoX)
            {
                posicaoInicialRoboX++;
            }
            else if (direcao == 'S' && posicaoInicialRoboY > 0)
            {
                posicaoInicialRoboY--;
            }
            else if (direcao == 'O' && posicaoInicialRoboX > 0)
            {
                posicaoInicialRoboX--;
            }
        }

        static int LerValorEntrada(string message)
        {
            int valor;

            do
            {
                Console.Write(message);
            }
            while (!int.TryParse(Console.ReadLine(), out valor));

            return valor;
        }

        static char DirecaoRobo()
        {
            char direcao;

            do
            {
                Console.Write("Direção inicial (N, S, L, O): ");
                direcao = char.ToUpper(Console.ReadKey().KeyChar);
            }
            while (direcao != 'N' && direcao != 'S' && direcao != 'L' && direcao != 'O');

            Console.WriteLine();

            return direcao;
        }

        static string ComandosRobos()
        {
            Console.Write("Digite os comandos que o robô deve realizar (D = Direita, E = Esquerda, M = move 1 p/ frente): ");
            return Console.ReadLine().ToUpper();
        }

        static char VirarEsquerda(char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    return 'O';
                case 'O':
                    return 'S';
                case 'S':
                    return 'L';
                case 'L':
                    return 'N';
                default:
                    return direcao;
            }
        }

        static char VirarDireita(char direcao)
        {
            switch (direcao)
            {
                case 'N':
                    return 'L';
                case 'O':
                    return 'N';
                case 'S':
                    return 'O';
                case 'L':
                    return 'S';
                default:
                    return direcao;
            }
        }
    }
}