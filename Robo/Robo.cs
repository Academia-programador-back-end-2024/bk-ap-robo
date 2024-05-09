namespace ProjetoRobo;

public class Robo
{
    public Mapa Mapa { get; set; }
    public Guid Identificador { get; set; }
    public int PosisaoX { get; set; }
    public int PosisaoY { get; set; }
    public char Direcao { get; set; }

    public string Comandos { get; set; }

    public Robo(Mapa mapa)
    {
        Mapa = mapa;
        Identificador = Guid.NewGuid();
    }

    public void IniciarNoMapa()
    {
        Console.WriteLine("Informe a posição inicial e a direção (formato: X Y D):");
        string[] initialPosition = Console.ReadLine().Split(' ');
        PosisaoX = int.Parse(initialPosition[0]);
        PosisaoY = int.Parse(initialPosition[1]);
        Direcao = char.Parse(initialPosition[2]);
    }

    public void DefenirComandos()
    {
        Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
        Comandos = Console.ReadLine();

        //TODO: Rever se os comandos estão certo. 
    }

    public void ExecutarComandos()
    {
        foreach (char comando in Comandos)
        {
            switch (comando)
            {
                case 'E':
                    VirarEsquerda();
                    break;
                case 'D':
                    VirarDireita();
                    break;
                case 'M':
                    Mover();
                    break;
                default:
                    Console.WriteLine($"Comando inválido: {comando}");
                    break;
            }
        }
    }

    private void VirarEsquerda()
    {
        switch (Direcao)
        {
            case 'N':
                Direcao = 'O';
                break;
            case 'O':
                Direcao = 'S';
                break;
            case 'S':
                Direcao = 'L';
                break;
            case 'L':
                Direcao = 'N';
                break;
        }
    }

    public void VirarDireita()
    {
        switch (Direcao)
        {
            case 'N':
                Direcao = 'L';
                break;
            case 'L':
                Direcao = 'S';
                break;
            case 'S':
                Direcao = 'O';
                break;
            case 'O':
                Direcao = 'N';
                break;
        }
    }

    public void Mover()
    {
        switch (Direcao)
        {
            case 'N':
                if (PosisaoY < Mapa.EixoY)
                    PosisaoY++;
                break;
            case 'S':
                if (PosisaoY > 0)
                    PosisaoY--;
                break;
            case 'L':
                if (PosisaoX < Mapa.EixoX)
                    PosisaoX++;
                break;
            case 'O':
                if (PosisaoX > 0)
                    PosisaoX--;
                break;
            default:
                break;
        }
    }

    public override string ToString()
    {
        return $"{Identificador}: {PosisaoX},{PosisaoY},{Direcao}";
    }
}
