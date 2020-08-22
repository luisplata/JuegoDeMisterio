using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TeoriaDeGrafos : MonoBehaviour
{
    [Header("Vertice Final")]
    [ContextMenuItem("Saca de los vertices actuales uno al azar", "GenerarVerticeFinal")]
    public ObjetoInteractuable verticeFinal;
    public List<ObjetoInteractuable> vertices;
    private List<ObjetoInteractuable> verticesVisitados;
    [Header("Distancias de los vertices")]
    [ContextMenuItem("Ejecutara una funcion recursiva para crear las distancias entre los verices", "GenerarMapaDeDialogosDelGrafo")]
    public ObjetoInteractuable distanciaDesdeAqui;
    private Dictionary<ObjetoInteractuable, int> distanciasPorVertice;
    [SerializeField]
    private int distanciaMaxima;
    
    //Generamos el verice final a partir de los vertices seleccionados

    public void GenerarVerticeFinal()
    {
        //numero random
        int random = UnityEngine.Random.Range(0, vertices.Count);
        verticeFinal = vertices[random];
    }

    public List<string> DialogosDeEsteObjeto(ObjetoInteractuable origen)
    {
        Dictionary<ObjetoInteractuable, int> caminos = new Dictionary<ObjetoInteractuable, int>();
        foreach(ObjetoInteractuable o in origen.aristas)
        {
            //reiniciar el estado vistado a todos
            foreach(GameObject oo in GameObject.FindGameObjectsWithTag("objetosInteractuables"))
            {
                oo.GetComponent<ObjetoInteractuable>().visitado = false;
                oo.GetComponent<ObjetoInteractuable>().distancia = 0;
            }
            caminos.Add(o, BFS(o));
        }
        //decidir cual es el mas corto y el largo de los caminos para sacar sus dialogos
        var myList = caminos.ToList();
        
        myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        
        List<string> dialogos = new List<string>();
        
        foreach(KeyValuePair<ObjetoInteractuable, int> l in myList)
        {
            if (l.Value.Equals(myList[0].Value))
            {
                dialogos.Add(l.Key.dialogoBueno);
            }
            else
            {
                dialogos.Add(l.Key.dialogoMalo);
            }
        }
        return dialogos;
    }

    /// <summary>
    /// Deprecada
    /// </summary>
    /// <param name="distancia"></param>
    /// <param name="verticeIndividual"></param>
    /// <returns></returns>
    public int FuncionRecursivaParaEncontrarFinal(int distancia, ObjetoInteractuable verticeIndividual)
    {
        if (verticeIndividual.Equals(verticeFinal))
        {
            if(distancia < distanciaMaxima)
            {
                distanciaMaxima = distancia;
            }
            else
            {
                //Debug.LogWarning(">>>>>> esporque es el final");
                return distancia;
            }
        }

        if (verticesVisitados.Contains(verticeIndividual) && verticeIndividual.distancia < distancia)
        {
            //Debug.LogWarning("Es porque ya a sido visitado "+ verticeIndividual.gameObject.name +" pero distancia recorrida hasta el fue de: "+verticeIndividual.distancia+" y la recorrida hsata ahora es de "+distancia );
            return distancia;
        }
        else
        {
            verticesVisitados.Add(verticeIndividual);
            verticeIndividual.distancia = distancia;
            ////Todo esta bien
            distancia++;
            foreach (ObjetoInteractuable arista in verticeIndividual.aristas)
            {
                //Debug.LogWarning("El objeto "+verticeIndividual.gameObject.name+" visita a: " + arista.gameObject.name + " distancia hasta aqui es: " + distancia);
                distancia = FuncionRecursivaParaEncontrarFinal(distancia, arista);
            }
            return distancia;
        }
    }


    public int BFS(ObjetoInteractuable origen)
    {
        Queue<ObjetoInteractuable> cola = new Queue<ObjetoInteractuable>();
        cola.Enqueue(origen);
        origen.visitado = true;
        int i = 0;
        while (cola.Count > 0)
        {
            ObjetoInteractuable v = cola.Dequeue();
            //si es el final return
            if (v == verticeFinal)
            {
                break;
            }
            i++;
            foreach (ObjetoInteractuable w in v.aristas)
            {
                if (!w.visitado)
                {
                    w.visitado = true;
                    w.distancia = i;
                    cola.Enqueue(w);
                }
                else if (w.distancia < i && w == verticeFinal)
                {
                    i = w.distancia;
                }
                else
                {
                    break;
                }
            }
        }
        return i;
    }

}
