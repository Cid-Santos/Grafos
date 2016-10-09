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
    public class BuscaEmProfundidade
    {
        public const byte branco = 0;
        public const byte cinza = 1;
        public const byte preto = 2;

        private int[] d;
        private int[] t;
        private int[] antecessor;
        private Grafo grafo;

        public BuscaEmProfundidade(Grafo grafo)
        {
            this.grafo = grafo;
            int n = this.grafo.get_numVertices();

            d = new int[n];
            t = new int[n];
            antecessor = new int[n];
        }

        public int tempoDeDescoberta (int v) { return this.d[v]; }
        public int tempoDeTermino (int v) { return this.t[v]; }
        public int verticeAntecessor (int v) { return this.antecessor[v]; }

        public void imprimeCaminho(int origem, int v)
        {
            if (origem == v)
                Console.WriteLine(origem);
            else if (this.antecessor[v] == -1)
                Console.WriteLine("Nao existe caminho de " + origem + " ate " + v);
            else
            {
                imprimeCaminho(origem, this.antecessor[v]);
                Console.WriteLine(v);
            }
        }

        public void buscaEmProfundidade()
        {
            int tempo = 0; int[] cor = new int[this.grafo.get_numVertices()];

            for (int u = 0; u < grafo.get_numVertices(); u++)
            {
                cor[u] = branco; this.antecessor[u] = -1;
            }

            for (int u = 0; u < grafo.get_numVertices(); u++)
                if (cor[u] == branco)
                    tempo = this.visitaDfs(u, tempo, cor);
        }

        private int visitaDfs(int u, int tempo, int[] cor)
        {
            cor[u] = cinza; this.d[u] = ++tempo;

            if (!this.grafo.listaAdjVazia(u))
            {
                Aresta a = this.grafo.primeiroListaAdj(u);
                
                while (a != null)
                {
                    int v = a.v2;
                    if (cor[v] == branco)
                    {
                        this.antecessor[v] = u;
                        tempo = this.visitaDfs(v, tempo, cor);
                    }
                    a = this.grafo.proxAdj(u);
                }
            }
            cor[u] = preto; this.t[u] = ++tempo;
            return tempo;
        }


    }
}
