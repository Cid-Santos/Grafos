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

namespace List
{
    public class Pilha
    {
        private class Celula
        {
            public Object item;
            public Celula prox;
        }
        private Celula topo;
        private int tam;

        public Pilha()
        {
            this.topo = null; this.tam = 0;
        }

        public void empilha(Object x)
        {
            Celula aux = this.topo;
            this.topo = new Celula();
            this.topo.item = x;
            this.topo.prox = aux;
            this.tam++;
        }
        public Object desempilha()
        {
            if (this.vazia())
                throw new Exception("Erro: A pilha esta vazia");
            Object item = this.topo.item;
            this.topo = this.topo.prox;
            this.tam--;
            return item;
        }

        public bool vazia()
        {
            return (this.topo == null);
        }

        public int tamanho()
        {
            return this.tam;
        }
    }
}
