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
        GameObject.FindGameObjectWithTag("Camara").GetComponent<CinemachineVirtualCamera>().Follow = referenciasDePantalla[referenciaInicial].transform;
    }


    public void ClickIzquierda()
    {
        panelDerecho.SetActive(true);
        referenciaInicial--;
        GameObject.FindGameObjectWithTag("Camara").GetComponent<CinemachineVirtualCamera>().Follow = referenciasDePantalla[referenciaInicial].transform;
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
        GameObject.FindGameObjectWithTag("Camara").GetComponent<CinemachineVirtualCamera>().Follow = referenciasDePantalla[referenciaInicial].transform;
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
