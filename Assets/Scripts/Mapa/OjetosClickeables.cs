using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjetosClickeables : MonoBehaviour
{
    [SerializeField]
    private bool fuiClickeado;
    public void YaNoEsClickieable()
    {
        fuiClickeado = false;
    }
    private void OnMouseDown()
    {
        if (!fuiClickeado)
        {
            fuiClickeado = true;
            GameObject.Find("ControladorDeEscenario").GetComponent<ControlaLosObjetosClickeablesDelMapa>().referencia = gameObject;
            GameObject.Find("ControladorDeEscenario").GetComponent<ControlaLosObjetosClickeablesDelMapa>().StartFadeIn();
        }
    }
}
