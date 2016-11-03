/*

Implementação das estruturas de dados Grafo e Listas foram adaptadas do livro: 

[Ziviani, 2006] Projeto de Algoritmos com Implementações em Java e C++.
Nivio Ziviani. 2006, 642 pp. Editora Thomson, ISBN 8522105251.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class GrafoMatriz : Grafo
    {
        public int[,] mat;
        public int numVertices;
        public int[] pos;

        public GrafoMatriz(int numVertices)
        {
            this.mat = new int[numVertices, numVertices];
            this.pos = new int[numVertices];

            this.numVertices = numVertices;

            for (int i = 0; i < this.numVertices; i++)
            {
                for (int j = 0; j < this.numVertices; j++)
                    this.mat[i, j] = 0;

                this.pos[i] = -1;
            }

        }

        public void insereAresta(int v1, int v2, int peso)
        {
            this.mat[v1, v2] = peso;          
        }

        public bool existeAresta(int v1, int v2, int peso)
        {
            return (this.mat[v1, v2] > 0);
        }

        public bool listaAdjVazia(int v)
        {
            for (int i = 0; i < this.numVertices; i++)
                if (this.mat[v, i] > 0)
                    return false;

            return true;
        }

        public Aresta primeiroListaAdj(int v)
        {
            // Retorna a primeira aresta que o v\'ertice v participa ou 
            // se a lista de adjac\^encia de v for vazia
            this.pos[v] = -1;
            return this.proxAdj(v);
        }
        public Aresta proxAdj(int v)
        {
            //Retorna a pr\'oxima aresta que o v\'ertice v participa ou}@ 
            //se a lista de adjac\^encia de v estiver no fim 
            this.pos[v]++;
            while ((this.pos[v] < this.numVertices) && (this.mat[v, this.pos[v]] == 0))
                this.pos[v]++;

            if (this.pos[v] == this.numVertices)
                return null;

            else
                return new Aresta(v, this.pos[v], this.mat[v, this.pos[v]]);
        }


        public bool retiraAresta(int v1, int v2, int peso)
        {
            if (this.mat[v1, v2] == 0)
                return false;
            else
            {
                Aresta aresta = new Aresta(v1, v2, this.mat[v1, v2]);
                this.mat[v1, v2] = 0;
                return true;
            }
        }

        public void imprime()
        {
            for (int i = 0; i < this.numVertices; i++)
            {
                for (int j = 0; j < this.numVertices; j++)
                    Console.Write(this.mat[i, j] + "   ");

                Console.WriteLine();
            }
        }

        public int get_numVertices()
        {
            return this.numVertices;
        }

        public GrafoMatriz grafoTransposto()
        {
            GrafoMatriz grafoT = new GrafoMatriz(this.numVertices);
            for (int v = 0; v < this.numVertices; v++)
                if (!this.listaAdjVazia(v))
                {
                    Aresta adj = this.primeiroListaAdj(v);
                    while (adj != null)
                    {
                        grafoT.insereAresta(adj.v2, adj.v1, adj.peso);
                        adj = this.proxAdj(v);
                    }
                }

            return grafoT;
        }



    }
}

