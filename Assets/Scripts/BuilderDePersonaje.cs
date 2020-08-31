using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderDePersonaje : MonoBehaviour
{

    public Genero masculino, femenino;
    public Piel blanca, negra;
    public Ropa azul, roja;
    public PersonajeBuilder personajeBuilder;
    // Start is called before the first frame update
    void Start()
    {
        //buscar en los palayerpref la constuiccion y contruirlo
        Debug.Log(PlayerPrefs.GetString("genero") + "  " + femenino.name);
        if (PlayerPrefs.GetString("genero").Contains(femenino.name))
        {
            personajeBuilder.ConGenero(femenino);
        }
        else
        {
            personajeBuilder.ConGenero(masculino);
        }
        Debug.Log(PlayerPrefs.GetString("ropa"));
        if (PlayerPrefs.GetString("ropa").Contains(azul.name))
        {
            personajeBuilder.ConRopa(azul);
        }
        else
        {
            personajeBuilder.ConRopa(roja);
        }
        Debug.Log(PlayerPrefs.GetString("piel"));
        if (PlayerPrefs.GetString("piel").Contains(blanca.name))
        {
            personajeBuilder.ConPiel(blanca);
        }
        else
        {
            personajeBuilder.ConPiel(negra);
        }
        personajeBuilder.Build();
    }
    
}
