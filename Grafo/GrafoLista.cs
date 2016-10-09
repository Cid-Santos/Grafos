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
using List;

namespace Grafo
{
    public class GrafoLista : Grafo
    {     
        private Lista[] adj;
        private int numVertices;

        public GrafoLista(int numVertices)
        {
            this.adj = new Lista[numVertices];
            this.numVertices = numVertices;

            for (int i = 0; i < this.numVertices; i++)
                this.adj[i] = new Lista();
        }

        public void insereAresta(int v1, int v2, int peso)
        {
            Aresta a = new Aresta(v1, v2, peso);

            this.adj[v1].insere(a);
        }

        public bool existeAresta(int v1, int v2, int peso)
        {
            Aresta a = new Aresta(v1, v2, peso);

            return (this.adj[v1].pesquisa(a));
        }

        public bool listaAdjVazia(int v)
        {
            return this.adj[v].vazia();
        }

        public bool retiraAresta(int v1, int v2, int peso)
        {
            Aresta a = new Aresta(v1, v2, peso);

            Aresta item = (Aresta) this.adj[v1].retira(a);
            return item != null ? true : false;
        }

        public Aresta primeiroListaAdj(int v)
        {
            // Retorna a primeira aresta que o vértice v participa ou
            // null se a lista de adjacência de v for vazia
            Aresta item = (Aresta)this.adj[v].Primeiro();
            return item != null ? new Aresta(v, item.v2, item.peso) : null;
        }

        public Aresta proxAdj(int v)
        {
            // Retorna a próxima aresta que o vértice v participa ou
            // null se a lista de adjacência de v estiver no fim
            Aresta item = (Aresta)this.adj[v].proximo();
            return item != null ? new Aresta(v, item.v2, item.peso) : null;
        }


        public void imprime()
        {
            for (int i = 0; i < this.numVertices; i++)
            {
                Console.Write("Vertice " + i);
                Aresta item = (Aresta)this.adj[i].Primeiro();
                while (item != null)
                {
                    Console.Write(" -> " + item.v2 + " ( " + item.peso + " )");
                    item = (Aresta)this.adj[i].proximo();
                }

                Console.WriteLine();
            }
            
        }

        public int get_numVertices()
        {
            return this.numVertices;
        }

        public int get_grauSaidaVertice(int i)
        {
            return this.adj[i].quantidade();
        }

        public GrafoLista grafoTransposto()
        {
            GrafoLista grafoT = new GrafoLista(this.numVertices);
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

