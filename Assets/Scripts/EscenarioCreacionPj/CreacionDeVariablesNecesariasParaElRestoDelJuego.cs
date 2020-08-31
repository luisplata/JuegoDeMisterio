using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionDeVariablesNecesariasParaElRestoDelJuego : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey(ConstantesDelProyecto.VARIABLE_DE_PRIMERA_VEZ))
        {
            PlayerPrefs.SetInt(ConstantesDelProyecto.VARIABLE_DE_PRIMERA_VEZ, 1);
        }
    }

}
