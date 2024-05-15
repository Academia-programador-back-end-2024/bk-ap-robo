using System;

namespace desafio_robo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int planoX = RecebeValor("Valor de X: ");
            int planoY = RecebeValor("Valor de Y: ");

            int numeroRobos = RecebeValor("Informe o numero de robos: ");

            for (int i = 0; i < numeroRobos; i++)
            {
                Console.Clear();
                Console.WriteLine($"Robô {i + 1}: ");

                Posicao posicaoInicial = RecebePosicaoInicial(planoX, planoY);

                Direcao direcao = RecebeDirecaoInicial();

                string comandos = RecebeComandos();

                ExecutaComandos(ref posicaoInicial, ref direcao, comandos, planoX, planoY);

                Console.WriteLine($"Posição final: {posicaoInicial.X}, {posicaoInicial.Y}, {direcao}");
            }
        }

        private static void ExecutaComandos(ref Posicao posicaoInicial, ref Direcao direcao, string comandos, int limiteX, int limiteY)
        {
            foreach (char comando in comandos)
            {
                switch (comando)
                {
                    case 'E':
                        direcao = direcao.VirarEsquerda();
                        break;
                    case 'D':
                        direcao = direcao.VirarDireita();
                        break;
                    case 'M':
                        posicaoInicial = posicaoInicial.Mover(direcao, limiteX, limiteY);
                        break;
                }
            }
        }

        static int RecebeValor(string texto)
        {
            int valor;

            while (true)
            {
                Console.Write(texto);
                if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                    return valor;
                else
                    Console.WriteLine("Por favor, insira um valor válido maior que zero.");
            }
        }

        static Posicao RecebePosicaoInicial(int limiteX, int limiteY)
        {
            int x = RecebeValor("Posição inicial X do robô: ");
            int y = RecebeValor("Posição inicial Y do robô: ");

            while (x < 0 || x > limiteX || y < 0 || y > limiteY)
            {
                Console.WriteLine($"As posições X e Y devem estar entre 0 e {limiteX}/{limiteY}.");
                x = RecebeValor("Posição inicial X do robô: ");
                y = RecebeValor("Posição inicial Y do robô: ");
            }

            return new Posicao(x, y);
        }

        static Direcao RecebeDirecaoInicial()
        {
            Direcao direcao;

            do
            {
                Console.Write("Direção inicial (N, S, L, O): ");
                if (Enum.TryParse(Console.ReadLine().ToUpper(), out direcao))
                {
                    Console.WriteLine("Direção inválida. Tente novamente.");
                }
            } while (!Enum.IsDefined(typeof(Direcao), direcao));

            return direcao;
        }

        static string RecebeComandos()
        {
            Console.Write("Digite os comandos que o robô deve realizar (D = Direita, E = Esquerda, M = move 1 p/ frente): ");
            return Console.ReadLine().ToUpper();
        }
    }

    public struct Posicao
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Posicao(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Posicao Mover(Direcao direcao, int limiteX, int limiteY)
        {
            int novoX = X;
            int novoY = Y;

            switch (direcao)
            {
                case Direcao.Norte:
                    if (Y < limiteY)
                        novoY++;
                    break;
                case Direcao.Sul:
                    if (Y > 0)
                        novoY--;
                    break;
                case Direcao.Leste:
                    if (X < limiteX)
                        novoX++;
                    break;
                case Direcao.Oeste:
                    if (X > 0)
                        novoX--;
                    break;
            }

            return new Posicao(novoX, novoY);
        }
    }

    public enum Direcao
    {
        Norte,
        Sul,
        Leste,
        Oeste,
        Invalido
    }

    public static class DirecaoExtensions
    {
        public static Direcao VirarEsquerda(this Direcao direcao)
        {
            switch (direcao)
            {
                case Direcao.Norte:
                    return Direcao.Oeste;
                case Direcao.Oeste:
                    return Direcao.Sul;
                case Direcao.Sul:
                    return Direcao.Leste;
                case Direcao.Leste:
                    return Direcao.Norte;
                default:
                    return Direcao.Invalido;
            }
        }

        public static Direcao VirarDireita(this Direcao direcao)
        {
            switch (direcao)
            {
                case Direcao.Norte:
                    return Direcao.Leste;
                case Direcao.Oeste:
                    return Direcao.Norte;
                case Direcao.Sul:
                    return Direcao.Oeste;
                case Direcao.Leste:
                    return Direcao.Sul;
                default:
                    return Direcao.Invalido;
            }
        }

        public static Direcao Parse(string input)
        {
            switch (input)
            {
                case "N":
                    return Direcao.Norte;
                case "S":
                    return Direcao.Sul;
                case "L":
                    return Direcao.Leste;
                case "O":
                    return Direcao.Oeste;
                default:
                    return Direcao.Invalido;
            }
        }
    }
}
