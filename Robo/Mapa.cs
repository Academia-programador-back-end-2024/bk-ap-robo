namespace ProjetoRobo;

public class Mapa
{
    public Mapa(int eixoX, int eixoY)
    {
        EixoX = eixoX;
        EixoY = eixoY;
    }


    public readonly int EixoX;
    public readonly int EixoY;

    public void ImprimirPlanoCartesiano()
    {
        int height = EixoY;
        int width = EixoX;
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
}
