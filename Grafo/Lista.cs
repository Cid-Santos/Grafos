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
    public class Lista
    {
        private class Celula
        {
            public Object item;
            public Celula prox;
        }
        private Celula primeiro, ultimo, pos;
        // Operações

        public Lista()
        { // Cria uma Lista vazia
            this.primeiro = new Celula();
            this.pos = this.primeiro;
            this.ultimo = this.primeiro;
            this.primeiro.prox = null;

        }

        private bool equals(Object chave, Object elemento)
        {
            if (chave.Equals(elemento))
                return false;
            
            return true;
        }

        public bool pesquisa(Object elemento)
        {
            if (this.vazia())
                return false;

            Celula aux = this.primeiro;
            while (aux.prox != null)
            {
                if (this.equals(aux.prox.item, elemento))
                    return true;

                aux = aux.prox;
            }
            return false;
        }

        /* insere novo item no final da lista */
        public void insere(Object item)
        {
            this.ultimo.prox = new Celula();
            this.ultimo = this.ultimo.prox;
            this.ultimo.item = item;
            
            this.ultimo.prox = null;
        }

        /* insere novo item no início da lista */
        public void insereNoInicio (Object item)
        {
            Celula nova = new Celula();
            nova.item = item;

            nova.prox = this.primeiro.prox;
            this.primeiro.prox = nova;            
        }

        public Object retira(Object obj)
        {
            if (this.vazia())
                throw new Exception("Erro : Lista vazia ou chave invalida");

            Celula aux = this.primeiro;
            while (aux.prox != null && !this.equals(aux.prox.item, obj))
                aux = aux.prox;

            if (aux.prox == null)
                return -1; // não encontrada

            Celula q = aux.prox;
            Object item = q.item;
            aux.prox = q.prox;

            if (aux.prox == null)
                this.ultimo = aux;

            return item;
        }
        
        public Object Primeiro()
        {
            this.pos = primeiro;
            return proximo();
        }

        public Object proximo()
        {
            this.pos = this.pos.prox;
            if (this.pos == null)
                return null;
            else
                return this.pos.item;
        }
        
        public bool vazia()
        {
            return (this.primeiro == this.ultimo);
        }

        public void imprime()
        {
            Celula aux = this.primeiro.prox;
            while (aux != null)
            {
                Console.Write(aux.item.ToString() + " ");
                aux = aux.prox;
            }
        }

        public int quantidade()
        {
            Celula aux = this.primeiro.prox;
            int qtd = 0;
            while (aux != null)
            {
                qtd++;
                aux = aux.prox;
            }

            return qtd;
        }


    }
}
