using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetoRobo
{
    internal class Robo
    {
        Mapa mp = new Mapa();

        public int posX;
        public int posY;
        public int maxX;
        public int maxY;
        public int direcao;
        public int minX = 0;
        public int minY = 0;



        /* guia direção do robo
         * 0 = norte
         * 1 = leste
         * 2 = sul
         * 3 = oeste 
         */

        public string verificaDirecao()
        {
            switch (this.direcao)
            {
                case 0:
                    return "Norte";
                case 1:
                    return "Leste";
                case 2:
                    return "Sul";
                case 3:
                    return "Oeste";
            }
            return "Sem direcao";
        }

        public void mostrarInfo(int numeroRobo)
        {
            string direc = verificaDirecao( );

            Console.WriteLine("\nNumero do robo: " + numeroRobo +
            "\nPosicao X: " + this.posX +
            "\nPosicao Y: " + this.posY +
            "\nDirecao: " + direc);

            mp.mostraMapa();
        }

        public void alteraDirecao(char novaDirecao)
        {
            this.direcao = novaDirecao;
        }
        //tamanho maximo do mapa
        public void insereMapa(string mapa)
        {
            //realiza um split no parametro recebido separando por espaços
            string[] tamMapa = mapa.Split(' ');
            //insere o tamanho do mapa convertendo para int
            mp.inicializaMapa(Convert.ToInt16(tamMapa[0]), Convert.ToInt16(tamMapa[1]));

            this.maxY = Convert.ToInt16(tamMapa[1]);
            this.maxY = Convert.ToInt16(tamMapa[1]);
        }

        public void inserePosicaoDirecao(string posicDirec)
        {
            //realiza um split no parametro recebido separando por espaços
            string[] info = posicDirec.Split(' ');
            //insere os dados recebidos convertendo para int
            this.posX = Convert.ToInt16(info[0]);
            this.posY = Convert.ToInt16(info[1]);
            this.direcao = Convert.ToInt16(info[2]);
        }

        public void andarFrente()
        {
            switch (this.direcao)
            {
                case 0:
                    if(this.posY <= this.maxY)
                    {
                        this.posY++;
                        mp.inserePosicao(this.posX, this.posY);
                    } else
                    {
                        Console.WriteLine("Nao e possivel andar mais para a direcao " + verificaDirecao());
                    }
                    break;

                case 2:
                    if(this.posY >= this.minY)
                    {
                        this.posY--;
                        mp.inserePosicao(this.posX, this.posY);
                    } else
                    {
                        Console.WriteLine("Nao e possivel andar mais para a direcao " + verificaDirecao());
                    }
                    break;

                case 1:
                    if (this.posX <= this.maxX)
                    {
                        this.posX++;
                        mp.inserePosicao(this.posX, this.posY);
                    }
                    else
                    {
                        Console.WriteLine("Nao e possivel andar mais para a direcao " + verificaDirecao());
                    }
                    break;

                case 3:
                    if (this.posX >= this.minX)
                    {
                        this.posX--;
                        mp.inserePosicao(this.posX, this.posY);
                    }
                    else
                    {
                        Console.WriteLine("Nao e possivel andar mais para a direcao " + verificaDirecao());
                    }
                    break;
                default:
                    break;
            }
            mp.mostraMapa();
        }

        public void inputComando(char comando)
        {
            switch (comando)
            {
                case 'M':
                    andarFrente();
                    break;
                case 'E': 
                    if (this.direcao == 0)
                    {
                        this.direcao = 3;
                    } else
                    {
                        this.direcao--;
                    }
                    break;

                case 'D':
                    if (this.direcao == 3)
                    {
                        this.direcao = 0;
                    }
                    else
                    {
                        this.direcao++;
                    }
                    break;
            }
        }

        public void insereMovimentos(string comandos)
        {
            foreach (char c in comandos)
            {
                Console.Clear();
                inputComando(c);
                Thread.Sleep(1000);
            }
        }
    }
}
