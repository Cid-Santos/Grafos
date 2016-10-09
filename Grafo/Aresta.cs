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
    public class Aresta
    {
        public int v1, v2, peso;

        public Aresta(int v1, int v2, int peso)
        {
            this.v1 = v1; this.v2 = v2; this.peso = peso;
        }
    }
}
