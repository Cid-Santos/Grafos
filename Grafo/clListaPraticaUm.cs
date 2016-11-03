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
            return G.existeAresta(v1, v2, 1);
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
        ///  um vertice pendente e aquele que tem grau 1
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
            return (G.get_numVertices() > 0) ? false : true;
        }


        /// <summary>
        /// Metodo retorna se o grafo e completo, pois 
        /// Um grafo completo é um grafo simples em que todo vértice é adjacente 
        /// a todos os outros vértices. 
        /// Um grafo Kn possui o número máximo possível de arestas para um dados n. 
        /// Ele é, também regular-(n-1) pois todos os seus vértices tem grau n-1. 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro se for completo</returns>
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
            int numVertices = G.get_numVertices();
            bool[] visitados = new bool[numVertices];

            for (int i = 0; i < numVertices; i++)
                visitados[i] = false;

            for (int i = 0; i < numVertices; i++)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (G.existeAresta(i, j, 1) && i != j)
                    {
                        visitados[i] = true;
                    }
                }

            }

            for (int i = 0; i < numVertices; i++)
            {
                if (!visitados[i])
                    return false;
            }

            return true;
        }


        /// <summary>
        /// O metodo devolve true se o grafo  G é bipartido e devolve false em caso contrário. 
        /// Além disso, se G é bipartido, a função atribui uma "cor" a cada vértice de G de 
        /// tal forma que toda aresta tenha pontas de cores diferentes. As cores dos vértices, 
        /// 0 e 1, são registradas no vetor cor indexado pelos vértices. 
        /// um grafo bipartido ou bigrafo é um grafo cujos vértices podem ser 
        /// divididos em dois conjuntos disjuntos U e V tais que toda aresta
        /// conecta um vértice em U a um vértice em V; ou seja, U e V são conjuntos independentes.
        /// Equivalentemente, um grafo bipartido é um grafo que não contém qualquer ciclo de comprimento ímpar
        /// Os dois conjuntos U e V podem ser pensados como uma coloração do grafo com duas cores: 
        /// se nós colorirmos todos os nodos em U de azul, e todos os nodos em V de verde, cada
        /// aresta tem terminações de cores diferentes, como é exigido no problema de coloração de grafos.
        /// Em contrapartida, tal coloração é impossível no caso de um grafo que não é bipartido,
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Bipartido</returns>

        int numVertices;
        int[] cor;
        GrafoMatriz Gm = null;
        public bool isBipartido(GrafoMatriz Gm)
        {
            this.Gm = Gm;
            numVertices = Gm.get_numVertices();
            cor = new int[numVertices];
            int v;
            int c = 0; //representa a "cor"
            for (v = 0; v < numVertices; ++v) cor[v] = -1;
            for (v = 0; v < numVertices; ++v)
                if (cor[v] == -1)
                    if (dfsCor(v, c) == 0) return false;
            return true;
        }

        int dfsCor(int v, int c)
        {
            int p;
            cor[v] = 1 - c; //???
            for (p = 0; p < numVertices; ++p)
            {
                if ((Gm.mat[v, p] == 1 && v != p) && cor[p] == -1)
                { //existe aresta e ainda não tem cor
                    if (dfsCor(p, 1 - c) == 0) return 0;
                }
                else if (cor[p] == 1 - c) return 0;
            }
            return 1;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Retorna um grafo coplementar</returns>
        public Grafo getComplementar(GrafoMatriz Gm)
        {
            numVertices = Gm.get_numVertices();
            GrafoLista Gl = new GrafoLista(numVertices);
            for (int i = 0; i < numVertices; ++i)
            {
                for (int j = 0; j < numVertices; j++)
                {
                    if (!Gm.existeAresta(i, j, 1))
                    {
                        Gl.insereAresta(i, j, 1);
                    }
                }
            }


            return Gl;
        }


        /// <summary>
        /// O metodo devolve true se o grafo  G é Eureliano, pois 
        /// Um grafo G é dito ser euleriano se há um ciclo em G que contenha todas as suas arestas. Este ciclo é dito ser um ciclo euleriano. 
        /// um solução simples para determinar se um grafo é euleriano e o seguinte Teorema
        /// Teorema: Um multigrafo M é euleriano se e somente se M é conexo e cada vértice de M tem grau par. 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Euleriano</returns>
        public bool isEuleriano(Grafo G)
        {
            int M = G.get_numVertices();
            int N = 0;
            if (isConexo(G))
            {
                for (int v1 = 0; v1 < M; v1++)
                {
                    if ((getGrau(v1) % 2) == 0)
                    {
                        N++;
                    }
                }
                if (M == N)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// O metodo devolve true se o grafo  G é inicursal, pois 
        /// Um grafo conexo é unicursal se, e somente 
        /// se, ele possuir exatamente 2 vértices de grau ímpar.
        /// TEOREMA: Em um grafo conexo G com exatamente 2k
        /// vértices de grau ímpar, existem k subgrafos disjuntos
        /// de arestas, todos eles unicursais, de maneira que
        /// juntos eles contêm todas as arestas de G.
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Unicursal</returns>
        int N = 0;
        public bool isUnicursal(Grafo G)
        {
            int M = G.get_numVertices();
            if (isConexo(G))
            {
                for (int v1 = 0; v1 < M; v1++)
                {
                    if ((getGrau(v1) % 2) > 0)
                    {
                        N++;
                    }
                }
                if (2 == N)
                {
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// O metodo devolve true se o grafo  G é Hamiltoniano, pois 
        /// Um grafo G é dito ser hamiltoniano se existe um ciclo em G 
        /// que contenha todos os  seus vértices, sendo que cada vértice
        /// só aparece uma vez no ciclo.Este ciclo é chamado de ciclo hamiltoniano.
        /// Sendo assim.um grafo é hamiltoniano se ele contiver um ciclo hamiltoniano.
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for  hamiltoniano</returns>
        public bool isHamiltoniano(Grafo G)
        {
            int M = G.get_numVertices();
            if (M >= 3)
            {
                if (isCompleto(G))
                {
                    return true;
                }
            }
            return false;
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
            int M = G.get_numVertices();
            int[] vet = new int[M];

            int total = 0;
            int comp = 0;
            for (int v1 = 0; v1 < M; v1++)
            {
                for (int v2 = 0; v2 < M; v2++)
                {
                    if (G.existeAresta(v1, v2, 1))
                    {
                        vet[v2] = v2;
                    }
                }
                for (int i = 0; i < vet.Length; i++)
                {
                    if (vet[i] != v1) total++;
                }
                for (int j = 0; j < M; j++)
                {
                    if (vet[j] != v1)
                        for (int k = 0; k < M; k++)
                        {
                            if (vet[k] != v1)
                                if (G.existeAresta(vet[j], vet[k], 1))
                                {
                                    comp++;
                                }
                        }
                }
                if (total == comp)
                    return true;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <returns>Retorna o grau de Entrada</returns>
        public int getGrauEntrada(Grafo G, int v)
        {
            int M = G.get_numVertices();
            int grau = 0;
            for (int v1 = 0; v1 < M; v1++)
            {
                if (G.existeAresta(v1, v, 1))
                {
                    grau++;
                }
            }
            return grau;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        public void ordenacaoTopologica(Grafo G)
        {
            //verifique  se  o  grafo é acíclico antes
   

        }


        /// <summary>
        /// O metodo retorna o grafo transposto de G 
        /// </summary>
        /// <param name="G"></param>
        /// <returns></returns>
        public GrafoLista getTransposto(GrafoLista G)
        {
            return G.grafoTransposto();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="G"></param>
        /// <returns>Verdadeiro de for Conexo</returns>
        public bool isFConexo(Grafo G)
        {
            int M = G.get_numVertices();
            for (int v1 = 0; v1 < M; v1++)
            {
                for (int v2 = 0; v2 < M; v2++)
                {
                    if (!G.existeAresta(v1, v2, 1))
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        #endregion
    }
}
