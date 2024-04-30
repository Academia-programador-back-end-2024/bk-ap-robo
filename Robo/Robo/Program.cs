using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

const char norte = 'N';
const char sul = 'S';
const char leste = 'L';
const char oeste = '0';
const char direita = 'D';
const char esquerda = 'E';
const char mover = 'M';

string comando;
char posicao = ' ';
int x = 0, y = 0, quantidade;
string tamanho;

Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
string coordenadas = Console.ReadLine();
Posicao(coordenadas, ref x, ref y, ref posicao);



int[,] mapa = new int[x, y];

for (int i = 0; i < mapa.GetLength(0); i++)
{
    for (int j = 0; j < mapa.GetLength(1); j++)
    {
        mapa[i, j] = 0;
    }
}

Console.WriteLine("Posição do Robo (formato: X Y Z)");
string posicaoRobo = Console.ReadLine();
Posicao(posicaoRobo, ref x, ref y, ref posicao);


ValidaCoordenada(x, y, mapa);

Console.WriteLine("Escreva o comando");
comando = Console.ReadLine();

foreach (var item in comando)
{
    if (item == esquerda)
    {
        switch (posicao)
        {
            case norte:
                posicao = oeste;

                break;
            case sul:
                posicao = leste;

                break;
            case leste:
                posicao = norte;

                break;
            case oeste:
                posicao = sul;

                break;
            default:

                break;
        }
    }
    else if (item == direita)
    {
        switch (posicao)
        {
            case norte:
                posicao = leste;

                break;
            case sul:
                posicao = oeste;

                break;
            case leste:
                posicao = sul;

                break;
            case oeste:
                posicao = norte;

                break;
            default:

                break;
        }
    }
    else if (item == mover)
    {
        switch (posicao)
        {
            case norte:
                mapa[x, y] = 0;
                x = x + 1;
                mapa[x, y] = 1;


                break;
            case sul:
                mapa[x, y] = 0;
                x = x - 1;
                mapa[x, y] = 1;
                break;
            case leste:
                mapa[x, y] = 0;
                y = y + 1;
                mapa[x, y] = 1;
                break;
            case oeste:
                mapa[x, y] = 0;
                y = y - 1;
                mapa[x, y] = 1;
                break;
            default:

                break;

        }
        Console.Write("\n");

        for (int l = 0; l < mapa.GetLength(0); l++)
        {
            for (int j = 0; j < mapa.GetLength(1); j++)
            {
                Console.Write(mapa[l, j]);
                Console.Write(" ");
            }
            Console.Write("\n");

        }
    }
    Thread.Sleep(500);
}

static void Posicao(string coordenadas, ref int x, ref int y, ref char posicao)
{
    string[] coordenadasXeY = coordenadas.Split(' ');
    x = Convert.ToInt16(coordenadasXeY[0]);
    y = Convert.ToInt16(coordenadasXeY[1]);
    if (coordenadasXeY.Length >= 3 && !string.IsNullOrEmpty(coordenadasXeY[2]))
    {
        posicao = Convert.ToChar(coordenadasXeY[2]);
    }
}

static void ValidaCoordenada(int x, int y, int[,] mapa)
{
    if (x < mapa.GetLength(0) && y < mapa.GetLength(1))
    {
        mapa[x, y] = 1;
    }
    else
    {
        Console.WriteLine("Coordenadas do robô estão fora dos limites do mapa.");
    }

    for (int i = 0; i < mapa.GetLength(0); i++)
    {
        for (int j = 0; j < mapa.GetLength(1); j++)
        {
            Console.Write(mapa[i, j]);
            Console.Write(" ");
        }
        Console.Write("\n");

    }
}