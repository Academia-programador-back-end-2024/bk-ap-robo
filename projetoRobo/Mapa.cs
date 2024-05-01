using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoRobo
{
    internal class Mapa
    {
        public string[,] matrizMapa;
        public int passo = 0;

        public void inicializaMapa(int x, int y)
        {
            matrizMapa = new string[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrizMapa[i, j] = "x";
                }
            }
        }

        public void inserePosicao(int x, int y)
        {
            matrizMapa[y, x] = "" + Convert.ToString(passo) + "";
            
            passo++;
        }

        public void mostraMapa() {
            for (int i = 0; i < matrizMapa.GetLongLength(0); i++)
            {
                for (int j = 0; j < matrizMapa.GetLongLength(1); j++)
                {
                    Console.Write(matrizMapa[i, j]);
                }
                Console.WriteLine();
            }
        }


    }
}
