/*

Implementação das estruturas de dados Grafo e Listas foram adaptadas do livro: 

[Ziviani, 2006] Projeto de Algoritmos com Implementações em Java e C++.
Nivio Ziviani. 2006, 642 pp. Editora Thomson, ISBN 8522105251.

*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    class Program
    {
        /* -----------

            O arquivo contento uma instância do grafo deve ser criado da seguinte maneira:

            - Primeira linha: número de vértices
            - Da segunda até a n-ésima linha: arestas do grafo. Três números inteiros separados por espaço simples,
            em que o primeiro número representa o vértice de origem da aresta, o segundo número o vértice de destino e o
            terceiro número o peso da aresta. 

            Para grafos não direcionados, deve-se criar uma nova linha para cada aresta, invertendo os vértices de origem
            e destino. Ou no código do programa, criar uma função para leitura do grafo que instancie grafos não direcionados.
            Neste caso, quando inserir uma aresta, inserir também outra aresta invertendo os vértices de origem e destino.

            Exemplo de um arquivo contendo um grafo (peso 1 para todas as arestas) de 5 vértices e 6 arestas:
            5
            0 1 1
            0 2 1
            0 3 1
            2 1 1
            2 3 1
            4 3 1            

        ------------- */
        private static void instanciaGrafo(StreamReader input, Grafo G)
        {
            int v1, v2, peso;
            String[] aresta;

            while (!input.EndOfStream)
            {
                aresta = input.ReadLine().Split(' ');

                v1 = int.Parse(aresta[0]);
                v2 = int.Parse(aresta[1]);
                peso = int.Parse(aresta[2]);

                G.insereAresta(v1, v2, peso);
                //G.insereAresta(v2, v1, peso); //Para grafos não-direcoinados.

            }

        }

        /* -----------

            Insstancia um grafo com matriz de adjacência

        ------------- */
        public static GrafoMatriz instanciaGrafoDoArquivo(String filename, GrafoMatriz G)
        {
            StreamReader input = new StreamReader(filename);

            int numeroDeVertices = int.Parse(input.ReadLine());

            G = new GrafoMatriz(numeroDeVertices);

            instanciaGrafo(input, G);

            input.Close();

            return G;

        }

        /* -----------

            Insstancia um grafo com lista de adjacência

        ------------- */
        public static GrafoLista instanciaGrafoDoArquivo(String filename, GrafoLista G)
        {
            StreamReader input = new StreamReader(filename);

            int numeroDeVertices = int.Parse(input.ReadLine());

            G = new GrafoLista(numeroDeVertices);

            instanciaGrafo(input, G);

            input.Close();

            return G;
        }

        private static int opcao;
        private static int tipoGrafo = 0;
        static void Main(string[] args)
        {

            GrafoLista G = null;
            clListaPraticaUm listaexc;
            String filename = @"C:\Users\Cid\Documents\Visual Studio 2015\Projects\Grafos\input.txt";

            G = instanciaGrafoDoArquivo(filename, G);

            do
            {
                if (tipoGrafo == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Escolha o tipo de Grafo :");

                    Console.WriteLine("╔════════════════════════════╗");
                    Console.WriteLine("║[1 ] = Grafo não dirigido   ║");
                    Console.WriteLine("║[2 ] = Grafo dirigido       ║");
                    Console.WriteLine("║[0 ] = Sair                 ║");
                    Console.WriteLine("╚════════════════════════════╝");
                    Console.Write("Digite uma opção: ");
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            tipoGrafo = 1;
                            filename = @"C:\Users\Cid\Documents\Visual Studio 2015\Projects\Grafos\input.txt";
                            break;
                        case 2:
                            tipoGrafo = 2;
                            filename = @"C:\Users\Cid\Documents\Visual Studio 2015\Projects\Grafos\input.txt";
                            break;
                        case 0:
                            tipoGrafo = 0;
                            break;
                    }
                    Console.Clear();
                }
                else if (tipoGrafo == 1)
                {
                    listaexc = new clListaPraticaUm(G);
                    int v1, v2, grauVertive;
                    String Vertice;
                    Console.WriteLine("Considere um grafo não dirigido:");

                    Console.WriteLine("╔═════════════════════════════╗");
                    Console.WriteLine("║[1  ] = Imprimir Grafo       ║");
                    Console.WriteLine("║[2  ] = Vertices Adjacentes  ║");
                    Console.WriteLine("║[3  ] = Grau do Vertice      ║");
                    Console.WriteLine("║[4  ] = Grafo Regular        ║");
                    Console.WriteLine("║[5  ] = Vertice Isolado      ║");
                    Console.WriteLine("║[6  ] = Vertice Pendente     ║");
                    Console.WriteLine("║[7  ] = Grafo Nulo           ║");
                    Console.WriteLine("║[8  ] = Grafo Completo       ║");
                    Console.WriteLine("║[9  ] = Grafo Conexo         ║");
                    Console.WriteLine("║[10 ] = Grafo Bipartido      ║");
                    Console.WriteLine("║[11 ] = Grafo Complementar   ║");
                    Console.WriteLine("║[12 ] = Grafo Eureliano      ║");
                    Console.WriteLine("║[13 ] = grafo Unicursal      ║");
                    Console.WriteLine("║[14 ] = grafo Hamiltoniano   ║");
                    Console.WriteLine("║[100] = Menu Principal       ║");
                    Console.WriteLine("╚═════════════════════════════╝");
                    Console.Write("Digite uma opção: ");
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            G.imprime();
                            break;
                        case 2:
                            Console.Write("\nEntre com V1: ");
                            v1 = Int32.Parse(Console.ReadLine());
                            Console.Write("\nEntre com V2: ");
                            v2 = Int32.Parse(Console.ReadLine());
                            Vertice = (listaexc.isadjacente(v1, v2)) ? "O Vertice V" + v1 + " e adjacente a v" + v2 : "O Vertice V" + v1 + " nao e adjacente a v" + v2;
                            Console.WriteLine(Vertice);
                            break;
                        case 3:
                            Console.Write("\nEntre com o vertice : ");
                            v1 = Int32.Parse(Console.ReadLine()); ;
                            grauVertive = listaexc.getGrau(v1);
                            Console.WriteLine("O grau do Vertice [" + v1 + "] = " + grauVertive);
                            break;
                        case 4:
                            Vertice = (listaexc.isRegular(G)) ? "\nEste grafo e regular" : "Este grafo nao e regular";
                            Console.WriteLine(Vertice);
                            break;
                        case 5:
                            Console.Write("\nEntre com V1: ");
                            v1 = Int32.Parse(Console.ReadLine());
                            Vertice = (listaexc.isIsolado(v1)) ? "O Vertice V" + v1 + " e isolado" : "O Vertice V" + v1 + " nao e isolado";
                            Console.WriteLine(Vertice);
                            break;
                        case 6:
                            Console.Write("\nEntre com V1: ");
                            v1 = Int32.Parse(Console.ReadLine());
                            Vertice = (listaexc.isPedente(v1)) ? "O Vertice V" + v1 + " e Pendente" : "O Vertice V" + v1 + " nao e Pendente";
                            Console.WriteLine(Vertice);

                            break;
                        case 7:
                            Vertice = (listaexc.isNulo(G)) ? "\nEste grafo e Nulo" : "Este grafo nao e nulo";
                            Console.WriteLine(Vertice);
                            break;
                        case 8:
                            Vertice = (listaexc.isCompleto(G)) ? "\nEste grafo e completo" : "Este grafo nao e completo";
                            Console.WriteLine(Vertice);
                            break;
                        case 9:
                           
                        break;
                        case 10:

                            break;
                        case 11:

                            break;
                        case 12:

                            break;
                        case 13:

                            break;
                        case 100:
                            tipoGrafo = 0;
            break;
            default:

                            break;
        }
        Console.ReadLine();
                    Console.Clear();
                }
                else if (tipoGrafo == 2)
                {
                    Console.WriteLine("Considere um grafo não dirigido:");

                    Console.WriteLine("╔═════════════════════════════╗");
                    Console.WriteLine("║[1  ] = Grafo Ciclico        ║");
                    Console.WriteLine("║[2  ] = Grau de entrada      ║");
                    Console.WriteLine("║[3  ] = ordenacao Topologica ║");
                    Console.WriteLine("║[4  ] = Grafo Transposto     ║");
                    Console.WriteLine("║[5  ] = Vertice FConexo      ║");
                    Console.WriteLine("║[100] = Menu Principal       ║");
                    Console.WriteLine("╚═════════════════════════════╝");
                    Console.Write("Digite uma opção: ");
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 0:

                            break;
                        case 1:

                            break;
                        case 2:

                            break;
                        case 3:
                            break;
                        case 4:
                            G = G.grafoTransposto();
                            G.imprime();
                            break;
                        case 5:

                            break;
                        case 100:
                            tipoGrafo = 0;
                            break;


                        default:

                            break;
                    }
Console.Clear();
                }
            }
            while (opcao != 0);
        }
    }
}
