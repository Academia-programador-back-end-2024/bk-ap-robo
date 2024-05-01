using System;
namespace ProjetoRobo
{
    public class Program
    {
        const char NORTE = 'N';
        const char SUL = 'S';
        const char LESTE = 'L';
        const char OESTE = 'O';

        const char ESQUERDA = 'E';
        const char DIREITA = 'D';
        const char MOVER = 'M';

        public static int RoboPosicaoInicialX { get; set; }
        public static int RoboPosicaoInicialY { get; set; }
        public static char Direcao { get; set; }
        public static int PlanoX { get; set; }
        public static int PlanoY { get; set; }

        static void Main(string[] args)
        {
            Console.Write("Informe o tamanho do plano de coordenadas (formato: X Y): ");
            string posicaoXeY = Console.ReadLine();

            PlanoX = int.Parse(posicaoXeY.Split(" ")[0]);
            PlanoY = int.Parse(posicaoXeY.Split(" ")[1]);

            Console.Write("Digite o número de Robos: ");
            int numeroRobos = int.Parse(Console.ReadLine());
            string[] resultadoFinal = new string[numeroRobos];
            Console.WriteLine("");

            for (int i = 1; i <= numeroRobos; i++)
            {
                Console.Write($"Robô {i} - Informe a posição inicial e a direção (formato: X Y D): ");
                string local = Console.ReadLine();

                RoboPosicaoInicialX = int.Parse(local.Split(" ")[0]);
                RoboPosicaoInicialY = int.Parse(local.Split(" ")[1]);
                Direcao = char.Parse(local.Split(" ")[2].ToUpper());

                Console.Write("Informe as ordens de movimento (formato: E, D ou M): ");
                string roboMovimentos = Console.ReadLine().ToUpper();
                Console.WriteLine("");

                Mover(roboMovimentos);

                resultadoFinal[i - 1] = $"Posição final do robô {i}: {RoboPosicaoInicialX}, {RoboPosicaoInicialY}, {Direcao}";
            }

            foreach (var resultado in resultadoFinal)
            {
                Console.WriteLine(resultado);
            }

            Console.ReadKey();
        }

        public static void GirarParaEsquerda()
        {
            switch (Direcao)
            {
                case NORTE:
                    Direcao = OESTE;
                    break;
                case OESTE:
                    Direcao = SUL;
                    break;
                case SUL:
                    Direcao = LESTE;
                    break;
                case LESTE:
                    Direcao = NORTE;
                    break;
                default:
                    break;
            }
        }

        public static void GirarParaDireita()
        {
            switch (Direcao)
            {
                case NORTE:
                    Direcao = LESTE;
                    break;
                case LESTE:
                    Direcao = SUL;
                    break;
                case SUL:
                    Direcao = OESTE;
                    break;
                case OESTE:
                    Direcao = NORTE;
                    break;
                default:
                    break;
            }
        }

        public static void Andar()
        {
            switch (Direcao)
            {
                case NORTE:
                    if (RoboPosicaoInicialY < PlanoY)
                        RoboPosicaoInicialY += 1;
                    break;
                case LESTE:
                    if (RoboPosicaoInicialX < PlanoX)
                        RoboPosicaoInicialX += 1;
                    break;
                case SUL:
                    if (RoboPosicaoInicialY > -PlanoY)
                        RoboPosicaoInicialY -= 1;
                    break;
                case OESTE:
                    if (RoboPosicaoInicialX > -PlanoX)
                        RoboPosicaoInicialX -= 1;
                    break;
                default:
                    break;
            }
        }

        public static void Mover(string comandos)
        {
            char[] instrucoes = comandos.ToCharArray();

            for (int i = 0; i < instrucoes.Length; i++)
            {
                switch (instrucoes[i])
                {
                    case ESQUERDA:
                        GirarParaEsquerda();
                        break;
                    case DIREITA:
                        GirarParaDireita();
                        break;
                    case MOVER:
                        Andar();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}




