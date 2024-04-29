
namespace ProjetoRobo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const char NORTE = 'N';
            const char SUL = 'S';
            const char LESTE = 'L';
            const char OESTE = 'O';

            const char ESQUERDA = 'E';
            const char DIREITA = 'D';
            const char MOVER = 'M';

            Console.Write("Informe o tamanho do plano de coordenadas(formato: X Y): ");
            string cordenadas = Console.ReadLine();

            int planoX = int.Parse(cordenadas.Split(" ")[0]);
            int planoY = int.Parse(cordenadas.Split(" ")[1]);

            Console.Write("Informe o número de robôs: ");
            int numeroRobos = int.Parse(Console.ReadLine());
            string[] resultados = new string[numeroRobos];
            Console.WriteLine();

            for (int i = 1; i <= numeroRobos; i++)
            {
                Console.Write($"Robô {i} - Informe a posição inicial e a direção(formato: X Y D): ");
                string posicaoInicialRobo = Console.ReadLine().ToUpper();

                int roboPosicaoX = int.Parse(posicaoInicialRobo.Split(" ")[0]);
                int roboPosicaoY = int.Parse(posicaoInicialRobo.Split(" ")[1]);
                char roboDirecao = char.Parse(posicaoInicialRobo.Split(" ")[2]);

                Console.Write("Informe as ordens de movimento(formato: E, D ou M): ");
                string roboMovimentos = Console.ReadLine().ToUpper();
                Console.WriteLine("");

                foreach (char comando in roboMovimentos)
                {
                    if (comando == ESQUERDA)
                    {
                        if (roboDirecao == NORTE)
                        {
                            roboDirecao = OESTE;
                        }
                        else if (roboDirecao == OESTE)
                        {
                            roboDirecao = SUL;
                        }
                        else if (roboDirecao == SUL)
                        {
                            roboDirecao = LESTE;
                        }
                        else if (roboDirecao == LESTE)
                        {
                            roboDirecao = NORTE;
                        }
                    }
                    else if (comando == DIREITA)
                    {
                        if (roboDirecao == NORTE)
                        {
                            roboDirecao = LESTE;
                        }
                        else if (roboDirecao == OESTE)
                        {
                            roboDirecao = NORTE;
                        }
                        else if (roboDirecao == SUL)
                        {
                            roboDirecao = OESTE;
                        }
                        else if (roboDirecao == LESTE)
                        {
                            roboDirecao = SUL;
                        }
                    }
                    else if (comando == MOVER)
                        if (roboDirecao == NORTE)
                        {
                            if (roboPosicaoY < planoY)
                            {
                                roboPosicaoY++;
                            }
                        }
                        else if (roboDirecao == OESTE)
                        {
                            if (roboPosicaoX > -planoX)
                            {
                                roboPosicaoX--;
                            }
                        }
                        else if (roboDirecao == SUL)
                        {
                            if (roboPosicaoY > -planoY)
                            {
                                roboPosicaoY--;
                            }
                        }
                        else if (roboDirecao == LESTE)
                        {
                            if (roboPosicaoX < planoX)
                            {
                                roboPosicaoX++;
                            }
                        }
                }
                string posicaoFinalRobo = $"Posição final do robô {i}: {roboPosicaoX}, {roboPosicaoY}, {roboDirecao}";
                resultados[i - 1] = posicaoFinalRobo;
            }

            foreach (string posicaoFinalRobo in resultados)
            {
                Console.WriteLine(posicaoFinalRobo);
            }

            Console.ReadKey();
        }
    }
}