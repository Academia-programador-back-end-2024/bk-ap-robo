namespace Robo
{
    internal class Program
    {
        const char NORTE = 'N';// Para cima
        const char SUL = 'S';//Para baixo
        const char LESTE = 'L';//Para direita
        const char OESTE = 'O';//Para esquerda

        const char ESQUERDA = 'E';
        const char DIREITA = 'D';
        const char MOVER = 'M';

        static char roboDirecao = ' ';


        static void Main(string[] args)
        {
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
                int roboPosicaoInicialX, roboPosicaoInicialY;
                DadosIniciarRobo(roboIndice, out roboPosicaoInicialX, out roboPosicaoInicialY);

                Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
                string roboMovimentos = Console.ReadLine().ToUpper();

                foreach (char comando in roboMovimentos)
                {
                    ProcessarComando(
                        planoX,
                        planoY,
                        ref roboPosicaoInicialX,
                        ref roboPosicaoInicialY,
                        comando);
                }
                string posicaoFinalRobo = $"Posição final do robô {roboIndice}: {roboPosicaoInicialX},{roboPosicaoInicialY},{roboDirecao}";
                resultados[roboIndice - 1] = posicaoFinalRobo;
            }

            foreach (var posicaoFinalRobo in resultados)
            {
                Console.WriteLine(posicaoFinalRobo);
            }


        }

        private static void DadosIniciarRobo(int roboIndice, out int roboPosicaoInicialX, out int roboPosicaoInicialY)
        {
            Console.WriteLine(@$"
Robô {roboIndice}:
Informe a posição inicial e a direção (formato: X Y D):");

            string[] posicaoInicialRobo = Console.ReadLine().ToUpper().Split(' ');

            roboPosicaoInicialX = Convert.ToInt32(posicaoInicialRobo[0]);
            roboPosicaoInicialY = Convert.ToInt32(posicaoInicialRobo[1]);
            roboDirecao = posicaoInicialRobo[2][0];
        }

        private static void ProcessarComando(
            int planoX,
            int planoY,
            ref int roboPosicaoInicialX,
            ref int roboPosicaoInicialY,
            char comando)
        {
            switch (comando)
            {
                case ESQUERDA:
                    roboDirecao = RotacionarEsquera(roboDirecao);
                    break;
                case DIREITA:
                    roboDirecao = RotacionarDireita(roboDirecao);
                    break;
                case MOVER:
                    Mover(planoX, planoY, ref roboPosicaoInicialX, ref roboPosicaoInicialY, roboDirecao);
                    break;
            }
        }

        private static char RotacionarEsquera(char roboDirecao)
        {
            switch (roboDirecao)
            {
                case NORTE:
                    roboDirecao = OESTE;
                    break;
                case OESTE:
                    roboDirecao = SUL;
                    break;
                case SUL:
                    roboDirecao = LESTE;
                    break;
                case LESTE:
                    roboDirecao = NORTE;
                    break;
            }
            return roboDirecao;
        }

        /// <summary>
        /// Rotacionar eixo robo , girar 90 graus para a direita (sem mover)
        /// </summary>
        /// <param name="roboDirecao">Posição que está apontando</param>
        /// <returns></returns>
        private static char RotacionarDireita(
            char roboDirecao
            )
        {
            switch (roboDirecao)
            {
                case NORTE:
                    roboDirecao = LESTE;
                    break;
                case OESTE:
                    roboDirecao = NORTE;
                    break;
                case SUL:
                    roboDirecao = OESTE;
                    break;
                case LESTE:
                    roboDirecao = SUL;
                    break;
            }
            return roboDirecao;
        }

        //M: mover uma posição para frente no grid, mantendo a mesma direção
        private static void Mover(
            int planoX,
            int planoY,
            ref int roboPosicaoInicialX,
            ref int roboPosicaoInicialY,
            char roboDirecao)
        {
            if (roboDirecao == NORTE && (roboPosicaoInicialY < planoY))
            {
                roboPosicaoInicialY++;
                return;
            }

            if (roboDirecao == OESTE && (roboPosicaoInicialX > -planoX))
            {
                roboPosicaoInicialX--;
                return;
            }

            if (roboDirecao == SUL && (roboPosicaoInicialY > -planoY))
            {
                roboPosicaoInicialY--;
                return;
            }

            if (roboDirecao == LESTE && (roboPosicaoInicialX < planoX))
            {
                roboPosicaoInicialX++;
                return;
            }
        }
    }
}
