namespace Robo;


class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
        //string[] sizeInput = Console.ReadLine().Split(' ');
        int eixoX = 5;//int.Parse(sizeInput[0]);
        int eixoY = 5;//int.Parse(sizeInput[1]);

        //Console.WriteLine("Informe o número de robôs:");
        int numRobots = 1;//int.Parse(Console.ReadLine());

        ImprimirPlanoCartesiano(eixoX, eixoY);

        for (int i = 0; i < numRobots; i++)
        {
            Console.WriteLine($"Robô {i + 1}:");
            Console.WriteLine("Informe a posição inicial e a direção (formato: X Y D):");
            string[] initialPosition = Console.ReadLine().Split(' ');
            int x = int.Parse(initialPosition[0]);
            int y = int.Parse(initialPosition[1]);
            char direcao = char.Parse(initialPosition[2]);


            Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
            string comandos = Console.ReadLine();

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
                        Mover(ref x, ref y, direcao, eixoX, eixoY);
                        break;
                    default:
                        Console.WriteLine($"Comando inválido: {comando}");
                        break;
                }
            }

            Console.WriteLine($"Posição final do robô {i + 1}: {x},{y},{direcao}");
        }
    }
    static void ImprimirPlanoCartesiano(int height, int width)
    {
        string[,] planoCartesiano = new string[height * 2 + 1, width * 2 + 1];

        // Preenche o plano cartesiano com os valores
        for (int y = height; y >= -height; y--)
        {
            for (int x = -width; x <= width; x++)
            {
                planoCartesiano[y + height, x + width] = "(" + x + "," + y + ")";
            }
        }

        for (int y = height; y >= -height; y--)
        {
            for (int x = -width; x <= width; x++)
            {
                Console.Write(planoCartesiano[y + height, x + width].PadLeft(7) + " ");
            }
            Console.WriteLine();
        }
    }

    static char VirarEsquerda(char direcaoAtual)
    {
        switch (direcaoAtual)
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
                //ignorar
                return direcaoAtual;
        }
    }

    static char VirarDireita(char direcao)
    {
        switch (direcao)
        {
            case 'N':
                return 'L';
            case 'L':
                return 'S';
            case 'S':
                return 'O';
            case 'O':
                return 'N';
            default:
                //Ignorar
                return ' ';
        }
    }

    static void Mover(ref int posX, ref int posY, char direcao, int eixoX, int eixoY)
    {
        switch (direcao)
        {
            case 'N':
                if (posY < eixoY)
                    posY++;
                break;
            case 'S':
                if (posY > 0)
                    posY--;
                break;
            case 'L':
                if (posX < eixoX)
                    posX++;
                break;
            case 'O':
                if (posX > 0)
                    posX--;
                break;
            default:
                break;
        }
    }
}
