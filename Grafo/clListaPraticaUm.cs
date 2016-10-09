using List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafo
{
    public class clListaPraticaUm
    {

        GrafoLista G = null;

        public clListaPraticaUm(GrafoLista graf)
        {
            this.G = graf;
        }


        #region Considere um grafo nao dirigido

        /// <summary>
        /// Metodo verifica se  dois vertice sao adjacentes, pois 
        /// uma aresta (u , v) sai do vértice u e entra no vértice v. 
        /// O vértice v é adjacente ao vértice u.
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns> verdadeiro de for adjacente </returns>
        public bool isadjacente(int v1, int v2)
        {
            return G.existeAresta(v1, v2, 0);
        }

        /// <summary>
        /// Metodo para retorna o grau de m vertive, pois 
        /// Em grafos  nao direcionados :
        /// o grau de um vértice é o número de arestas que incidem nele.
        /// Em grafos direcionados :
        /// O grau de um vértice é o número de arestas que saem dele mais 
        /// o número de arestas que chegam nele.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Retorna o grau do Vertice </returns>
        public int getGrau(int v1)
        {
            return G.get_grauSaidaVertice(v1);
        }


        /// <summary>
        /// Metodo retorna se um grafo é regular, pois 
        /// um grafo em que todos os vértices tem o mesmo grau k.
        /// e dito grafo k regular onde k e o grau dos vertices.
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for regular</returns>
        public bool isRegular(Grafo G)
        {
            int nv = G.get_numVertices();
            int PGrau = 0, TGrau = 0, total = 0;
            for (int i = 0; i < nv; i++)
            {
                PGrau = getGrau(i);
                if ((PGrau == TGrau))
                {
                    total++;
                }
                TGrau = PGrau;
            }
            return (nv == total) ? true : false;
        }

        /// <summary>
        /// Metodo para verificar se uma vertice é isolado, pois 
        /// o grau de um vértice é o número de arestas que incidem nele.
        /// um vérice de grau zero é dito isolado ou não conectado.
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Verdadeiro de for isolado</returns>
        public bool isIsolado(int v1)
        {
            return (getGrau(v1) == 0) ? true : false;
        }

        /// <summary>
        ///  Metodo retorna se o vertice e pendente, pois 
        ///  um vertice pendente e aqule que tem grau 1
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Verdadeiro de for Pendente</returns>
        public bool isPedente(int v1)
        {
            return (G.get_grauSaidaVertice(v1) == 1) ? true : false;
        }

        /// <summary>
        ///  Metodo retorna se o grafo e nulo, pois 
        ///  um grafo nulo e o grafo que nao tem vertices ou arestas.
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Nulo</returns>
        public bool isNulo(Grafo G)
        {
            return (G.get_numVertices() > 0) ? true : false;
        }


        /// <summary>
        /// Metodo retorna se o grafo e completo, pois 
        /// Um grafo completo é um grafo simples em que todo vértice é adjacente 
        /// a todos os outros vértices. 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for completo</returns>
        public bool isCompleto(Grafo G)
        {
            int nv = G.get_numVertices();
            int PGrau = 0, total = 0;
            for (int i = 0; i < nv; i++)
            {
                PGrau = getGrau(i);
                if ((PGrau == (nv - 1)))
                {
                    total++;
                }
            }
            return (nv == total) ? true : false;
        }



        private static int TAM;
        private static int[] visitado = new int[TAM]; // vetor de visitação
        private static int[,] adj = new int[TAM, TAM];
        /// <summary>
        /// Metodo retorna se um grasfo e conexo , pois 
        /// Um grafo G=(V, E) é conexo se existir um caminho entre qualquer par de vértices.
        /// Caso Contrário é desconexo – se há pelo menos um par de vértices 
        /// que não está ligado a nenhuma cadeia  (caminho).
        /// Atenção: falar de componente conexa só faz sentido em grafos NÃO direcionados!
        /// Uma componente conexa é um subgrafo onde existe um caminho entre qualquer par de nós.
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for conexo</returns>
        public bool isConexo(Grafo G)
        {
            TAM = G.get_numVertices();
            // limpa todas as marcas de visitação
            for (int i = 0; i < TAM; i++)
                visitado[i] = 0;

            // inicia busca no nó de índice 0 Busca em profundidade (DFS)
            dfs(0);

            // testa se todos os nós foram visitados com uma única busca
            for (int i = 0; i < TAM; i++)
                if (visitado[i] != 0)
                    return false;
            return true;
        }


        public void dfs(int u)
        {
            if (visitado[u] == 1)
                return;
            visitado[u] = 1;
            for (int v = 0; v < TAM; v++)
                if (adj[u, v] == 1)
                {
                    dfs(v);
                }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Bipartido</returns>
        public bool isBipartido(Grafo G)
        {
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Retorna um grafo coplementar</returns>
        public Grafo getComplementar(Grafo G)
        {

            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Euleriano</returns>
        public bool isEuleriano(Grafo G)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Unicursal</returns>
        public bool isUnicursal(Grafo G)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for  hamiltoniano</returns>
        public bool isHamiltoniano(Grafo G)
        {
            return true;
        }

        #endregion

        #region Considere um grafo dirigido

        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Ciclo</returns>
        public bool hasCiclo(Grafo G)
        {
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Retorna o grau de Entrada</returns>
        public int getGrauEntrada(int v1)
        {
            return 2;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        public void ordenacaoTopologica(Grafo G)
        {
            //verifique  se  o  grafo é acíclico antes
            if (hasCiclo(G))
            {


            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns></returns>
        public Grafo getTransposto(Grafo G)
        {
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Conexo</returns>
        public bool isFConexo(Grafo G)
        {
            return true;
        }

        #endregion
    }
}
