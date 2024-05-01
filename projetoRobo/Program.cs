namespace projetoRobo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Robo roboUm = new();


            Console.WriteLine("Informe o tamanho do plano de coordenadas (formato: X Y): ");
            roboUm.insereMapa(Console.ReadLine());

            Console.WriteLine("Informe o numero de robos: ");
            int numRobo = Convert.ToInt16(Console.ReadLine());



            for (int i = 0; i < numRobo; i++)
            {
                Console.WriteLine("Informe a posição inicial e a direção (formato: X Y D):" +
                    "\nGuia de direcao:" +
                    "\n0 - norte" +
                    "\n1 - leste" +
                    "\n2 - sul" +
                    "\n3 - oeste");
                roboUm.inserePosicaoDirecao(Console.ReadLine());


                Console.WriteLine("Informe as ordens de movimento (formato: E, D ou M):");
                roboUm.insereMovimentos(Console.ReadLine());

                roboUm.mostrarInfo(i);
            }
        }
    }
}
