namespace ProjetoRobo;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y):");
        string[] sizeInput = Console.ReadLine().Split(' ');

        Mapa mapa = new Mapa(
            int.Parse(sizeInput[0]),
            int.Parse(sizeInput[0]));


        Console.WriteLine("Informe o número de robôs:");
        int numRobots = int.Parse(Console.ReadLine());

        Robo[] robos = new Robo[numRobots];
        for (int i = 0; i < numRobots; i++)
        {
            robos[i] = new Robo(mapa);
        }

        //ImprimirPlanoCartesiano(eixoX, eixoY);
        //Console.WriteLine($"Robô {i + 1}:");
        foreach (var robo in robos)
        {
            robo.IniciarNoMapa();
            robo.DefenirComandos();
            robo.ExecutarComandos();
            Console.WriteLine($"Posição final do robô {robo}");
        }
    }
}
