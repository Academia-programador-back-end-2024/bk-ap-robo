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

string comando = "EMEMEMEMM";
char posicao = 'N';
int x, y, quantidade;
string tamanho; 

Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
string coordenadas = Console.ReadLine();
string[] coordenadasXeY = coordenadas.Split(' ');
if (coordenadasXeY.Length != 2)
{
    Console.WriteLine("Coordenadas invalida!");
    return;
}

x = Convert.ToInt16(coordenadasXeY[0]);
y = Convert.ToInt16(coordenadasXeY[1]);


int[,] mapa = new int[x,y];

for (int i = 0; i < mapa.GetLength(0); i++)
{
    for (int j = 0; j < mapa.GetLength(1); j++)
    {
        mapa[i, j] = 0;
    }
}

//Console.WriteLine("Informe a quantdade de robos");
//quantidade = int.Parse(Console.ReadLine());

Console.WriteLine("Posição do Robo (formato: X Y Z)");
string posicaoRobo = Console.ReadLine();
x = int.Parse(posicaoRobo[0].ToString());
y = int.Parse(posicaoRobo[2].ToString());

// Verifica se as coordenadas do robô estão dentro dos limites do mapa
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

foreach (var item in comando)
{
    Console.Clear();
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
    Thread.Sleep(1000);
}
  





