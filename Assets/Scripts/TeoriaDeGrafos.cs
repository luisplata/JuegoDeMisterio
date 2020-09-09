using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void Start()
    {
        //vamos a colocar aleatoriamente el vertice final
        List<ObjetoInteractuable> objetosQuePuedenSerFinales = new List<ObjetoInteractuable>();
        foreach(GameObject iterado in GameObject.FindGameObjectsWithTag("objetosInteractuables"))
        {
            if(iterado.GetComponent<ObjetoInteractuable>().dialogoFinal != "")
            {
                //Debug.Log(iterado.name);
                objetosQuePuedenSerFinales.Add(iterado.GetComponent<ObjetoInteractuable>());
            }
        }

        int random = UnityEngine.Random.Range(0, objetosQuePuedenSerFinales.Count);
        verticeFinal = objetosQuePuedenSerFinales[random];

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
        //TODO se debe colocar random el orden de la escritura de dialogos, porque siempre el primero es el correcto.
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

    public string dialogoSegunElTiempoTranscurrido()
    {
        DateTime horaFinal = DateTime.Now;
        string respuesta = "";
        //sacamos de los player prefs el dato
        if (!PlayerPrefs.HasKey("tiempo"))
        {
            horaFinal.AddMinutes(20);
        }
        else
        {
            horaFinal = DateTime.Parse(PlayerPrefs.GetString("tiempo"));//HH:mm
        }

        float tiempoTranscurrido = ((DateTime.Now.Hour - horaFinal.Hour)*60)+(DateTime.Now.Minute - horaFinal.Minute);
        Debug.LogError("Esta es la diferecia " + tiempoTranscurrido);
        if(tiempoTranscurrido < ConstantesDelProyecto.TIEMPOMINIMO)
        {
            //resultado bueno
            //Te encuentras con {0}, sus vestiduras están manchadas y rotas, no tienes certeza de si está vivo hasta que abre un ojo y te sonríe. Aún sigue completamente ebri{1}
            respuesta = string.Format("Te encuentras con {0}, sus vestiduras están manchadas y rotas, no tienes certeza de si está vivo hasta que abre un ojo y te sonríe. Aún sigue completamente ebri{1}.", PlayerPrefs.GetString("genero").Contains("Femenino")? "Arturo":"Alba", PlayerPrefs.GetString("genero").Contains("Femenino") ?"o":"a");
        }
        else if(tiempoTranscurrido > ConstantesDelProyecto.TIEMPOMINIMO && tiempoTranscurrido < (ConstantesDelProyecto.TIEMPOMINIMO * ConstantesDelProyecto.TIEMPO_PRIMER_AVISO))
        {
            //resultado no tan bieno
            //Logras distinguir un rastro de sangre en el piso, una mezcla de sexto sentido y familiaridad te dice que es de tu amad{0}. Persigues el rastro hasta encontrarte con {1}, le intentas convencer de que todo estará bien.
            respuesta = string.Format("Encontraste rastros de sangre en el piso, sabiendo perfectamente que es de {0}, al final del pasillo ves que esta {1} tirado en el piso. Todo estará bien le dices a {0}.", PlayerPrefs.GetString("genero").Contains("Femenino") ? "o": "a", PlayerPrefs.GetString("genero").Contains("Femenino") ? "Arturo": "Alba");
        }else if (tiempoTranscurrido > (ConstantesDelProyecto.TIEMPOMINIMO * ConstantesDelProyecto.TIEMPO_PRIMER_AVISO) && tiempoTranscurrido < (ConstantesDelProyecto.TIEMPOMINIMO * ConstantesDelProyecto.TIEMPO_SEGUNDO_AVISO))
        {
            //resultado malo
            //Hay un olor a sangre pestilente, no es ese olor que despierta a tu bestia en busca de alimento, parece ser sangre vieja… y de {0}. Luego de un buen tiempo buscando, solo lográs encontrar su cuerpo muerto, prácticamente seco.
            respuesta = string.Format("Hay un olor a sangre pestilente, no es ese olor que despierta a tu bestia en busca de alimento, parece ser sangre vieja… y de {0}. Luego de un buen tiempo buscando, solo lográs encontrar su cuerpo muerto, prácticamente seco.", PlayerPrefs.GetString("genero").Contains("Femenino") ? "el": "ella");
        }else if (tiempoTranscurrido > (ConstantesDelProyecto.TIEMPOMINIMO * ConstantesDelProyecto.TIEMPO_SEGUNDO_AVISO))
        {
            //valio verga
            //Logras distinguir un cuerpo en el suelo… Mientras te acercas para corroborar distingues la túnica que le habías regalado… No hay otra opción, es {0}, su cuerpo está desprendido de su cabeza que no logras encontrar por más que busques. 
            respuesta = string.Format("Logras distinguir un cuerpo en el suelo… Mientras te acercas para corroborar distingues la túnica que le habías regalado… No hay otra opción, es {0}, su cuerpo está desprendido de su cabeza que no logras encontrar por más que busques.", PlayerPrefs.GetString("genero").Contains("Femenino") ?  "Arturo": "Alba");
        }
        StartCoroutine(DialogoFinalConMandadaHaciaInicio());

        return respuesta;
    }

    IEnumerator DialogoFinalConMandadaHaciaInicio()
    {
        yield return new WaitForSeconds(20);
        //eliminamos todo playerpref
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(ConstantesDelProyecto.CREDITOS);
    }
}
