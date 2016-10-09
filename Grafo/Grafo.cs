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
    public interface Grafo
    {
        void insereAresta(int v1, int v2, int peso);

        bool existeAresta(int v1, int v2, int peso);

        bool listaAdjVazia(int v);

        bool retiraAresta(int v1, int v2, int peso);

        Aresta primeiroListaAdj(int v);
       
        Aresta proxAdj(int v);

        void imprime();

        int get_numVertices();   
               
    }
}
