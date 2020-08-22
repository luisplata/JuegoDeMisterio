using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeCamaraDeEscenario : MonoBehaviour
{
    public List<GameObject> referenciasDePantalla;
    public int referenciaInicial;
    public GameObject panelIzquierdo, panelDerecho, panelDeDialogo;

    private void Start()
    {
        //buscamos la mitad de la lista
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().MovePosition(referenciasDePantalla[referenciaInicial].transform.position);

    }

    private void Update()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().velocity = referenciasDePantalla[referenciaInicial].transform.position - GameObject.FindGameObjectWithTag("GameController").transform.position;
    }


    public void ClickIzquierda()
    {
        panelDerecho.SetActive(true);
        referenciaInicial--;
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().MovePosition(referenciasDePantalla[referenciaInicial].transform.position);
        if(referenciaInicial <= 0)
        {
            //ocultar panel
            panelIzquierdo.SetActive(false);
        }
    }

    public void ClickDerecha()
    {
        panelIzquierdo.SetActive(true);
        referenciaInicial++;
        //GameObject.FindGameObjectWithTag("GameController").GetComponent<Rigidbody2D>().MovePosition(referenciasDePantalla[referenciaInicial].transform.position);
        if (referenciaInicial >= referenciasDePantalla.Count -1)
        {
            //ocultar panel
            panelDerecho.SetActive(false);
        }
    }

    public void ActivarDialogo()
    {
        panelDeDialogo.SetActive(true);
    }


    public void DesactivarDialogo()
    {
        panelDeDialogo.SetActive(false);
    }
}
