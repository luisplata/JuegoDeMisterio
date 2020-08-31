using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorDeComportamientoDeInicio : MonoBehaviour
{
    public Button botonStart, botonContinuar;
    // Start is called before the first frame update
    void Start()
    {
        botonStart.onClick.AddListener(DesicionDeQuePantallaVaIr);
        botonContinuar.onClick.AddListener(ReiniciarTodo);
    }

    private void ReiniciarTodo()
    {
        SceneManager.LoadScene(ConstantesDelProyecto.ESCENA_MAPA_CREACION_PJ);
    }

    private void DesicionDeQuePantallaVaIr()
    {
        
        if(PlayerPrefs.HasKey(ConstantesDelProyecto.VARIABLE_DE_PRIMERA_VEZ))
        {
            //ya entro, y debe tener su pj
            SceneManager.LoadScene(ConstantesDelProyecto.ESCENA_MAPA_GENERAL);
        }
        else
        {
            //lo mandamos a la creacion del PJ
            ReiniciarTodo();
        }
    }
}
