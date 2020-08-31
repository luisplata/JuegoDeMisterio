using UnityEngine;
using System;
using System.Collections.Generic;

public class DialogoFactory : MonoBehaviour
{
    public List<Dialogo> dialogosFactory;
    private Dialogo dialogoInstanciado;

    public Dialogo Create(string id)
    {
        foreach(Dialogo buscado in dialogosFactory)
        {
            if (buscado.Id.Equals(id))
            {
                if(dialogoInstanciado != null)
                {
                    Destroy(dialogoInstanciado.gameObject);
                }
                dialogoInstanciado = Instantiate(buscado);
                return dialogoInstanciado;
            }
        }
        throw new Exception("No hay nada");
    }
}
