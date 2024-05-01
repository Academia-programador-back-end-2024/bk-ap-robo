namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                const char NORTE = 'N';
                const char SUL = 'S';
                const char LESTE = 'L';
                const char OESTE = 'O';
            const char ESQUERDA = 'E';
            const char DIREITA = 'D';
            const char MOVER = 'M';

                Console.Write("Digite o tamanho da dimensão do plano de coordenadas: ");
                int tamanhoX = Convert.ToInt32(Console.ReadLine());
                int tamanhoY = Convert.ToInt32(Console.ReadLine());
                string[,] dimensao = new string[tamanhoX, tamanhoY];

                Console.Write("Digite o número de robôs: ");
                int robos = Convert.ToInt32(Console.ReadLine());
                int[,] coordenadas = new int[robos, 2];
                char[,] direcao = new char[robos, 1];

                for (int i = 0; i < robos; i++)
            {
                    for (int j = 0; j < 2; j++)
                    {
                        Console.WriteLine($"Digite as coordenadas iniciais do {i + 1}º robô:");
                        Console.Write("X = ");
                        coordenadas[i, j] = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Y = ");
                        coordenadas[i, ++j] = Convert.ToInt16(Console.ReadLine());
            }

                    Console.WriteLine("Agora digite a direção inicial que o robô está virado" +
                            "\nN: norte" +
                            "\nS: sul" +
                            "\nL: leste" +
                            "\nO: oeste");
                    direcao[i, 0] = Convert.ToChar(Console.ReadLine().ToUpper());

                    Console.Write($"Informe as ordens de movimento do {i + 1}º robô (formato E, D ou M): ");
                string roboMovimentos = Console.ReadLine().ToUpper();

                foreach (char comando in roboMovimentos)
                {
                        if (comando == ESQUERDA) //Girar 90º à esquerda
                    {
                            if (direcao[i, 0] == NORTE)
                        {
                                direcao[i, 0] = OESTE;
                        }
                            else if (direcao[i, 0] == OESTE)
                        {
                                direcao[i, 0] = SUL;
                        }
                            else if (direcao[i, 0] == SUL)
                        {
                                direcao[i, 0] = LESTE;
                        }
                            else if (direcao[i, 0] == LESTE)
                        {
                                direcao[i, 0] = NORTE;
                        }
                    }
                        else if (comando == DIREITA) //Girar 90º à direita
                    {
                            if (direcao[i, 0] == NORTE)
                        {
                                direcao[i, 0] = LESTE;
                        }
                            else if (direcao[i, 0] == LESTE)
                        {
                                direcao[i, 0] = SUL;
                        }
                            else if (direcao[i, 0] == SUL)
                        {
                                direcao[i, 0] = OESTE;
                        }
                            else if (direcao[i, 0] == OESTE)
                        {
                                direcao[i, 0] = NORTE;
                        }
                    }
                        else if (comando == MOVER) //Mover a direção em 1
                    {
                            if (direcao[i, 0] == NORTE)
                        {
                                if (coordenadas[i, 1] < tamanhoY)
                            {
                                    coordenadas[i, 1]++;
                            }
                        }
                            else if (direcao[i, 0] == SUL)
                        {
                                if (coordenadas[i, 1] > -tamanhoY)
                            {
                                    coordenadas[i, 1]--;
                            }
                        }
                            else if (direcao[i, 0] == LESTE)
                        {
                                if (coordenadas[i, 0] < tamanhoX)
                            {
                                    coordenadas[i, 0]++;
                            }
                        }
                            else if (direcao[i, 0] == OESTE)
                        {
                                if (coordenadas[i, 0] > -tamanhoX)
                            {
                                    coordenadas[i, 0]--;
                            }
                        }
                    }
                }
                string posicaoFinalRobo = $"Posição final do robô {roboIndice}: {roboPosicaoInicialX},{roboPosicaoInicialY},{roboDirecao}";
                resultados[roboIndice] = posicaoFinalRobo;
            }
                for (int i = 0; i < robos; i++)
                {
                    Console.Write($"Robô {i + 1} = ");

                    for (int j = 0; j < 2; j++)
            {
                        Console.Write($"{coordenadas[i, j]} ");
                    }
                    Console.Write($"{direcao[i, 0]}");
                    Console.WriteLine();
                }
            }


        }
    }
}
