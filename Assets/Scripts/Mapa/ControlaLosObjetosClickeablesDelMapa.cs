using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaLosObjetosClickeablesDelMapa : MonoBehaviour
{
    public GameObject UI;
    public GameObject referencia, guiaCamara;
    public float magnitudDeError;

    private void Update()
    {
        Vector2 diff = referencia.transform.position - guiaCamara.transform.position;
        guiaCamara.GetComponent<Rigidbody2D>().velocity = diff;
        
    }

    public void StartFadeIn()
    {
        //Seteamos el nombre de lo que es lo sacamos de la referencia
        UI.transform.Find("Panel").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Seguro Que Deseas entrar a " + referencia.name;
        StartCoroutine(FadeInCameraObject());
        UI.SetActive(true);
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOutCameraObject());
        UI.SetActive(false);
        referencia = GameObject.Find("ReferenciaDeReseteo").gameObject;
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("objetosInteractuables"))
        {
            o.GetComponent<OjetosClickeables>().YaNoEsClickieable();
        }
    }

    public void EntrarAlEscenario()
    {
        //hacemos un switch para cargar el escenario segun sea el objeto
        string nombreDelEscenario = "";
        switch (referencia.name)
        {
            case "Posada":
                break;
            case "Iglesia":
                nombreDelEscenario = "Iglesia_escena";
                break;
            case "el Bar":
                nombreDelEscenario = "isometric_escena";
                break;
            case "Restaurante":
                break;
            default:
                break;
        }

        SceneManager.LoadScene(nombreDelEscenario);
    }


    IEnumerator FadeInCameraObject()
    {
        for(float i = 3; i >= 1f; i -= 0.1f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(.01f);
        }
    }
    IEnumerator FadeOutCameraObject()
    {
        for (float i = 1f; i <= 3; i += 0.1f)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = i;
            yield return new WaitForSeconds(.01f);
        }
    }
}
