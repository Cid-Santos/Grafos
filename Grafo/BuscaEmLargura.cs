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
    public class BuscaEmLargura
    {
        public const byte branco = 0;
        public const byte cinza = 1;
        public const byte preto = 2;
        private int[] d;
        private int[] antecessor;
        private Grafo grafo;

        public BuscaEmLargura(Grafo grafo)
        {
            this.grafo = grafo;
            int n = this.grafo.get_numVertices();
            this.d = new int[n];
            this.antecessor = new int[n];
        }

        public int get_d(int v) { return this.d[v]; }
        public int get_antecessor(int v) { return this.antecessor[v]; }

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

        public void buscaEmLargura()
        {
            int[] cor = new int[this.grafo.get_numVertices()];

            for (int u = 0; u < grafo.get_numVertices(); u++)
            {
                cor[u] = branco; this.d[u] = Int32.MaxValue;
                this.antecessor[u] = -1;
            }
            for (int u = 0; u < grafo.get_numVertices(); u++)
                if (cor[u] == branco)
                    this.visitaBfs(u, cor);
        }

        private void visitaBfs(int u, int[] cor)
        {
            cor[u] = cinza; this.d[u] = 0;
            Fila fila = new Fila();
            fila.enfileira(u);

            while (!fila.vazia())
            {
                int aux = (int)fila.desenfileira(); u = aux;
                if (!this.grafo.listaAdjVazia(u))
                {
                    Aresta a = this.grafo.primeiroListaAdj(u);
                    while (a != null)
                    {
                        int v = a.v2;
                        if (cor[v] == branco)
                        {
                            cor[v] = cinza; this.d[v] = this.d[u] + 1;
                            this.antecessor[v] = u; fila.enfileira(v);
                        }
                        a = this.grafo.proxAdj(u);
                    }
                }
                cor[u] = preto;
            }
        }
    }
}
