// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

int x, y, quantidade;
string tamanho; 
Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y)");
tamanho = Console.ReadLine();                                          
x = int.Parse(tamanho[0].ToString());
y = int.Parse(tamanho[2].ToString());

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

