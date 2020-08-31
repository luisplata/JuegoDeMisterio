using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeUI : MonoBehaviour
{
    ControladorDeCamaraPrincipal camara;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        camara = GetComponent<ControladorDeCamaraPrincipal>();
        camara.panelIzquierdo.SetActive(true);
        camara.panelDerecho.SetActive(true);
        UI.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
