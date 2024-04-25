namespace Robo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*Informe o tamanho do plano de coordenadas (formato: X Y):
5 5
Informe o número de robôs:
2
Robô 1:
Informe a posição inicial e a direção (formato: X Y D):
1 2 N
Informe as ordens de movimento (formato: E, D ou M):
EMEMEMEMM
Robô 2:
Informe a posição inicial e a direção (formato: X Y D):
3 3 L
Informe as ordens de movimento (formato: E, D ou M):
MMDMMDMDDM
Posição final do robô 1: 1,3,N
Posição final do robô 2: 5,1,L
                
- N: norte
- S: sul
- L: leste
- O: oeste

//Comandos
- E: girar 90 graus para a esquerda (sem mover)
- D: girar 90 graus para a direita (sem mover)
- M: mover uma posição para frente no grid, mantendo a mesma direção
            */

            const char NORTE = 'N';// Para cima
            const char SUL = 'S';//Para baixo
            const char LESTE = 'L';//Para direita
            const char OESTE = 'O';//Para esquerda

            const char ESQUERDA = 'E';
            const char DIREITA = 'D';
            const char MOVER = 'M';


            Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
            string coordenadas = Console.ReadLine();
            string[] coordenadasXeY = coordenadas.Split(' ');
            if (coordenadasXeY.Length != 2)
            {
                Console.WriteLine("Coordenadas invalida!");
                return;
            }

            int planoX = Convert.ToInt16(coordenadasXeY[0]);
            int planoY = Convert.ToInt16(coordenadasXeY[1]);

            Console.WriteLine("Informe o número de robôs:");
            int numeroDeRobos = Convert.ToInt32(Console.ReadLine());
            string[] resultados = new string[numeroDeRobos];

            for (int roboIndice = 1; roboIndice <= numeroDeRobos; roboIndice++)
            {
                Console.WriteLine(@$"
Robô {roboIndice}:
Informe a posição inicial e a direção (formato: X Y D):");
                string[] posicaoInicialRobo = Console.ReadLine().ToUpper().Split(' ');

                int roboPosicaoInicialX = Convert.ToInt32(posicaoInicialRobo[0]);
                int roboPosicaoInicialY = Convert.ToInt32(posicaoInicialRobo[1]);
                char roboDirecao = posicaoInicialRobo[2][0];

                Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
                string roboMovimentos = Console.ReadLine().ToUpper();

                foreach (char comando in roboMovimentos)
                {
                    if (comando == ESQUERDA)//- E: girar 90 graus para a esquerda (sem mover) 
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
                    else if (comando == DIREITA)//-  D: girar 90 graus para a direita (sem mover)
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
                    else if (comando == MOVER)//M: mover uma posição para frente no grid, mantendo a mesma direção
                    {
                        if (roboDirecao == NORTE)
                        {
                            if (roboPosicaoInicialY < planoY)
                            {
                                roboPosicaoInicialY++;
                            }
                        }
                        else if (roboDirecao == OESTE)
                        {
                            if (roboPosicaoInicialX > -planoX)
                            {
                                roboPosicaoInicialX--;
                            }
                        }
                        else if (roboDirecao == SUL)
                        {
                            if (roboPosicaoInicialY > -planoY)
                            {
                                roboPosicaoInicialY--;
                            }
                        }
                        else if (roboDirecao == LESTE)
                        {
                            if (roboPosicaoInicialX < planoX)
                            {
                                roboPosicaoInicialX++;
                            }
                        }
                    }
                }
                string posicaoFinalRobo = $"Posição final do robô {roboIndice}: {roboPosicaoInicialX},{roboPosicaoInicialY},{roboDirecao}";
                resultados[roboIndice] = posicaoFinalRobo;
            }

            foreach (var posicaoFinalRobo in resultados)
            {
                Console.WriteLine(posicaoFinalRobo);
            }


        }
    }
}
