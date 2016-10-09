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
    public class Fila
    {
        private class Celula
        {
            public Object item;
            public Celula prox;
        }
        private Celula frente;
        private Celula tras;

        // Operações
        public Fila()
        { //Cria uma Fila vazia
            this.frente = new Celula();
            this.tras = this.frente;
            this.frente.prox = null;
        }

        public void enfileira(Object x)
        {
            this.tras.prox = new Celula();
            this.tras = this.tras.prox;
            this.tras.item = x;
            this.tras.prox = null;
        }

        public Object desenfileira()
        {
            Object item = null;
            if (this.vazia())
                throw new Exception("Erro: A fila esta vazia");

            this.frente = this.frente.prox;
            item = this.frente.item;
            return item;
        }

        public bool vazia()
        {
            return (this.frente == this.tras);
        }

        public void imprime()
        {
            Celula aux; aux = this.frente.prox;
            while (aux != null)
            {
                Console.WriteLine(" " + aux.item.ToString());
                aux = aux.prox;
            }

            Console.WriteLine();
        }

    }
}
