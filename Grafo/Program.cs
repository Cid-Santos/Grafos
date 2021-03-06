﻿/*

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
            GrafoMatriz Gm = null;
            int numVertices = 0;
            clListaPraticaUm listaexc;
            String filename = "";



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
                            filename = @"C:\Users\Cid\Documents\Visual Studio 2015\Projects\Grafos\inputND.txt";
                            G = instanciaGrafoDoArquivo(filename, G);
                            Gm = instanciaGrafoDoArquivo(filename, Gm);
                            break;
                        case 2:
                            tipoGrafo = 2;
                            filename = @"C:\Users\Cid\Documents\Visual Studio 2015\Projects\Grafos\inputD.txt";
                            G = instanciaGrafoDoArquivo(filename, G);
                            Gm = instanciaGrafoDoArquivo(filename, Gm);
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
                    Console.WriteLine("║[0  ] = Imprimir Grafo       ║");
                    Console.WriteLine("║[1  ] = Vertices Adjacentes  ║");
                    Console.WriteLine("║[2  ] = Grau do Vertice      ║");
                    Console.WriteLine("║[3  ] = Grafo Regular        ║");
                    Console.WriteLine("║[4  ] = Vertice Isolado      ║");
                    Console.WriteLine("║[5  ] = Vertice Pendente     ║");
                    Console.WriteLine("║[6  ] = Grafo Nulo           ║");
                    Console.WriteLine("║[7  ] = Grafo Completo       ║");
                    Console.WriteLine("║[8  ] = Grafo Conexo         ║");
                    Console.WriteLine("║[9  ] = Grafo Bipartido      ║");
                    Console.WriteLine("║[10 ] = Grafo Complementar   ║");
                    Console.WriteLine("║[11 ] = Grafo Eureliano      ║");
                    Console.WriteLine("║[12 ] = grafo Unicursal      ║");
                    Console.WriteLine("║[13 ] = grafo Hamiltoniano   ║");
                    Console.WriteLine("║[100] = Menu Principal       ║");
                    Console.WriteLine("╚═════════════════════════════╝");
                    Console.Write("Digite uma opção: ");
                    opcao = Int32.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 0:
                            G.imprime();
                            break;
                        case 1:
                            numVertices = Gm.get_numVertices();
                            do
                            {
                                Console.Write("\nEntre com V1: ");
                                v1 = Int32.Parse(Console.ReadLine());
                            } while (v1 >= numVertices);
                            do
                            {
                                Console.Write("\nEntre com V2: ");
                                v2 = Int32.Parse(Console.ReadLine());
                            } while (v2 >= numVertices);
                            Vertice = (Gm.existeAresta(v1, v2, 1)) ? "O Vertice V" + v1 + " e adjacente a v" + v2 : "O Vertice V" + v1 + " nao e adjacente a v" + v2;
                            Console.WriteLine(Vertice);
                            break;
                        case 2:
                            numVertices = Gm.get_numVertices();
                            do
                            {
                                Console.Write("\nEntre com V1: ");
                                v1 = Int32.Parse(Console.ReadLine());
                            } while (v1 >= numVertices);
                            grauVertive = listaexc.getGrau(v1);
                            Console.WriteLine("O grau do Vertice [" + v1 + "] = " + grauVertive);
                            break;
                        case 3:
                            Vertice = (listaexc.isRegular(G)) ? "\nEste grafo e regular" : "Este grafo nao e regular";
                            Console.WriteLine(Vertice);
                            break;
                        case 4:
                            numVertices = Gm.get_numVertices();
                            do
                            {
                                Console.Write("\nEntre com V1: ");
                                v1 = Int32.Parse(Console.ReadLine());
                            } while (v1 >= numVertices);
                            Vertice = (listaexc.isIsolado(v1)) ? "O Vertice V" + v1 + " e isolado" : "O Vertice V" + v1 + " nao e isolado";
                            Console.WriteLine(Vertice);
                            break;
                        case 5:
                            numVertices = Gm.get_numVertices();
                            do
                            {
                                Console.Write("\nEntre com V1: ");
                                v1 = Int32.Parse(Console.ReadLine());
                            } while (v1 >= numVertices);
                            Vertice = (listaexc.isPedente(v1)) ? "O Vertice V" + v1 + " e Pendente" : "O Vertice V" + v1 + " nao e Pendente";
                            Console.WriteLine(Vertice);

                            break;
                        case 6:
                            Vertice = (listaexc.isNulo(G)) ? "\nEste grafo e Nulo" : "Este grafo nao e nulo";
                            Console.WriteLine(Vertice);
                            break;
                        case 7:
                            Vertice = (listaexc.isCompleto(G)) ? "\nEste grafo e completo" : "Este grafo nao e completo";
                            Console.WriteLine(Vertice);
                            break;
                        case 8:
                            Vertice = (listaexc.isConexo(Gm)) ? "\nEste grafo e conexo" : "Este grafo nao e conexo";
                            Console.WriteLine(Vertice);
                            break;
                        case 9:
                            Vertice = (listaexc.isBipartido(Gm)) ? "\nEste grafo e BiPartido" : "Este grafo nao e BiPartido";
                            Console.WriteLine(Vertice);
                            break;
                        case 10:
                            Grafo Gl =  listaexc.getComplementar(Gm);
                            Gl.imprime();
                            break;
                        case 11:
                            Vertice = (listaexc.isEuleriano(G)) ? "\nEste grafo e Eureliano" : "Este grafo nao e Eureliano";
                            Console.WriteLine(Vertice);
                            break;
                        case 12:
                            Vertice = (listaexc.isUnicursal(G)) ? "\nEste grafo e Unicursal" : "Este grafo nao e Unicursal";
                            Console.WriteLine(Vertice);
                            break;
                        case 13:
                            Vertice = (listaexc.isHamiltoniano(G)) ? "\nEste grafo e Hamiltoniano" : "Este grafo nao e Hamiltoniano";
                            Console.WriteLine(Vertice);
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
                    listaexc = new clListaPraticaUm(G);
                    String Vertice;
                    int v1, v2, grauVertive;
                    Console.WriteLine("Considere um grafo dirigido:");

                    Console.WriteLine("╔═════════════════════════════╗");
                    Console.WriteLine("║[0  ] = Imprimir Grafo       ║");
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
                            G.imprime();
                            break;
                        case 1:
                            Vertice = (listaexc.hasCiclo(G)) ? "\nEste grafo tem Ciclo" : "Este grafo nao tem Ciclo";
                            Console.WriteLine(Vertice);
                            break;
                        case 2:
                            numVertices = Gm.get_numVertices();
                            do
                            {
                                Console.Write("\nEntre com V1: ");
                                v1 = Int32.Parse(Console.ReadLine());
                            } while (v1 >= numVertices);
                            int grau = listaexc.getGrauEntrada(Gm, v1);
                            Console.WriteLine(grau);
                            break;
                        case 3:
                            Vertice = (listaexc.hasCiclo(Gm)) ? "\nEste grafo e Ciclo" : "Este grafo nao e Ciclo";
                            Console.WriteLine(Vertice);
                            break;
                        case 4:
                            GrafoLista Gl;
                            Gl = listaexc.getTransposto(G);
                            Gl.imprime();
                            break;
                        case 5:
                            Vertice = (listaexc.isFConexo(G)) ? "\nEste grafo e FConexo" : "Este grafo nao e FConexo";
                            Console.WriteLine(Vertice);
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
            }
            while (opcao != 0);
        }
    }
}
