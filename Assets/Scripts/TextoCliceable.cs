using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TextoCliceable : MonoBehaviour, IPointerClickHandler
{
    public string URL;
    public void OnPointerClick(PointerEventData eventData)
    {
            // open the link id as a url, which is the metadata we added in the text field
            Application.OpenURL(URL);
      
    }

    public void ChangeEscene()
    {
        SceneManager.LoadScene(ConstantesDelProyecto.ESCENA_INICIAL);
    }
}
